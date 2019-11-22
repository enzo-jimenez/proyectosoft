using System;
using System.Collections.Generic;
using GeoAPI.Geometries;

namespace proyectosoft1._4.Models
{
    public partial class Comercio
    {
        public string ComId { get; set; }
        public string ComNombre { get; set; }
        public IGeometry ComUbicacion { get; set; }
        public string ComDescripcion { get; set; }
        public string ComDireccion { get; set; }
        public string ComUsId { get; set; }
        public string ComUbId { get; set; }
        public string ComProId { get; set; }

        public virtual Producto ComPro { get; set; }
        public virtual Ubicacion ComUb { get; set; }
        public virtual AspNetUsers ComUs { get; set; }
    }
}
