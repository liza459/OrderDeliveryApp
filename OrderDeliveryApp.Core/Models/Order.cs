using System.ComponentModel.DataAnnotations;

namespace OrderDeliveryApp.Core.Models;

public class Order
{
	[Key]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "Город отправителя обязателен.")]
	[StringLength(100, ErrorMessage = "Город отправителя не может превышать 100 символов.")]
	[Display(Name = "Город отправителя")]
	public string SenderCity { get; set; }

	[Required(ErrorMessage = "Адрес отправителя обязателен.")]
	[StringLength(250, ErrorMessage = "Адрес отправителя не может превышать 250 символов.")]
	[Display(Name = "Адрес отправителя")]
	public string SenderAddress { get; set; }

	[Required(ErrorMessage = "Город получателя обязателен.")]
	[StringLength(100, ErrorMessage = "Город получателя не может превышать 100 символов.")]
	[Display(Name = "Город получателя")]
	public string ReceiverCity { get; set; }

	[Required(ErrorMessage = "Адрес получателя обязателен.")]
	[StringLength(250, ErrorMessage = "Адрес получателя не может превышать 250 символов.")]
	[Display(Name = "Адрес получателя")]
	public string ReceiverAddress { get; set; }

	[Required(ErrorMessage = "Вес груза обязателен.")]
	[Range(0.01, 10000.00, ErrorMessage = "Вес груза должен быть от 0.01 до 10000.")]
	[Display(Name = "Вес (кг)")]
	public decimal Weight { get; set; }

	[Required(ErrorMessage = "Дата забора груза обязательна.")]
	[DataType(DataType.Date)]
	[Display(Name = "Дата забора груза")]
	public DateTime PickupDate { get; set; }

	[Display(Name = "Номер заказа")]
	public int OrderNumber { get; set; }
}
