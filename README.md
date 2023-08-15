# etb_example
# service
##  DB (if not inMemory)
    İlk db kurulumu icin yapılacaklar
    --` dotnet-ef database update` migration to db
    -- Migration yok ise
        - ef toolunu eklemek icin `dotnet tool install --global dotnet-ef`
        - db migration generate ` dotnet-ef migrations add StartMigration`
## backend
Teknolojileri:
- framework, template olarak .net 7 `webapi` kullanıldı. Yeni servis oluşturmak için yeni servis klasöründe : 
    ``` dotnet new webapi ``` komutu calıştırılabilir
- ORM olarak `EntityFramework` kullanıldı
    - Veri tabanı seçenekleri sunuldu
        ``` application.json icinden guncellenebilir ```
        - InMemory
        - MSSQL
- Api explorer olarak `Swagger` kullanıldı.
  - Endpoint listesi için serviceurl/swagger adresi görüntülenebilir.
  - Logger //todo:
  //LOGSTASH
  //KIBANA
 //ELASTICH SEARCH
Db klasöründe model ve context mevcut

## UI

vue, typescript

## Customer

Model yapısı
    Name&Surname
    Email
    Phone
    Birthday

Endpointler
    - CRUD-List-Roles //TODO:

İstisnalar:
    Birthday guncellenemez (olabili)

Role (Yetki)
        - Silme sadece Admin tarafindan yapilir //TODO

Eventlar
    - Eklendigin CRM servisine kayit gonderilsin // TODO:

Ui:
    - CRUD-List islemleri