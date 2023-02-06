﻿using AutoMapper;
using MyPocketPal.Core.Dtos.Expenses;
using MyPocketPal.Core.Interfaces;
using MyPocketPal.Data.Models;
using MyPocketPal.Data.Repositories.Interfaces;

namespace MyPocketPal.Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<CreatedExpenseWithCategoryNameAndIdDto> AddExpenseAsync(CreateExpenseDto expenseDto)
        {
            if (expenseDto == null)
            {
                throw new ArgumentNullException(nameof(expenseDto));
            }

            try
            {
                var expense = _mapper.Map<Expense>(expenseDto);
                var addedExpense = await _expenseRepository.AddExpenseAsync(expense);
                return _mapper.Map<CreatedExpenseWithCategoryNameAndIdDto>(addedExpense);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding expense", ex);
            }
        }

        public async Task<ExpenseWithCategoryNameDto> GetExpenseByIdAsync(int id)
        {
            try
            {
                var expense = await _expenseRepository.GetExpenseAsync(id);
                return _mapper.Map<ExpenseWithCategoryNameDto>(expense);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving expense", ex);
            }
        }

        public async Task<IEnumerable<ExpenseWithCategoryNameDto>> GetExpensesAsync()
        {
            try
            {
                var expenses = await _expenseRepository.GetExpensesAsync();
                return _mapper.Map<IEnumerable<ExpenseWithCategoryNameDto>>(expenses);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving expenses", ex);
            }
        }

        public async Task<Expense> UpdateExpenseAsync(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }

            if (!await _expenseRepository.ExpenseExistsAsync(expense.Id))
            {
                throw new ArgumentException("Expense does not exist.");
            }

            try
            {
                await _expenseRepository.UpdateExpenseAsync(expense);

                return expense;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating expenses", ex);
            }
        }

        public async Task DeleteExpenseAsync(Expense expense)
        {
            try
            {
                if (expense == null)
                {
                    throw new ArgumentNullException("Expense cannot be null.");
                }

                if (!await _expenseRepository.ExpenseExistsAsync(expense.Id))
                {
                    throw new Exception("Expense not found.");
                }

                await _expenseRepository.DeleteExpenseAsync(expense.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting expenses", ex);
            }
        }
    }
}
