namespace BackFlexorApi.Models
{
    public class CalculationResponse
    {
        public CalculationDetail Respuesta { get; set; }

        public class CalculationDetail
        {
            public decimal Subtotal { get; set; }
            public decimal IVA { get; set; }
            public decimal Descuento { get; set; }
            public decimal Total { get; set; }
        }
    }
}
