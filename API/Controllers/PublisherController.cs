using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
   public class PublisherController(TransactionService service) : ControllerBase
   {
      private readonly TransactionService _service = service; 

      [HttpPost]
      public Task<IActionResult> PublishTransaction([FromBody] Transaction transaction)
      {
         var result = _service.CreateTransaction(transaction);

         return Ok(result);
      }
   }
}