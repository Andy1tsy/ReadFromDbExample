using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWork
{
    public class Worker
    {
        int Id { get; set; }
        string Name { get; set; }
        int BossId { get; set; }
        int SpecialityId { get; set; }
        int IsBoss { get; set; }

        public Worker()
        {   }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{BossId}\t{SpecialityId}\t\t{IsBoss}";
        }
    }
}
