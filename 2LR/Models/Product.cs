using System.ComponentModel.DataAnnotations;

namespace _2LR.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        public string ?Name { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Введите положительное число")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Введите вес")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Введите положительное число")]
        public double? Weight { get; set; }
    }

}
