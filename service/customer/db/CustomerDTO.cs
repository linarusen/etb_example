namespace customer.db;
/// Base class oluşturup benzer properylerin diğerlerinde var olması için kalıtım alındı.
/// Bu sayede InfoDto'daki bilgiler diğerlerinde de mevcut.
public class CustomerInfoDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string BDay { get; set; }

}

public class CustomerListResponseDTO : CustomerInfoDTO
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CustomerUpdateRequestDTO : CustomerInfoDTO
{
    public long Id { get; set; }
}

public class CustomerCreateRequestDTO : CustomerInfoDTO
{}