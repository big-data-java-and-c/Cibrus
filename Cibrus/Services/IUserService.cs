using Cibrus.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cibrus.Services
{
    public interface IUserService
    {
        Response Authenticate(string username, string password);
        IEnumerable<User> getAllUsers();
        void addUser(SignUpForm newUser);
        bool checkIfUserExists(string email);
        User getUserByUserId(int id);
        Teacher getTeacherByID(int id);
    }
}
