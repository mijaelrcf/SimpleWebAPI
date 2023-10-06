using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Encryption;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var transactions = new List<Transaction>();
            transactions.Add(new Transaction(1, 2010001, DateTime.Now, 10, "BOB", "Pago QR", "D"));
            transactions.Add(new Transaction(2, 2010001, DateTime.Now, 20, "BOB", "Pago QR", "C"));
            transactions.Add(new Transaction(3, 2010001, DateTime.Now, 30, "BOB", "Pago QR", "D"));
            transactions.Add(new Transaction(4, 2010001, DateTime.Now, 40, "BOB", "Pago QR", "C"));
            transactions.Add(new Transaction(5, 2010001, DateTime.Now, 50, "BOB", "Pago QR", "C"));

            return Ok(transactions);
        }
    }
}
