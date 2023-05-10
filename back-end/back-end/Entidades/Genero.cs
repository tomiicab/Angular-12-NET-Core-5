using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using back_end.Validaciones;

namespace back_end.Entidades
{
	public class Genero : IValidatableObject
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "El campo {0} es requerido")]
		[StringLength(maximumLength: 10)]
		//[PrimeraLetraMayuscula]
        public string Nombre { get; set; }

		[Range(18, 120)]
		public int Edad { get; set; }

		[CreditCard]
		public string TarjetaDeCredito { get; set; }

		[Url]
		public string URL { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
			if (!string.IsNullOrEmpty(Nombre))
			{
				var primeraLetra = Nombre[0].ToString();

				if (primeraLetra != primeraLetra.ToUpper())
				{
                    //con yield se van obteniendo los elementos a medida que lo necesite quien nos llame
                    yield return new ValidationResult("La primera letra debe ser mayuscula",
						new string[] { nameof(Nombre) });//aca decimos que el error le corresponde al campo nombre
				}
			}
        }
    }
}