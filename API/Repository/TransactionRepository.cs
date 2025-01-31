using Microsoft.EntityFrameworkCore;
using RabbitMQ.API.Models;

namespace RabbitMQ.API.Repository;
public class TransactionRepository : DbContext
{
    public required DbSet<Transaction> Transactions {get; set;}
}