using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time2Goal.Models
{
    public class Login
    {
        public string email { get; set; }
        public string senha { get; set; }

        public Login(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }
    }
}
