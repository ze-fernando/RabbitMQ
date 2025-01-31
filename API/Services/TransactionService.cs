using MassTransit;
using RabbitMQ.API.Models;
using RabbitMQ.API.Repository;

namespace RabbitMQ.API.Services;
public class TransactionService(IBus bus, TransactionRepository repository)
{
   private readonly IBus _bus = bus;
   private readonly TransactionRepository _repository = repository;
   public async Task<Transaction> CreateTransaction(Transaction transaction)
   {
      var _transaction = new Transaction{
         Sender = transaction.Sender,
         To = transaction.To,
         Confirmed = false,
         Value = transaction.Value,
         Date = DateTime.Now
      };

      _repository.Transactions.Add(_transaction);

      await _bus.Publish(_transaction);

      return _transaction;
   }
}