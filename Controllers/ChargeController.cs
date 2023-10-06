using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Encryption;
using SimpleWebAPI.Models;
using System.Security.Cryptography;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargeController : ControllerBase
    {
        public ChargeController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            SimpleQR simpleQR = new SimpleQR();

            //Una vez obtenido los datos se arma el array de la informacion.
            string[] array = new string[]
            {
                simpleQR.Id.ToString(),
                simpleQR.TitularDestinatario,
                simpleQR.CiNitDestinatario,
                simpleQR.CodDestinatario.ToString(),
                simpleQR.CuentaDestino,
                simpleQR.CodMoneda,
                simpleQR.Importe.ToString(),
                simpleQR.Glosa,
                simpleQR.FechaVencimiento,
                simpleQR.UnicoUso.ToString(),
                simpleQR.CodigoServicio.ToString(),
                "Campo de uso futuro-----------"
                //nroSerieCertDigital
            };

            string textQR = string.Join("|", array);

            RsaEncryption rsaEncryption = new RsaEncryption();            
            string cypher = rsaEncryption.EncryptRsa(textQR);

            //string serialNumber = "2dc3d369fbf17c934b7e9424807e1ee8";

            //cypher += "|" + serialNumber;

            return Ok(cypher);
        }
    }
}
