using System;
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
        public ActionResult<Expense> Get(string id)
        {   
            var result = _expenseRepository.FindOne(id);
            if (result != default)
                return Ok(_expenseRepository.FindOne(id));
            return NotFound();
        }

        
        [HttpPost]
        public ActionResult<Expense> Insert([FromBody]Expense exp)
        {
            //generate id
            var newExpenseId = Guid.NewGuid().ToString();

            //update id in expense
            exp.Id = newExpenseId;

            var returnId = _expenseRepository.Insert(exp);
            ActionResult actionResult;

            if (returnId != default)
                actionResult = CreatedAtAction("Get", returnId , exp);
            else
                actionResult = BadRequest();
            return actionResult;
        }

        
        [HttpPut]
        public ActionResult<Expense> Update(Expense dto)
        {
            var result = _expenseRepository.Update(dto);
            ActionResult actionResult;
            if (result)
                actionResult = CreatedAtAction("Get", dto.Id , dto);
            else
                actionResult = BadRequest();
            return actionResult;
        }

        
        [HttpDelete("{id}")]
        public ActionResult<Expense> Delete(string id)
        {
            var result = _expenseRepository.Delete(id);
            if (result)
                return NoContent();
            return NotFound();
        }
    }
}