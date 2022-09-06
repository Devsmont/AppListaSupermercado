using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using AppListaSupermercado.Model;

namespace AppListaSupermercado.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            Console.WriteLine("_______________________________________________________________________________");
            Console.WriteLine("CHEGOU no construtor");

            _conn = new SQLiteAsyncConnection(path);

            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE produto SET NomeProduto=?, Quantidade=?, PrecoPago=?, PrecoEstimado=? WHERE id= ?";
            return _conn.QueryAsync<Produto>(sql, p.NomeProduto, p.Quantidade, p.PrecoPago, p.Id, p.PrecoEstimado);

        }
        public Task<List<Produto>> GetAll()
        {
            Task<List<Produto>> lista = null;

            


            try
            {
                lista = _conn.Table<Produto>().ToListAsync();

            } catch (Exception ex)
            {
                Console.WriteLine("_______________________________________________________________________________");
                Console.WriteLine(ex.Message);
            }

            return lista;
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE NomeProduto LIKE '%" + q + "%' ";

            return _conn.QueryAsync<Produto>(sql);
        }
    }
}