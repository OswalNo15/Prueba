using HotelesVillage.Dominio.Interfaces;
using HotelesVillage.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelesVillage.Aplicaciones.Interfaces
{
    public interface IServicioHoteles
    {
        Task<Hotel> CreateAsync(Hotel modelo);
        Task<Hotel> EditAsync(Hotel modelo);
        void DeshabilitadAsync(long idHotel);
        Task<IQueryable<Hotel>> ListarGeneralAsync();

        Task<Hotel> SearchHotel(long idHotel);
        Task<Hotel> FindHotelxName(string nameHotel);
        Task<IQueryable<Hotel>> SeleccionarHotelPorSearchAsync(DateTime? FechaInicial, DateTime? FechaFinal, long? CantidadPersonas, string Location);
    }
}
