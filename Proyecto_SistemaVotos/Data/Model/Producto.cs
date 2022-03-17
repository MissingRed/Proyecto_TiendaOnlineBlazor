using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_TiendaOnline.Data.Model
{
    public class Producto
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Activo { get; set; }

    }
}
