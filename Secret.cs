using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRegistration
{
    public class Secret
    {
        public static string Connection { get; set; } = $"server=localhost;uid=root;pwd=abc123;database=moviedb";
    }
}
