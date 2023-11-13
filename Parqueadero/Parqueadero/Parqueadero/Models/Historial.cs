using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parqueadero.Models
{
	public class Historial
	{
		[PrimaryKey]
		public int Id { get; set; }
		public string Id_puesto { get; set; }
		public string Placa_vehiculo { get; set; }
		public string Id_resrvas { get; set; }
	}
}
