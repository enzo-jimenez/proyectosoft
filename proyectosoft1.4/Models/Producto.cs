using System;
using System.Collections.Generic;

namespace proyectosoft1._4.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Comercio = new HashSet<Comercio>();
        }

        public string ProId { get; set; }
        public string ProNombre { get; set; }
        public decimal? ProPrecio { get; set; }
        public bool ProDisponible { get; set; }
        public string ProDescripcion { get; set; }

        public virtual ICollection<Comercio> Comercio { get; set; }
    }
}
