using Microsoft.AspNetCore.Mvc;
using RabbitMQ.API.Models;
using RabbitMQ.API.Services;

namespace RabbitMQ.API.Controllers;
[ApiController]
[Route("/api")]
public class TransactionController(TransactionService service) : ControllerBase
{
   private readonly TransactionService _service = service; 

   [HttpGet("get-transactions")]
   public async Task<IActionResult> GetTransactionAsync()
   {
      var result = await _service.GetAllTransactions();

      return Ok(result);
   }

   
   [HttpGet("get-one-transaction")]
   public async Task<IActionResult> GetOneTransactionAsync([FromBody] long id)
   {
      var result = await _service.GetTransactionById(id);

      return Ok(result);
   }
}