using System;
using back_end.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Repositorios
{
	public interface IRepositorio
	{
        List<Genero> ObtenerTodosLosGeneros();
        Task<Genero> ObtenerPorId(int Id);
        //Guid ObtenerGuid();
        void CrearGenero(Genero genero);
    }
}