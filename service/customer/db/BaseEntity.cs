namespace customer.db;
// Genel olarak bir çok modelde bulunan özelliklerin diğerleri tarafindan kullanılması için oluşturuldu.
public class BaseEntity
{
    public long Id { get; set; } //Uniqe bilgi, 1 er artan (1,2,3,4,5)  
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    //Set edilmeden başlangıç olarak şimdiki zamani alması için( Not:Normalde uidan set edilmemesi icin dto modelinden bu alan çıkarılmalı)
}