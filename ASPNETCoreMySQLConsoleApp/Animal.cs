using System;
using System.Collections.Generic;

namespace ASPNETCoreMySQLConsoleApp
{
    public partial class Animal
    {
        public Animal()
        {
            Owner = new HashSet<Owner>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Owner> Owner { get; set; }
    }
}
