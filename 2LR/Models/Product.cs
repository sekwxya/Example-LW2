using System.ComponentModel.DataAnnotations;

namespace _2LR.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите бренд")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина названия бренда должна быть от 1 до 50 символов")]
        public string? Brend { get; set; }

        [Required(ErrorMessage = "Введите модель")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина названия модели должна быть от 1 до 50 символов")]
        public string? ItemModel { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Введите положительное число")]
        public double? Price { get; set; }

    }

}
