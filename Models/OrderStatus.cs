using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public enum OrderStatus
    {
        [Display(Name ="Создан")]
        Created,
        [Display(Name = "Обработан")]
        Processed,
        [Display(Name = "В пути")]
        Delivering,
        [Display(Name = "Доставлен")]
        Delivered,
        [Display(Name = "Получен")]
        Received,
        [Display(Name = "Отменен")]
        Canceled
    }
}