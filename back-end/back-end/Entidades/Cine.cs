using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace back_end.Entidades
{
	public class Cine
	{
		public int Id { get; set; }
        [Required]
		[StringLength(maximumLength: 75)]
		public string Nombre { get; set; }

        [Column(TypeName = "geometry")]
        public Point Ubicacion { get; set; }
	}
}

