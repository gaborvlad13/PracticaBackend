using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersPageBackend.Domain
{
    public class Materie
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Teachers { get; set; }

        public string Description { get; set; }



    }
}
