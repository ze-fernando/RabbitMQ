using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using RabbitMQ.API.Interfaces;
using RabbitMQ.API.Models;
using RabbitMQ.API.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RabbitMQ.Tests.Services
{
    public sealed class TransactionServiceTest
    {
        private readonly AppDbContext _context;
        private readonly ITransactionService _service;
        private readonly Faker<Transaction> _fakerTransactions;

        public TransactionServiceTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new AppDbContext(dbContextOptions);
            _service = Substitute.For<ITransactionService>();

            _fakerTransactions = new Faker<Transaction>("pt_BR").StrictMode(true)
                .RuleFor(t => t.Id, f => f.Random.Long(0, 100))
                .RuleFor(t => t.Sender, f => f.Person.FirstName)
                .RuleFor(t => t.To, f => f.Person.FirstName)
                .RuleFor(t => t.Confirmed, f => f.Random.Bool())
                .RuleFor(t => t.Value, f => f.Random.Double(0, 100))
                .RuleFor(t => t.Date, f => DateTime.Now);
        }

        [Fact]
        public async Task Service_Should_Return_List_Of_Transactions()
        {
            var fakeTransactions = _fakerTransactions.Generate(5);
            _service.GetAllTransactions().Returns(fakeTransactions);

            var res = await _service.GetAllTransactions();

            res.Should().BeAssignableTo<IEnumerable<Transaction>>();
            res.Should().HaveCount(5);
        }

        [Fact]
        public async Task Service_Should_Return_Empty_List_Of_Transactions()
        {
            var fakeTransactions = _fakerTransactions.Generate(0);
            _service.GetAllTransactions().Returns(fakeTransactions);

            var res = await _service.GetAllTransactions();

            res.Should().BeAssignableTo<IEnumerable<Transaction>>();
            res.Should().HaveCount(0);
        }
    }
}
