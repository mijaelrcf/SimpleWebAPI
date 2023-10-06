using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Encryption;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public IActionResult ReadQR(string cypher)
        {
            if (string.IsNullOrEmpty(cypher))
                return BadRequest();

            //string[] strTransaction = content.Split('|');
            
            //string cypher = strTransaction[0];
            //string serialNumber = strTransaction[1];

            RsaEncryption rsa = new RsaEncryption();
            string plainText = rsa.DecryptRsa(cypher);

            return Ok(plainText);
        }
    }
}
