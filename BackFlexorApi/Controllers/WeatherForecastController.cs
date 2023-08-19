using BackFlexorApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackFlexorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost("Calcular")]
        public ActionResult<CalculationResponse> Calcular(List<Product> productos)
        {
            decimal subtotal = 0;
            decimal totalDescuento = 0;
            decimal totalIVA = 0;

            foreach (var producto in productos)
            {
                var totalProducto = producto.Precio * producto.Cantidad;
                subtotal += totalProducto;
                totalDescuento += producto.Descuento * producto.Cantidad;
                totalIVA += (totalProducto - producto.Descuento) * (producto.IVA / 100);
            }

            var result = new CalculationResponse
            {
                Respuesta = new CalculationResponse.CalculationDetail
                {
                    Subtotal = subtotal,
                    Descuento = totalDescuento,
                    IVA = totalIVA,
                    Total = subtotal - totalDescuento + totalIVA
                }
            };

            return Ok(result);
        }
    }
}