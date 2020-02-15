﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExpenseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : Controller
    {
        private readonly ILogger<ExpenseController> _logger;
        private readonly LiteDbExpenseService _expenseDbService;

        public ExpenseController(ILogger<ExpenseController> logger, LiteDbExpenseService expenseDbService)
        {
            _expenseDbService = expenseDbService;
            //_logger = logger;
        }


        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            return _expenseDbService.FindAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Expense> Get(int id)
        {
            var result = _expenseDbService.FindOne(id);
            if (result != default)
                return Ok(_expenseDbService.FindOne(id));
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Expense> Insert([FromBody]Expense dto)
        {
            var  returnId = _expenseDbService.Insert(dto);
             ActionResult actionResult;

             if (returnId != default)
                 actionResult = CreatedAtAction("Get", returnId);
            else
                actionResult = BadRequest();
            return actionResult;
        }

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