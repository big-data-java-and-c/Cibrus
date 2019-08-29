using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Cibrus.Context;
using Cibrus.models;
using Microsoft.EntityFrameworkCore;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;

namespace Cibrus.Services
{
    public class UserService : IUserService
    {
        private const string KEY = "likeJwtKeylikeJwtKey";
        private DatabaseContext databaseContext;

        public UserService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public void Save()
        {
            databaseContext.SaveChanges();
        }

        public void addUser(SignUpForm userForm)
        {
            User newUser = new User();
            newUser.email = userForm.email;

            string encryptedPassword = ComputeHash(KEY, userForm.password);
            newUser.password = encryptedPassword;

            //string role = userForm.role;

            if (userForm.role.Equals("STUDENT"))
            {
                newUser.RoleId = 2;
            }
            if (userForm.role.Equals("TEACHER"))
            {
                newUser.RoleId = 3;
            }
            databaseContext.users.Add(newUser);
            databaseContext.SaveChanges();

            if (newUser.RoleId == 1)
            {
                //value to add on registry for student
                Student newStudent = new Student();
                newStudent.UserId = newUser.UserId;
                newStudent.GroupId = 1;
                databaseContext.Students.Add(newStudent);
                databaseContext.SaveChanges();
            }

            if (newUser.RoleId == 2)
            {
                //value to add on registry for teacher
                Teacher teacher = new Teacher();
                teacher.UserId = newUser.UserId;
                databaseContext.teachers.Add(teacher);
                databaseContext.SaveChanges();
            }
        }

        private string ComputeHash(string kEY, string password)
        {
            var key = Encoding.UTF8.GetBytes(kEY);
            string hashString;
            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                hashString = Convert.ToBase64String(hash);
            }

            return hashString;
        }

        public Response Authenticate(string email, string password)
        {
            var user = databaseContext
                .users
                 .Where(b => b.email.Equals(email))
                 .FirstOrDefault();

            if (user == null) { return null; }

            var claim = new[]
            {
                new Claim(ClaimTypes.Name, user.email)
            };
            
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY)), SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                "http://localhost:4200/",
                "SampleAudience",
                claim,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
             );

            IdentityModelEventSource.ShowPII = true;
            var JWTResponse = new Response();
            JWTResponse.response.token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            JWTResponse.userId = user.UserId;
            JWTResponse.roleId = user.RoleId;

            return JWTResponse;
        }

        public bool checkIfUserExists(string email)
        {
            return databaseContext
                .users
                .Any(first => first.email.Equals(email));
        }

        public IEnumerable<User> getAllUsers()
        {
            return databaseContext.users;
        }

        public Teacher getTeacherByID(int id)
        {
            return databaseContext.teachers
                .Include(first => first.User)
                .Where(second => second.UserId.Equals(id))
                .FirstOrDefault();
        }

        public User getUserByUserId(int id)
        {
            return databaseContext.users
                .Include(first => first.Roles)
                .Where(second => second.UserId.Equals(id))
                .FirstOrDefault();
        }
    }
}
