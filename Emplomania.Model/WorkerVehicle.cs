using System;

namespace Emplomania.Model
{
    public class WorkerVehicle
    {
        public int Id { get; set; }
        public Guid WorkerFK { get; set; }
        public Guid VehicleFK { get; set; }

    }
}