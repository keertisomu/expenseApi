using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExpenseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : Controller
    {
        private readonly ILogger<ExpenseController> _logger;

        private readonly IRepository<Expense> _expenseRepository;

        public ExpenseController(IRepository<Expense> expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }


        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            return _expenseRepository.FindAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Expense> Get(int id)
        {   
            var result = _expenseRepository.FindOne(id);
            if (result != default)
                return Ok(_expenseRepository.FindOne(id));
            return NotFound();
        }
    
        //yet to implement
        //[HttpPost]
        //public ActionResult<Expense> Insert([FromBody]Expense dto)
        //{
        //    var  returnId = _expenseDbService.Insert(dto);
        //     ActionResult actionResult;

        //     if (returnId != default)
        //         actionResult = CreatedAtAction("Get", returnId);
        //    else
        //        actionResult = BadRequest();
        //    return actionResult;
        //}

        //[HttpPut]
        //public ActionResult<Expense> Update(Expense dto)
        //{
        //    var result = _expenseDbService.Update(dto);
        //    if (result)
        //        return NoContent();
        //    else
        //        return NotFound();
        //}

        //[HttpDelete("{id}")]
        //public ActionResult<Expense> Delete(int id)
        //{
        //    var result = _expenseDbService.Delete(id);
        //    if (result > 0)
        //        return NoContent();
        //    else
        //        return NotFound();
        //}
    }
}