namespace SimpleWebAPI.Models
{
    public class Transaction
    {
        public int IdMovimiento { get; set; }
        public int NroCuenta { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public decimal Monto { get; set; }
        public string CodMoneda { get; set; }
        public string Glosa { get; set; }
        public string DebitoCredito { get; set; }

        public Transaction(int idMovimiento, int nroCuenta, DateTime fechaMovimiento, decimal monto, string codMoneda, string glosa, string debitoCredito)
        {
            IdMovimiento = idMovimiento;
            NroCuenta = nroCuenta;
            FechaMovimiento = fechaMovimiento;
            Monto = monto;
            CodMoneda = codMoneda;
            Glosa = glosa;
            DebitoCredito = debitoCredito;
        }
    }
}
