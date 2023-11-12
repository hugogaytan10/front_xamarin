using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parqueadero.Models
{
    public class Vehiculo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
       

    }
}