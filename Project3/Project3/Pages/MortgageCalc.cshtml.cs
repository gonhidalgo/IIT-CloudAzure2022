using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Project2.Pages
{
    public class MortgageCalcModel : PageModel
    {
        public string MortgageResult { get; set; }
        [BindProperty]
        [Required]
        public double? InputValueLoan { get; set; }
        [BindProperty]
        [Required]
        public double? InputValueInterest { get; set; }
        [BindProperty]
        [Required]
        public double? InputValueDuration { get; set; }
       // [BindProperty]
        //[Required]
       // public double FinalValue { get; set; }
        //public double rounded { get; set; }
        public void OnPost()
        {

            if (ModelState.IsValid)
            {
                double FinalValue = MortgageCalcHelper.ComputeMonthlyPayment(InputValueLoan.Value, InputValueDuration.Value, InputValueInterest.Value);
                double rounded = System.Math.Round(FinalValue, 2);
                MortgageResult = $"The monthly payment is ${rounded} for a loan of ${InputValueLoan.Value} for {InputValueDuration.Value} and an interest rate of {InputValueInterest.Value}";
            }
            else
            {
                if (String.IsNullOrEmpty(ModelState["InputValueLoan"].AttemptedValue) ||
                String.IsNullOrWhiteSpace(ModelState["InputValueLoan"].AttemptedValue) ||
                String.IsNullOrEmpty(ModelState["InputValueInterest"].AttemptedValue) ||
                String.IsNullOrWhiteSpace(ModelState["InputValueInterest"].AttemptedValue) ||
                String.IsNullOrEmpty(ModelState["InputValueDuration"].AttemptedValue) ||
                String.IsNullOrWhiteSpace(ModelState["InputValueDuration"].AttemptedValue))
                {
                    MortgageResult = "Blanks are not valid. Please, insert a valid option";
                }
                else
                {
                    MortgageResult = $"Letters are not valid. Please, try again.";
                }


            }
    





          /*  if (String.IsNullOrEmpty(ModelState["InputValueLoan"].AttemptedValue) || 
                String.IsNullOrWhiteSpace(ModelState["InputValueLoan"].AttemptedValue) ||
                String.IsNullOrEmpty(ModelState["InputValueInterest"].AttemptedValue) || 
                String.IsNullOrWhiteSpace(ModelState["InputValueInterest"].AttemptedValue) || 
                String.IsNullOrEmpty(ModelState["InputValueDuration"].AttemptedValue) || 
                String.IsNullOrWhiteSpace(ModelState["InputValueDuration"].AttemptedValue))
            {
                MortgageResult = "Blanks are not valid. Please, insert a valid option";
            }
            else
            {
                FinalValue = MortgageCalcHelper.ComputeMonthlyPayment(InputValueLoan.Value, InputValueDuration.Value, InputValueInterest.Value);
                rounded = System.Math.Round(FinalValue, 2);
                MortgageResult = $"The monthly payment is ${rounded} for a loan of {InputValueLoan.Value} for {InputValueDuration.Value} and an interest rate of {InputValueInterest.Value}";

            }*/
        }
    }
}
