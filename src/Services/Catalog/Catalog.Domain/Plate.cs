namespace Catalog.Domain
{
    public class Plate
    {
        public Guid Id { get; set; }

        public string? Registration { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SalePrice { get; set; }

        public string? Letters { get; set; }

        public int Numbers { get; set; }

        public Availability Availability { get; set; }

    }

    public enum Availability
    {
        Available = 0,
        Reserved = 1,
        Sold = 2,
        Revoked = 3,
    }
}