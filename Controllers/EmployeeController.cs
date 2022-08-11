namespace TestSqliteCore.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    public IConfiguration Configuration { get; }  
    public EmployeeController(IConfiguration configuration)
    {
        Configuration = configuration;       
    }

    [HttpGet]
    public IActionResult Get()
    {
        Models.employeeContext db=new Models.employeeContext();
        var result=db.Emps;
        return Ok(result);
    }

}