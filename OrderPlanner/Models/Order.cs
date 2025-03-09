using OrderPlanner.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace OrderPlanner.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Обязательное поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Недопустимая длина названия города")]
        [RegularExpression(@"^[А-Яа-я\s-]+$", ErrorMessage = "Недопустимый символ в названии города")]
        public string? SenderCity { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Недопустимая длина адреса")]
        [RegularExpression(@"^[А-Яа-я\s-.,\d]+$", ErrorMessage = "Недопустимый символ в адресе")]
        public string? SenderAdress { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Недопустимая длина названия города")]
        [RegularExpression(@"^[А-Яа-я\s-]+$", ErrorMessage = "Недопустимый символ в названии города")]
        public string? RecieverCity { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Недопустимая длина адреса")]
        [RegularExpression(@"^[А-Яа-я\s-.,\d]+$", ErrorMessage = "Недопустимый символ в адресе")]
        public string? RecieverAdress { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0, 999.9, ErrorMessage = "Недопустимый вес")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [FutureDate]
        public DateOnly PickupDate { get; set; }
    }
}
