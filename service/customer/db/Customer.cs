namespace customer.db;
/// <summary>
/// Model Yapisi: Kalıtım olarak BaseEntity kullanildi, onun içindekilerde burada kullanılsın diye.
/// </summary>
public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string BDay { get; set; }
}
