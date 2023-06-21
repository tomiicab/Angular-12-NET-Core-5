﻿using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace back_end.Entidades
{
	public class Cine
	{
		public int Id { get; set; }

		[Required]
		[StringLength(maximumLength: 75)]
		public string Nombre { get; set; }

		public Point Ubicacion { get; set; }
	}
}

