using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace back_end.Utilidades
{
	public class TypeBinder<T> : IModelBinder
	{
		public TypeBinder()
		{
		}

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var nombreProp = bindingContext.ModelName;
            var valor = bindingContext.ValueProvider.GetValue(nombreProp);

            if(valor == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            try
            {
                var valorDeserializado = JsonConvert.DeserializeObject<T>(valor.FirstValue);
                bindingContext.Result = ModelBindingResult.Success(valorDeserializado);
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.TryAddModelError(nombreProp, "Error de tipo de valor");
            }

            return Task.CompletedTask;
        }
    }
}

