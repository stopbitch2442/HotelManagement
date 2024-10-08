﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Domain;

public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption
        .Identity)] // Автоинкремент
    public int Id { get; set; } // Уникальный идентификатор номера

    [Required] public int HotelId { get; set; } // Идентификатор отеля, к которому принадлежит номер

    [Required] [StringLength(10)] public string RoomNumber { get; set; } // Номер комнаты
    [Required] public RoomType Type { get; set; } // Тип номера (например, одноместный, двухместный)
    [Required] public decimal Price { get; set; } // Цена за ночь
    [Required] public bool IsAvailable { get; set; } // Доступность номера

    public Room()
    {
        IsAvailable = true;
    }
}