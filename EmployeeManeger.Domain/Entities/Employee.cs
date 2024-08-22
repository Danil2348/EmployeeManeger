using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Domain.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Имя не указано")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Возраст не указан")]
        public uint Age { get; set; }

        [Required(ErrorMessage = "Должность не указана")]
        public string Post { get; set; }

        [Required(ErrorMessage = "Зарплата не указана")]
        [Range(0, double.MaxValue, ErrorMessage = "Зарплата не может быть отрицательной")]
        public double Salary { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfMemory { get; set; }
    }
}
