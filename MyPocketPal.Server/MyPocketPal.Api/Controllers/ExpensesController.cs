using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPocketPal.Core.Dtos.Expenses;
using MyPocketPal.Core.Interfaces;
using MyPocketPal.Data.Models;

namespace MyPocketPal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseWithCategoryNameDto>>> GetExpenses()
        {
            var expenses = await _expenseService.GetExpensesAsync();

            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseWithCategoryNameDto>> GetExpenseById(int id)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseWithCategoryNameDto>> AddExpense(CreateExpenseDto expenseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedExpense = await _expenseService.AddExpenseAsync(expenseDto);

            return CreatedAtAction(nameof(GetExpenseById), new { id = addedExpense.Id }, addedExpense);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Expense>> UpdateExpense(int id, Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedExpense = await _expenseService.UpdateExpenseAsync(expense);

            if (updatedExpense == null)
            {
                return NotFound();
            }

            return Ok(updatedExpense);
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Expense>> DeleteExpense(int id)
        //{
        //    var expense = await _expenseService.GetExpenseByIdAsync(id);
        //
        //    if (expense == null)
        //    {
        //        return NotFound();
        //    }
        //
        //    await _expenseService.DeleteExpenseAsync(expense);
        //
        //    return Ok(expense);
        //}
    }
}
