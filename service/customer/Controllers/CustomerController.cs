namespace customer.Controllers;

using System.Net;
using Microsoft.AspNetCore.Mvc;

[ApiController]
// [Route("/")]
[Route("[controller]")]

public class CustomersController : ControllerBase
{
    private readonly ILogger<CustomersController> _logger; //her islem için loglama yapılabilir
    private readonly customer.db.CustomerContext _ctx = null;
    /// <summary>
    /// Dependicy injection ile logger ve context çağrılır, Program.cs'de CustomerContext eklemesi yapıldı.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="ctx"></param>
    public CustomersController(
        ILogger<CustomersController> logger,
        customer.db.CustomerContext ctx
    )
    {
        _logger = logger;
        _ctx = ctx;
    }

    #region Commands
    #region CRUD komutları

    [HttpPut("create")]
    public dynamic Create(db.CustomerCreateRequestDTO dto)
    {
        var model = new db.Customer
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            BDay = dto.BDay,
        };
        _ctx.Customers.Add(model);
        _ctx.SaveChanges();
        return new { ok = 1, id = model.Id };
    }

    [HttpPost]
    public dynamic Update(db.CustomerUpdateRequestDTO model)
    {
        var current = _ctx.Customers.FirstOrDefault(f => f.Id == model.Id);
        if (current is null) return NotFound($"{model.GetType().Name} not found in this service. Please check id "); //TODO: language

        #region Set edilen alanlar
        current.Name = model.Name;
        current.Phone = model.Phone;
        current.BDay = model.BDay;
        current.Email = model.Email;
        #endregion

        _ctx.SaveChanges();

        return Ok(new());
    }

    [HttpDelete("{id}")]
    public dynamic Delete(long id)
    {

        //var isAdmin = true; //todo
        // if (!isAdmin)
        //  return //

        var m = _ctx.Customers.FirstOrDefault(f => f.Id == id);
        ArgumentNullException.ThrowIfNull(m);
        _ctx.Customers.Remove(m);
        _ctx.SaveChanges();

        return Ok(new());
    }

    #endregion

    #region Other Actions
    /// <summary>
    /// Bir müşteri bilgilerini diğer müşteriye aktarmak icin kullanılır.( Not:Sadece action sayısını artırmak için eklendi)
    /// </summary>
    /// <param name="idFrom"></param>
    /// <param name="idTo"></param>
    /// <returns></returns>
    [HttpPost("transfer/{idFrom}/{idTo}")]
    public dynamic Transfer(long idFrom, long idTo)
    {
        var modelFrom = _ctx.Customers.FirstOrDefault(item => item.Id == idFrom);
        var modelTo = _ctx.Customers.FirstOrDefault(item => item.Id == idTo);

        modelTo.Name = modelFrom.Name;
        modelTo.Email = modelFrom.Email;
        modelTo.Phone = modelFrom.Phone;
        modelTo.BDay = modelFrom.BDay;

        _ctx.Customers.Remove(modelFrom);
        _ctx.SaveChanges();
        return new { ok = 1 };
    }

    #endregion

    #endregion

    #region Get Methods 
    /// <summary>
    /// Url format customer/:id (:id yazan yere ilgili modelin idsi gelmeli)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public dynamic GetEntity(long id)
    {
        var item = _ctx.Customers.Where(w => w.Id == id).SingleOrDefault();
        ArgumentNullException.ThrowIfNull(item);
        return item;
    }

    [HttpGet("list")]
    public IEnumerable<db.CustomerListResponseDTO> List()
    {
        return _ctx.Customers
        // .Where(w=> w.) // filterelemek  için parametre alınabilir
        .Select(item => new db.CustomerListResponseDTO
        {
            Id = item.Id,
            Name = item.Name,
            Email = item.Email,
            Phone = item.Phone,
            BDay = item.BDay,
            CreatedAt = item.CreatedAt
        })
        .ToList();
    }

    /// <summary>
    /// Ui rol listesini çağırarak frontend tarafında gerekli sayfa gösterimlerini yapabilir.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Roles")]
    public object GetRoles()
    {
        var isAdmin = false;  //todo:
        return new List<string>(){
            "create",
            "update",
             isAdmin ? "delete" : "",
            "list",
        };
    }
    #endregion
}
