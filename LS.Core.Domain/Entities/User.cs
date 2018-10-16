using System;
using System.Collections.Generic;
using System.Text;

namespace LS.Core.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
}
