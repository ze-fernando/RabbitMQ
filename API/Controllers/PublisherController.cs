using Microsoft.AspNetCore.Mvc;
using RabbitMQ.API.Models;
using RabbitMQ.API.Services;

namespace RabbitMQ.API.Controllers;
public class PublisherController(TransactionService service) : ControllerBase
{
   private readonly TransactionService _service = service; 

   [HttpPost]
   public async Task<IActionResult> PublishTransactionAsync([FromBody] Transaction transaction)
   {
      var result = await _service.CreateTransaction(transaction);

      return Ok(result);
   }
}