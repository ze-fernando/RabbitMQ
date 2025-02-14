using RabbitMQ.API.Models;

namespace RabbitMQ.API.Interfaces;

public interface ITransactionService
{
    public Task<List<Transaction>> GetAllTransactions();
    
    public Task<Transaction> GetTransactionById(long id);
}