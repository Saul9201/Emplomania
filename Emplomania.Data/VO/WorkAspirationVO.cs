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


        public override bool Equals(object obj)
        {
            var o = obj as WorkAspirationVO;
            if (o == null)
                return false;

            return this.WorkerFK.Equals(o.WorkerFK) && this.WorkplaceFK.Equals(o.WorkplaceFK);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + this.WorkerFK.GetHashCode();
            hash = (hash * 7) + this.WorkplaceFK.GetHashCode();
            return hash;
        }
    }
}
