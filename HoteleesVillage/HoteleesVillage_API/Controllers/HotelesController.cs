using HotelesVillage.Aplicaciones.Interfaces;
using HotelesVillage.Dominio.Modelos;
using HotelesVillage.Dominio.Modelos.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoteleesVillage.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("HotelesNetCoreRules")]
    public class HotelesController : ControllerBase
    {
        private readonly IServicioHoteles _HotelesService;
        public HotelesController(IServicioHoteles HotelesService)
        {
            _HotelesService = HotelesService;

        }

        [HttpGet]
        [Route("GetAllHotelAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> TodoLosHoteles()
        {

            var hoteles = await _HotelesService.ListarGeneralAsync();


            return StatusCode(StatusCodes.Status200OK, hoteles);
        }


        [HttpGet]
        [Route("GetHotelxIdAsync:long")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> HotelPorId(long id)
        {

            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "El id para buscar el hotel es obligatorio");
            }

            var hotel = await _HotelesService.SearchHotel(id);

            if (hotel == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "El hotel no ha sido encontrado");

            }

            return StatusCode(StatusCodes.Status200OK, hotel);
        }

        [HttpPost]
        [Route("CreateAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrearHotel([FromBody] HotelDTO modelo)
        {
            try
            {
                if (!ModelState.IsValid) {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                var resultado = await _HotelesService.FindHotelxName(modelo.Nombre);
                if (resultado  != null) {
                    ModelState.AddModelError("Nombre existente", "El nombre del hotel ya existe!");
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                if (modelo == null)
                    return StatusCode(StatusCodes.Status400BadRequest, "El modelo del hotel es obligatorio");

                Hotel obj = new Hotel()
                {
                    Nombre = modelo.Nombre,
                    Ubicacion = modelo.Ubicacion,
                    Estado = modelo.Estado
                };



                var respuesta = await _HotelesService.CreateAsync(obj);

                return CreatedAtRoute("GetHotelxIdAsync", new { id = respuesta.Id }, respuesta);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
           

        }


        [HttpPut]
        [Route("UpdateAsync:long")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ActualizarHotel(long? id,[FromBody] HotelDTO modelo)
        {

            try
            {
                #region se valida el modelo de clases
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                #endregion

                #region condicionales para validaciones del update
                if (id== null || id == 0) { 
                    return StatusCode(StatusCodes.Status400BadRequest, "El id para actualizar el hotel es obligatorio");
                }

                if (modelo == null)
                    return StatusCode(StatusCodes.Status400BadRequest, "El modelo del hotel es obligatorio");
                #endregion


                var objUpdate = await _HotelesService.SearchHotel(id.Value);

                #region validacion si se encontro el id del hotel que deseas actualizar la informacion
                if (objUpdate == null) {
                    return StatusCode(StatusCodes.Status404NotFound, "El hotel no ha sido encontrado para actualizar");
                }
                #endregion

                #region validacion para verificar si existe el numero nuevo que quieres actualizar 
                if (objUpdate.Nombre.ToLower() != modelo.Nombre.ToLower()) {
                    var resultadoHotelxName = await _HotelesService.FindHotelxName(modelo.Nombre);
                    if (resultadoHotelxName != null) {
                        ModelState.AddModelError("Nombre existente", "El nombre del hotel ya existe!");
                        return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                    }
                }
                #endregion

                objUpdate.Nombre = modelo.Nombre;
                objUpdate.Ubicacion = modelo.Ubicacion;
                objUpdate.Estado = modelo.Estado;



                 var respuesta = await _HotelesService.EditAsync(objUpdate);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }


        [HttpPut]
        [Route("DisabledAsync:long")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeshabilitarHotel(long? idHotel) {

            try
            {
                if (idHotel == null || idHotel == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "El id para deshabilitar el hotel es obligatorio");
                }

                await Task.Run(() => _HotelesService.DeshabilitadAsync(idHotel.Value));

                return StatusCode(StatusCodes.Status200OK, "Hotel deshabilitado");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }

    }
}
