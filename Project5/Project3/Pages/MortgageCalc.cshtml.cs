using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Globalization;

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
        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                ///////////////////////CALLING API/////////////////////
                //HttpClient httpClient = new HttpClient();
                //var result = await httpClient.GetAsync($"http://localhost:54380/api/MortgageCalc?principal={InputValueLoan.Value.ToString()}&rate={InputValueInterest.Value.ToString()}&years={InputValueDuration.Value.ToString()}");
                //string resultAsString = await result.Content.ReadAsStringAsync();

                //double.TryParse(resultAsString, out double FinalValue);
                //var rounded = System.Math.Round(FinalValue, 2);

                ////////////////CALLING FUNCTION////////////////////////////////////7
                HttpClient httpClient = new HttpClient();
                var functionResult = await httpClient.GetAsync($"http://localhost:7071/api/MonthlyPayment?principal={InputValueLoan.Value.ToString()}&rate={InputValueInterest.Value.ToString()}&years={InputValueDuration.Value.ToString()}");
                string functionAsString = await functionResult.Content.ReadAsStringAsync();
                double.TryParse(functionAsString, out double FinalValue);
                var rounded = System.Math.Round(FinalValue, 2);


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
            return;
        
        }
    }
}
