using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models.LoginModels
{
    public class LoginSuccess
    {
        public object tokenString;

        public string A { get; set; }

        public string token { get; set; }

        public int id { get; set; }
        public string Name { get; set; }

    }
}
