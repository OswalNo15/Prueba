using HotelesVillage.Aplicaciones.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelesVillage.Dominio.Modelos;
using HotelesVillage.Dominio.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.CodeAnalysis;

namespace HotelesVillage.Aplicaciones.Servicio
{
    public class HotelesServicio : IServicioHoteles
    {
        private readonly IRepositorioHoteles<Hotel> _repoHotel;
        public HotelesServicio(IRepositorioHoteles<Hotel> repoHotel)
        {
            _repoHotel = repoHotel;
        }
        public async Task<Hotel> CreateAsync(Hotel modelo)
        {
            if (modelo == null) throw new ArgumentNullException("El 'hotel' no existe");

            return await _repoHotel.CreateAsync(modelo);
        }

        public async void DeshabilitadAsync(long idHotel)
        {
            await Task.Run(() => _repoHotel.DeshabilitadAsync(idHotel));
        }

        public async Task<Hotel> EditAsync(Hotel modelo)
        {
            return await _repoHotel.EditAsync(modelo);
        }

        public async Task<IQueryable<Hotel>> ListarGeneralAsync()
        {
            return await _repoHotel.ListarGeneralAsync();
        }

        public async Task<IQueryable<Hotel>> SeleccionarHotelPorSearchAsync(DateTime? FechaInicial, 
            DateTime? FechaFinal, long? CantidadPersonas, string Location)
        {
            return await _repoHotel.SeleccionarHotelPorSearchAsync(FechaInicial, FechaFinal, CantidadPersonas, Location);
        }


        public async Task<Hotel> SearchHotel(long idHotel) {
            var listadoHotel = await _repoHotel.ListarGeneralAsync();

            return await Task.FromResult(listadoHotel.Where(a => a.Id == idHotel).FirstOrDefault());
        }

        public async Task<Hotel> FindHotelxName(string nameHotel) {
            var listadoHotel = await _repoHotel.ListarGeneralAsync();

            return await Task.FromResult(listadoHotel.Where(a => a.Nombre.ToLower().Equals(nameHotel.ToLower())).FirstOrDefault());
        }
    }
}
