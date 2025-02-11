using Microsoft.AspNetCore.Mvc;
using RabbitMQ.API.Models;
using RabbitMQ.API.Services;

namespace RabbitMQ.API.Controllers;
[ApiController]
[Route("/api")]
public class PublisherController(PublisherService service) : ControllerBase
{
   private readonly PublisherService _service = service; 

   [HttpPost("send-transaction")]
   public async Task<IActionResult> PublishTransactionAsync([FromBody] Transaction transaction)
   {
      var result = await _service.CreateTransaction(transaction);

      return Ok(result);
   }
}