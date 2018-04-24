using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class WorkAspiration
    {
        public int Id { get; set; }
        public Guid WorkerFK { get; set; }
        public Guid WorkplaceFK { get; set; }
        public Guid ScheduleFK { get; set; }
        public string Experience { get; set; }
        public string Observations { get; set; }
        public string Abilities { get; set; }
    }
}
