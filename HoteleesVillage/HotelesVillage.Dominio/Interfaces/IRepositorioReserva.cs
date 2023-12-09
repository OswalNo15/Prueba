using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelesVillage.Dominio.Interfaces
{
    public interface IRepositorioReserva<TEntityModel> where TEntityModel : class
    {
        Task<TEntityModel> CreateAsync(TEntityModel modelo);
        Task<TEntityModel> EditAsync(TEntityModel modelo);
        void CancelarReserva(long? idReserva);
        Task<IQueryable<TEntityModel>> ListarReservasAsync();
        Task<IQueryable<TEntityModel>> SeleccionarReservaAsync(long idReserva);
    }
}
