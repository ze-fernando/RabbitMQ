using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class TransactionRepository : DbContext
    {
        public required DbSet<Transaction> Transactions {get; set;}
    }
}