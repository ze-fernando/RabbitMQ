using Microsoft.EntityFrameworkCore;
using RabbitMQ.API.Models;
using RabbitMQ.API.Repository;

namespace RabbitMQ.API.Services;


public class TransactionService(AppDbContext repository)
{
   private readonly AppDbContext _repository = repository;

   public async Task<List<Transaction>> GetAllTransactions()
   {
      return await  _repository.Transactions.ToListAsync();
   }
   public async Task<Transaction> GetTransactionById(long id)
   {
      return await _repository.Transactions.SingleAsync(t => t.Id == id);
   }
}