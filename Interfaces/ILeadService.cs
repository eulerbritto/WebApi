using WebApi.Entities;
using WebApi.Models.Lead;

namespace WebApi.Interfaces;

public interface ILeadService
{
    IEnumerable<Lead> GetAll();
    IEnumerable<Lead> GetAllByStatus(string status);
    Lead GetById(int id);
    void Create(LeadRequest model);
    void Update(int id, UpdateRequest model);
    void Accept(int id);
    void Decline(int id);
    void Delete(int id);
}
