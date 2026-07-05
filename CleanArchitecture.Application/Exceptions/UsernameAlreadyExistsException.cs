using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Exceptions
{
    public class UsernameAlreadyExistsException:Exception
    {
        public UsernameAlreadyExistsException() : base("The username is already taken.") { }
        public UsernameAlreadyExistsException(string message):base(message) { }
    }
}
