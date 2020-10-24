using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Proveedor.Despachos.PublisherListeningAzure
{
    public static class MensajeDespacho
    {
        [FunctionName("MensajeDespacho")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //            log.LogInformation("C# HTTP trigger function processed a request.");

            //            string name = req.Query["name"];
            string responseMessage;
            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Modelos.DespachoMd data = JsonConvert.DeserializeObject<Modelos.DespachoMd>(requestBody);
                //            name = name ?? data?.name;

                CorePOSApi.Business.Data.context.DataModelService da = new CorePOSApi.Business.Data.context.DataModelService();

                da.ExecuteNonQueryModel<Modelos.DespachoMd>("dbo.spr_despachos_disponibles_insert", data);

                responseMessage = "OK";

            }
            catch(Exception ex)
            {

                responseMessage = ex.Message;

            }

            return new OkObjectResult(responseMessage);
        }
    }
}
