using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class WorkAspirationVO
    {
        public int Id { get; set; }
        public Guid WorkerFK { get; set; }
        public Guid? WorkplaceFK { get; set; }
        public Guid? ScheduleFK { get; set; }
        public string Experience { get; set; }
        public string Observations { get; set; }
        public string Abilities { get; set; }

        private WorkplaceVO workplace;
        public WorkplaceVO Workplace
        {
            get { return workplace; }
            set
            {
                workplace = value;
                if (value != null)
                    WorkplaceFK = value.Id;
            }
        }

        private ScheduleVO schedule;
        public ScheduleVO Schedule
        {
            get { return schedule; }
            set
            {
                schedule = value;
                if (value != null)
                    ScheduleFK = value.Id;
            }
        }

    }
}
