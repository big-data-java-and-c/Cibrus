using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cibrus.models
{
    public class Response
    {
        public Token response { get; set; }
        public long userId { get; set; }
        public int roleId { get; set; }

        public Response()
        {
            response = new Token();
        }
    }
}
