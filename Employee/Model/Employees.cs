using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ProductName is required.")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "ProductCode is required.")]
        public string? ProductCode { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
        public int StockQuantity { get; set; }

        public bool IsActive { get; set; }

        public bool AvailableForDelivery { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
