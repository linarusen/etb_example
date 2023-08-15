using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Ayarlar

//DB-Context Tanimlamasi: (db klasoru)
//MsSql ve diğer dbleri kullanmak icin opt.Use... şeklinde güncellenebilir, 
// Şimdilik geçici tutuluyor veriler. uygulama kapanıp açılınca silinir.
if (!string.IsNullOrEmpty(builder.Configuration.GetConnectionString("DefaultConnection")))
    builder.Services.AddDbContext<customer.db.CustomerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
else builder.Services.AddDbContext<customer.db.CustomerContext>(opt => opt.UseInMemoryDatabase(databaseName: "db"));

//Ui dan istek gönderirken farkli domainde (urlde) olduğu için hata veriyordu, izin vermek için eklendi (Cors izni)
builder.Services.AddCors(p => p.AddDefaultPolicy(builder => { builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));

#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//ui dan istek gelmesi icin (farkli domain);
app.UseCors();
app.Run();
