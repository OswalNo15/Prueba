using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelesVillage.Dominio.Interfaces
{
    public interface IRepositorioHoteles<TEntityModel> where TEntityModel : class
    {
        Task<TEntityModel> CreateAsync(TEntityModel modelo);
        Task<TEntityModel> EditAsync(TEntityModel modelo);
        void DeshabilitadAsync(long idHotel);
        Task<IQueryable<TEntityModel>> ListarGeneralAsync();
        Task<IQueryable<TEntityModel>> SeleccionarHotelPorSearchAsync(DateTime? FechaInicial, DateTime? FechaFinal, long? CantidadPersonas, string Location);
    }
}
