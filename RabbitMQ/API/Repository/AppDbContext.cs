using Microsoft.EntityFrameworkCore;
using RabbitMQ.API.Models;

namespace RabbitMQ.API.Repository;
public class AppDbContext : DbContext
{
    public DbSet<Transaction> Transactions {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}