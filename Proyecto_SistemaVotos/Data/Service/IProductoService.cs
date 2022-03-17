using Proyecto_TiendaOnline.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_TiendaOnline.Data.Service
{
    public interface IProductoService
    {
        Task<bool> ProductoInsert(Producto producto);
        Task<bool> ProductoUpdate(Producto producto);
        Task<bool> ProductoDelete(Producto Producto);
        Task<IEnumerable<Producto>> TodasProductos();
        Task<Producto> ObtenerProducto(int id);
        Task<List<Producto>> ListaProductos();
    }
}