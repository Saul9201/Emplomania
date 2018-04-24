using System;

namespace Emplomania.Model
{
    public class WorkerDriverLicense
    {
        public int Id { get; set; }
        public Guid WorkerFK { get; set; }
        public Guid DriverLicenseFK { get; set; }
    }
}