using System;
using back_end.Entidades;
using System.Collections.Generic;

namespace back_end.Repositorios
{
	public interface IRepositorio
	{
        List<Genero> ObtenerTodosLosGeneros();
        Genero ObtenerPorId(int Id);
    }
}

