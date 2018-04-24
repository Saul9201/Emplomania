using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class WorkReferenceVO
    {
        public int Id { get; set; }
        public Guid WorkerFK { get; set; }
        public string Place { get; set; }
        public string Occupation { get; set; }
        public string WorkedTime { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }

    }
}
