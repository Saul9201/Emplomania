using System;

namespace Emplomania.Model
{
    public class WorkerCourse
    {
        public int Id { get; set; }
        public Guid WorkerFK { get; set; }
        public Guid CourseFK { get; set; }
    }
}