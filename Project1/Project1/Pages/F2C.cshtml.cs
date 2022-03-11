using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project1.Pages
{
    public class F2CModel : PageModel
    {
        public string ConversionResult { get; set; }
        [BindProperty]
        [Required]
        public double? InputValue { get; set; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {

                //F = (C*1.8) + 32
                ConversionResult = $"{InputValue} Fahrenheit are {Math.Round((InputValue.Value - 32) * 5 / 9)} in Celsius";
            }
            else
            {
                if (String.IsNullOrEmpty(ModelState["InputValue"].AttemptedValue) || String.IsNullOrWhiteSpace(ModelState["InputValue"].AttemptedValue))
                {
                    ConversionResult = "Please, insert a valid option";
                }
                else
                {
                    ConversionResult = $"{ModelState["InputValue"].AttemptedValue} is not valid. Please, try again.";
                }
            }
        }
    }
}
