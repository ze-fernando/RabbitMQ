using RabbitMQ.API.Models;
using RabbitMQ.API.Repository;

namespace RabbitMQ.API.Services;
public class TransactionService(TransactionRepository repository)
{
   private readonly TransactionRepository _repository = repository;

   public async Task<List<Transaction>> GetAllTransactions()
   {
    return await  _repository.Transactions.All();
   }
    public async Task<Transaction> GetTransactionById(long id)
   {
    return await _repository.Transactions.FirstOrDefault().Where(t => t.Id == id);
   }
}