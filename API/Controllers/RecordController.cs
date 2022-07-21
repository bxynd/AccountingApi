using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RecordController : ControllerBase
{
    private readonly IRecordService _recordService;

    public RecordController(IRecordService recordService)
    {
        _recordService = recordService;
    }
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _recordService.GetAllRecords());
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin,Regular")]
    public async Task<IActionResult> CreateRecord([FromBody]RecordDto record)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        try
        {
            return Ok(await _recordService.AddRecord(record));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [Authorize(Roles = "Admin,Regular")]
    [HttpGet("ByRecordId/{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok(await _recordService.GetRecordById(id));
    }
    
    [HttpPut("{id:Guid}")]
    [Authorize(Roles = "Admin,Regular")]
    public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] RecordDto record)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        try
        {
            return Ok(await _recordService.UpdateRecord(id,record));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpDelete("{id:Guid}")]
    [Authorize(Roles = "Admin,Regular")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        return Ok(await _recordService.DeleteRecord(id));
    }
}