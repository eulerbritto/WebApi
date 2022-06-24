using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Helpers;
using WebApi.Interfaces;
using WebApi.Models.Lead;
using WebApi.Services;

namespace WebApi.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class LeadsController : ControllerBase
{
    private ILeadService _leadService;
    private IMailService _mailService;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public LeadsController(
        ILeadService leadService,
        IMailService mailService,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _leadService = leadService;
        _mailService = mailService;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }


    [AllowAnonymous]
    [HttpPost("create")]
    public IActionResult Create(LeadRequest model)
    {
        _leadService.Create(model);
         return Ok();
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var leads = _leadService.GetAll();
        return Ok(leads);
    }

    [AllowAnonymous]
    [HttpGet("{status}")]
    public IActionResult GetAllByStatus(string status)
    {
        var leads = _leadService.GetAllByStatus(status);
        return Ok(leads);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var lead = _leadService.GetById(id);
        return Ok(lead);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _leadService.Update(id, model);
        return Ok(new { message = "Lead updated successfully." });
    }


    [HttpPut("{id}/accept")]
    public IActionResult Accept(int id)
    {
        _leadService.Accept(id);
        var lead = _leadService.GetById(id);
        _mailService.Send(lead);
        return Ok(new { message = "Lead was accepted successfully." });
    }

    [HttpPut("{id}/decline")]
    public IActionResult Decline(int id)
    {
        _leadService.Decline(id);
        return Ok(new { message = "Lead declined successfully." });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _leadService.Delete(id);
        return Ok(new { message = "Lead deleted successfully." });
    }
}