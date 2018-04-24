using System;

namespace Emplomania.Model
{
    public class WorkReference
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