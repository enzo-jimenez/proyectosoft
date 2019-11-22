using System;
using System.Collections.Generic;
using GeoAPI.Geometries;

namespace proyectosoft1._4.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Comercio = new HashSet<Comercio>();
        }

        public string UbId { get; set; }
        public IGeometry UbUbicacion { get; set; }

        public virtual ICollection<Comercio> Comercio { get; set; }
    }
}
