using WebApi.Entities;

namespace WebApi.Interfaces;

public interface IMailService
{
    void Send(Lead lead);
}
