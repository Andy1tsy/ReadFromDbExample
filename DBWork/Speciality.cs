using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWork
{
    public  class Speciality
    {
        int Id { get; set; }
        string Name { get; set; }

        public Speciality()
        { }

        public override string ToString()
        {
            return $"{Id}\t{Name}";
        }

    }
}
