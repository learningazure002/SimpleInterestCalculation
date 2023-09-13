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
    public static class EMICalculation
    {
        [FunctionName("EMICalculation")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var emiModel = JsonConvert.DeserializeObject<EMIModel>(requestBody);
            var emi = EMICalculator.GetCalculatedEmi(emiModel.principalAmount, emiModel.rateOfIntrest, emiModel.TimeInYear);

            return new OkObjectResult($" Your EMI per month is : {emi}");
        }
    }
}
