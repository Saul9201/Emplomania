using System;
using System.Collections.Generic;

namespace Emplomania.Data.ApiClient.WebDTO
{
    public class NegocioDTO
    {
        public Guid Id { get; set; }
        #region DatosContacto
        public string TelefonoMovil { get; set; }
        public string Direccion { get; set; }
        public string TelefonoFijo { get; set; }
        public string CorreoElectronico { get; set; }
        public string SitioWeb { get; set; }
        #endregion

        #region Datos Generales
        public string Nombre { get; set; }
        public string DetallesNegocio { get; set; }

        #endregion

        public Guid CategoriaId { get; set; }
        public Guid DueñoId { get; set; }

        public List<Guid> Plazas { get; set; } = new List<Guid>();
    }
}