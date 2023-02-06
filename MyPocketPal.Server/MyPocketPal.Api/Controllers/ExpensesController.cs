using Microsoft.AspNetCore.Mvc;
using MyPocketPal.Core.Dtos.Expenses;
using MyPocketPal.Core.Interfaces;

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
    }
}
