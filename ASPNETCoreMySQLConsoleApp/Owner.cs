using System;
using System.Collections.Generic;

namespace ASPNETCoreMySQLConsoleApp
{
    public partial class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Value { get; set; }
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
    }
}
