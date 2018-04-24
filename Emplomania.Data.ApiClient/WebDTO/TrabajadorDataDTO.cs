using System;
using System.Collections.Generic;

namespace Emplomania.Data.ApiClient.WebDTO
{
    public class TrabajadorDataDTO
    {
        public Guid Id { get; set; }
        public Guid TrabajadorId { get; set; }
        public Guid ColorOjosId { get; set; }
        public Guid ColorPiel { get; set; }
        public Guid Complexion { get; set; }
        public Guid GeneroId { get; set; }
        public Guid EstadoCivilId { get; set; }
        public Guid GradoEscolarId { get; set; }
        public Guid EspecialidadId { get; set; }
        public Guid HorarioId { get; set; }
        public List<Guid> Licencias { get; set; }
        public List<Guid> Vehiculos { get; set; }
        public List<Guid> Idiomas { get; set; }
        public List<Guid> Niveles { get; set; }
        public bool Hijos { get; set; }
        public double Estatura { get; set; }

    }
}