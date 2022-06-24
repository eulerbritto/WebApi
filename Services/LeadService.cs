using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Interfaces;
using WebApi.Models.Lead;

namespace WebApi.Services;

public class LeadService : ILeadService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public LeadService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Lead> GetAll()
    {
        return _context.Leads;
    }

    public IEnumerable<Lead> GetAllByStatus(string status)
    {
        var leads = _context.Leads.Where(w=>w.Status.ToLower().Equals(status.ToLower()));
        if (leads is null)
            throw new KeyNotFoundException($"No leads was found with {status} status.");
        return leads;
    }

    public Lead GetById(int id)
    {
        return GetLead(id);
    }

    public void Create(LeadRequest model)
    {
        if (_context.Leads.Any(x => x.FirstName.ToLower().Equals(model.FirstName.ToLower()) &&
                                x.DateCreated.Equals(model.DateCreated)))
            throw new AppException("Error creating new lead.");

        var lead = _mapper.Map<Lead>(model);

        _context.Leads.Add(lead);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var lead = GetLead(id);

        if (!model.FirstName.ToLower().Equals(lead.FirstName.ToLower()) && 
            _context.Leads.Any(x => x.FirstName.ToLower().Equals(model.FirstName.ToLower())))
            throw new AppException("It wasn't possible to update this lead.");

        var leadModel = _mapper.Map<Lead>(model);
        _context.Leads.Update(leadModel);
        _context.SaveChanges();
    }

    public void Accept(int id)
    {
        var lead = GetLead(id);
        if (!_context.Leads.Any(x => x.Id.Equals(id)))
            throw new AppException("Impossible to accpet the lead. It was not found.");

        lead.Status = "Accepted";
        lead.Price = lead.Price > 500 ? lead.Price * 0.9m : lead.Price;
        _context.Leads.Update(lead);
        _context.SaveChanges();
    }

    public void Decline(int id)
    {
        var lead = GetLead(id);
        if (!_context.Leads.Any(x => x.Id.Equals(id)))
            throw new AppException("Impossible to decline the lead. It was not found.");

        lead.Status = "declined";
        _context.Leads.Update(lead);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var lead = GetLead(id);
        _context.Leads.Remove(lead);
        _context.SaveChanges();
    }

    private Lead GetLead(int id)
    {
        var lead = _context.Leads.Find(id);
        if (lead is null) 
            throw new KeyNotFoundException("Lead not found.");
        return lead;
    }
}