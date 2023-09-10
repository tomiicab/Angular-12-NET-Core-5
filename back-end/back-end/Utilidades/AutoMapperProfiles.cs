using System;
using System.Collections.Generic;
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

			CreateMap<Cine, CineDTO>()
				.ForMember(x => x.Latitud, dto => dto.MapFrom(campo => campo.Ubicacion.Y))
                .ForMember(x => x.Longitud, dto => dto.MapFrom(campo => campo.Ubicacion.X));

			CreateMap<PeliculaCreacionDTO, Pelicula>()
				.ForMember(x => x.Poster, opciones => opciones.Ignore())
				.ForMember(x => x.PeliculasGeneros, opciones => opciones.MapFrom(MapearPeliculasGeneros))
                .ForMember(x => x.PeliculasCines, opciones => opciones.MapFrom(MapearPeliculasCines))
                .ForMember(x => x.PeliculasActores, opciones => opciones.MapFrom(MapearPeliculasActores));


        }

		private List<PeliculasGeneros> MapearPeliculasGeneros(PeliculaCreacionDTO peliculaCreacionDTO,
			Pelicula pelicula)
		{
			var result = new List<PeliculasGeneros>();

			if(peliculaCreacionDTO.GenerosIds == null)
			{
				return result;
			}

			foreach (var id in peliculaCreacionDTO.GenerosIds)
			{
				result.Add(new PeliculasGeneros()
				{
					GeneroId = id
				});
			}

			return result;
		}

        private List<PeliculasCines> MapearPeliculasCines(PeliculaCreacionDTO peliculaCreacionDTO,
            Pelicula pelicula)
        {
            var result = new List<PeliculasCines>();

            if (peliculaCreacionDTO.CinesIds == null)
            {
                return result;
            }

            foreach (var id in peliculaCreacionDTO.CinesIds)
            {
                result.Add(new PeliculasCines()
                {
                    CineId = id
                });
            }

            return result;
        }

        private List<PeliculasActores> MapearPeliculasActores(PeliculaCreacionDTO peliculaCreacionDTO,
            Pelicula pelicula)
        {
            var result = new List<PeliculasActores>();

            if (peliculaCreacionDTO.Actores == null)
            {
                return result;
            }

            foreach (var actor in peliculaCreacionDTO.Actores)
            {
                result.Add(new PeliculasActores()
                {
                    ActorId = actor.Id,
                    Personaje = actor.Personaje
                });
            }

            return result;
        }
    }
}

