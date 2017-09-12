using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Entry
    {
        public char Sign { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }

        public Entry(char sign, string first_name, string middle_name, string last_name)
        {
            Sign = sign;
            First_Name = first_name;
            Middle_Name = middle_name;
            Last_Name = last_name;
        }
        
    }
}
