using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("consumer")]
    public class ConsumerController(TransactionService service) : ControllerBase
    {
        private readonly TransactionService _service = service;
        [HttpGet]
        public Task<IActionResult> ConsumeTransactions([FromRoute] long transaction_id)
        {
            var result = _service.GetTransactionById(transaction_id);
            return Ok(result);
        }
    }
}