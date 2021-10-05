using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    
    public class ProductoRepository
    {
        private string connectionString;
        public ProductoRepository()
        {
            connectionString = @"Data Source=(Localdb)\SqlServer;Initial Catalog=Prueba;Integrated Security=True;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Producto prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"INSERT INTO Producto (Nombre,Precio,Stock,FechaRegistro) VALUES(@Nombre,@Precio,@Stock,@FechaRegistro)";
                dbConnection.Open();
                dbConnection.Execute(query, prod);
            }
        }

        public IEnumerable<Producto> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"SELECT * FROM Producto";
                dbConnection.Open();
                return dbConnection.Query<Producto>(query);
            }
        }

        public Producto GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"SELECT * FROM Producto where Id=@id";
                dbConnection.Open();
                return dbConnection.Query<Producto>(query, new { Id=id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"DELETE FROM Producto where Id=@id";
                dbConnection.Open();
                dbConnection.Execute(query, new { Id=id });
            }
        }

        public void Update(Producto prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"UPDATE Producto SET Nombre=@Nombre, Precio=@Precio, Stock=@Stock, FechaRegistro=@FechaRegistro where Id=@id";
                dbConnection.Open();
                dbConnection.Query(query, prod);
            }
        }

    }
}
