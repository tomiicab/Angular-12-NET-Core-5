﻿using System;
using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using NetTopologySuite.Geometries;

namespace back_end.Utilidades
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles(GeometryFactory geometryFactory)
		{
			CreateMap<Genero, GeneroDTO>().ReverseMap();

			//de generoCreacionDTO hacia Genero
			//entrada un dto y salida un genero
			CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<Actor, ActorDTO>().ReverseMap();
			CreateMap<ActorCreacionDTO, Actor>().ForMember(x => x.Foto, options => options.Ignore());

			CreateMap<CineCreacionDTO, Cine>()
				.ForMember(x => x.Ubicacion, x => x.MapFrom(dto =>
				geometryFactory.CreatePoint(new Coordinate(dto.Longitud, dto.Latitud))));
        }
	}
}

