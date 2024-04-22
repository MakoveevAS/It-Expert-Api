using It_Expert.Domain.Dtos;
using It_Expert.Domain.Requests;
using It_Expert.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace It_Expert.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
[ApiVersion("1.0")]
public class DataController : ControllerBase
{

    private readonly IDataService _dataService;

    public DataController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet(Name = "Data")]
    [SwaggerOperation(Summary = "request data from db")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(DataDto[]))]
    public async Task<IActionResult> Get(int? code, string? value)
    {
        return Ok(await _dataService.GetDataAsync(code, value));
    }


    [HttpPost(Name = "Data")]
    [SwaggerOperation(Summary = "save data into db")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] PostRequest dataRequest)
    {
        await _dataService.SaveDataAsync(dataRequest);

        return Ok();

    }
}
