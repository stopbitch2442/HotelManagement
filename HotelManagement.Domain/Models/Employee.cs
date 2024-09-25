using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Domain;

public class Employee
{
    [Key] public int Id { get; set; } // Уникальный идентификатор работника
    [Required] [MaxLength(100)] public string FirstName { get; set; } // Имя работника
    [Required] [MaxLength(100)] public string LastName { get; set; } // Фамилия работника

    [Required]
    [MaxLength(100)]
    public string Position { get; set; } // Должность работника (например, администратор, горничная)

    [Required] public decimal Salary { get; set; } // Зарплата работника

    public int HotelId { get; set; } // Идентификатор отеля, в котором работает работник
}