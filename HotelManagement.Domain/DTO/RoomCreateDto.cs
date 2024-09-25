using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Domain.DTO;

public class RoomCreateDto
{
    [Required]
    public int HotelId { get; set; } // Идентификатор отеля, к которому принадлежит номер
        
    [Required]
    [StringLength(10)]
    public string RoomNumber { get; set; } // Номер комнаты
        
    [Required]
    public RoomType Type { get; set; } // Тип номера (например, одноместный, двухместный)
        
    [Required]
    public decimal Price { get; set; } // Цена за ночь
        

}