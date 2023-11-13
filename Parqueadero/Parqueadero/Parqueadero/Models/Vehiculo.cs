using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parqueadero.Models
{
    public class Vehiculo
    {
        [PrimaryKey]
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
		public Int64 id_usuario { get; set; }



	}
}