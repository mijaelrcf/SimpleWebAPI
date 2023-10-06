using System.ComponentModel.DataAnnotations;

namespace SimpleWebAPI.Models
{
    public class SimpleQR
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string TitularDestinatario { get; set; }
        [Required]
        public string CiNitDestinatario { get; set; }
        [Required]
        public int CodDestinatario { get; set; }
        [Required]
        public string CuentaDestino { get; set; }
        [Required]
        public string CodMoneda { get; set; }
        public int Importe { get; set; }
        public string Glosa { get; set; }
        [Required]
        public string FechaVencimiento { get; set; }
        [Required]
        public bool UnicoUso { get; set; }
        public int CodigoServicio { get; set; }
        public string CampoLibre { get; set; }
        [Required]
        public string NroSerieCertDigital { get; set; }

        public SimpleQR()
        {
            Id = Guid.NewGuid();
            TitularDestinatario = "Juan Perez";
            CiNitDestinatario = "123456";
            CodDestinatario = 123;
            CuentaDestino = "2010002";
            CodMoneda = "BOB";
            Importe = 10000;
            Glosa = "pago";
            FechaVencimiento = DateTime.Now.ToString("yyyy-MM-dd");
            UnicoUso = false;
            CodigoServicio = 123;
            NroSerieCertDigital = "201000201";
        }
    }
}
