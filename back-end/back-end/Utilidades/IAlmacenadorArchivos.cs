using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace back_end.Utilidades
{
	public interface IAlmacenadorArchivos
	{
        Task BorrarArchivo(string ruta, string contenedor);
        Task<string> GuardarArchivo(string contenedor, IFormFile archivo);
        Task<string> EditarArchivo(string contenedor, IFormFile archivo, string ruta);

    }
}

