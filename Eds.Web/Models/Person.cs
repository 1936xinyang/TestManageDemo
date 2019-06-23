using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eds.Web.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}