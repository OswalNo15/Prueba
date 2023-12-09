using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelesVillage.Dominio.Interfaces
{
    public interface IRepositorioHabitaciones<TEntityModel> where TEntityModel : class
    {
        Task<TEntityModel> CreateAsync(TEntityModel modelo);
        Task<TEntityModel> EditAsync(TEntityModel modelo);
        void DeshabilitadAsync(long? idHabitacion);

        Task<IQueryable<TEntityModel>> ListarHabitacionesAsync();
        Task<IQueryable<TEntityModel>> SeleccionarHabitacionxHotelAsync(long? idHotel);
    }
}
