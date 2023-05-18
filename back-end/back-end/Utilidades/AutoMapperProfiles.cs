using System;
using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;

namespace back_end.Utilidades
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Genero, GeneroDTO>().ReverseMap();

			//de generoCreacionDTO hacia Genero
			//entrada un dto y salida un genero
			CreateMap<GeneroCreacionDTO, Genero>();
		}
	}
}

