using System.ComponentModel.DataAnnotations;

namespace IVS_RazorPages.Models
{
    public class Employee // класс-конструктор таблицы БД - определяет поля таблицы
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field cannot be null! Please, Write the name")]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please, enter a Valid Email (format: example@ex.com)")]
        [MaxLength(50), MinLength(2)]
        public string Email { get; set; }

        public string PhotoPath { get; set; }

        public Dept? Department { get; set; }
    }
}
