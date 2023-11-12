using Parqueadero.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parqueadero.Data
{
    public class VehiculosDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public VehiculosDatabase(string rutaBD)
        {
            database = new SQLiteAsyncConnection(rutaBD);
            database.CreateTableAsync<Vehiculo>().Wait();
        }

        public Task<int> Agregar(Vehiculo vehiculo)
        {
            return database.InsertAsync(vehiculo);
        }

        public Task<int> Actualizar(Vehiculo vehiculo)
        {
            return database.UpdateAsync(vehiculo);
        }

        public Task<int> Eliminar(Vehiculo vehiculo)
        {
            return database.DeleteAsync(vehiculo);
        }

        public Task<Vehiculo> BuscarUno(Vehiculo vehiculo)
        {
            return database.Table<Vehiculo>()
                            .Where(x => x.Id == vehiculo.Id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Vehiculo>> BuscarTodo(Vehiculo vehiculo)
        {
            return database.Table<Vehiculo>().ToListAsync();
        }
    }
}
