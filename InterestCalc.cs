using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzFuncLoanCalculation
{
    public static class InterestCalc
    {
        [FunctionName("InterestCalc")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            InterestCalculation input = JsonConvert.DeserializeObject<InterestCalculation>(requestBody);
            var totalInterest = input.PrincipleAmount * input.NoOfYear * input.RateOfInterest / 100;
            var totalAmount = input.PrincipleAmount + totalInterest;
            return new OkObjectResult($" Total Interest Incurred : {totalInterest} \n Final Amount to pay : {totalAmount}");
        }
    }

    public class InterestCalculation
    {
        public double RateOfInterest;
        public int NoOfYear;
        public double PrincipleAmount;
    }
}
