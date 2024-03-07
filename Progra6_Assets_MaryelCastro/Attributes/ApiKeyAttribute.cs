using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;



namespace Progra6_Assets_MaryelCastro.Attributes

{

    //con este atributo personalizado lo que se quiere es integrar una capa
    //de seguridad por medio de una llave (clave:valor) 
    //con esto se va a decorar ya sea todo un controller o solo 
    //ciertos end points para que no se puedan usar a menos que se 
    //integre la llave en el encabezado http que lo consume 



    [AttributeUsage(validOn: AttributeTargets.All)]
    public sealed class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        //indicamos cuál es la llave que se usará, esto estará en el 
        //archivo appsettings.json 
        private readonly string _apiKey = "P6ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context,ActionExecutionDelegate next)
        {

            //en esta función validamos que el json que llega al WebAPI tenga los 
            //datos del ApiKey válidos, caso contrario mostramos un error en el 
            //response del endpoint
            if (!context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var ApiSalida))
            {

                //en el caso que no venga info de apikey en el header entonces....
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "The http request doesn't contain security information"
                };
                return;
            }

            //pero si viene la info de apikey se procede con....
            //ahora que sabemos que la info de apikey viene, hay que validar que sea 
            //la correcta. 

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var ApiKeyValue = appSettings.GetValue<string>(_apiKey);

            //a este punto tenemos todo lo necesario para hacer la comparación de valores 

            if (ApiKeyValue != null && !ApiKeyValue.Equals(ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Incorrect ApiKey Data.... "
                };
                return;
            }

            await next();

        }











    }
}
