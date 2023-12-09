using HotelesVillage.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelesVillages.Infraestructura.Datos.DataContext;
using HotelesVillage.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelesVillage.Dominio.Repositorios
{
    public class HotelesRepositorio : IRepositorioHoteles<Hotel>
    {
        private readonly HotelesContext _dbContextHotel;

        public HotelesRepositorio(HotelesContext dbContextHotel)
        {
            _dbContextHotel = dbContextHotel;
        }
        public async Task<Hotel> CreateAsync(Hotel modelo)
        {
            if (modelo == null)
            {
                throw new ArgumentNullException("El 'hotel' no existe");
            }
            _dbContextHotel.Hotels.Add(modelo);
            await _dbContextHotel.SaveChangesAsync();
            return modelo;
        }

        public async void DeshabilitadAsync(long idHotel)
        {
            var hotelReturn = await _dbContextHotel.Hotels.FindAsync(idHotel);

            if (hotelReturn == null)
                throw new ArgumentNullException("El no existe el hotel que intentas buscar");

            hotelReturn.Estado = false;


            _dbContextHotel.Hotels.Update(hotelReturn);
            await _dbContextHotel.SaveChangesAsync();

        }

        public async Task<Hotel> EditAsync(Hotel modelo)
        {
            _dbContextHotel.Hotels.Update(modelo);
            await _dbContextHotel.SaveChangesAsync();
            return modelo;

        }

        public async Task<IQueryable<Hotel>> ListarGeneralAsync()
        {
            IQueryable<Hotel> queryHotelSql =  _dbContextHotel.Hotels;
            return queryHotelSql;
        }

        public async Task<IQueryable<Hotel>> SeleccionarHotelPorSearchAsync(DateTime? FechaInicial, DateTime? FechaFinal, long? CantidadPersonas, string Location)
        {
            var ListadoHoteles = await _dbContextHotel.ViewSearchHotelxHabitacion
                 .Where(a => ((a.FechaCheckin < FechaInicial && a.FechaCheckout > FechaFinal) || (a.FechaCheckin == null && a.FechaCheckout == null)) &&
                 (a.CantidadPersonas == (CantidadPersonas == null ? a.CantidadPersonas : CantidadPersonas)) &&
                 a.UbicacionHotel.Equals(!string.IsNullOrEmpty(Location) ? Location : a.UbicacionHotel)).ToListAsync();

            IQueryable<Hotel> hotelReturn = ListadoHoteles.Select(a => new Hotel
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Ubicacion = a.UbicacionHotel,

            }).AsQueryable();

            return hotelReturn;

        }
    }
}
