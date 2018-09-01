using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcFrameForProjectModel
{
    public class UserLoginInModel
    {
        public string Username { get; set; }

        public string Passwd { get; set; }

        public string VerificationCode { get; set; }

        public bool RememberPassword { get; set; }

    }
}
