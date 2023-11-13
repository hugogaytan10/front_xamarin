using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Parqueadero.Models
{
	public class Puesto
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Int64 id { get; set; }
		public int? numero { get; set; }
		public string estado { get; set; }
		public Int64 id_zona_parqueo { get; set; }
	}

	public enum EstadoPuesto
	{
		libre,
		ocupado,
		inactivo
	}
}

