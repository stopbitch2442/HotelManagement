using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Domain
{
    public enum RoomType
    {
        [Display(Name = "Single")]
        Single,
        
        [Display(Name = "Double")]
        Double,
        
        [Display(Name = "Suite")]
        Suite,
        
        [Display(Name = "Deluxe")]
        Deluxe,
        
        [Display(Name = "Family")]
        Family
    }
}