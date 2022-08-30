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
        readonly SQLiteConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteConnection(path);

            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE produto SET Descricao=?, Quantidade=?, Preco=? WHERE id= ?";
            return _conn.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.PrecoPago, p.id);

        }

        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(int => i.Id == id);
        }

        public Task<List<Produto>> Search(string q)
        {
           string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%" + q + "%' ";

           return _conn.QueryAsync<Produto>(sql);
        }
    }
}
