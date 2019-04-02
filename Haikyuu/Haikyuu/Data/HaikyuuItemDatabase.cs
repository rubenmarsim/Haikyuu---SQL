using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

using Haikyuu.Models;

namespace Haikyuu
{
    public class HaikyuuItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public HaikyuuItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Comentario>().Wait();
            database.CreateTableAsync<Personaje>().Wait();
        }

        public Task<List<Comentario>> GetItemsAsync()
        {
            Task<List<Comentario>> firstList;
            firstList = database.Table<Comentario>().ToListAsync();

            return firstList;
        }

        public Task<List<Personaje>> GetItemsAsyncPersonaje()
        {
            Task<List<Personaje>> firstList;
            firstList = database.Table<Personaje>().ToListAsync();

            return firstList;
        }

        public Task<Comentario> GetItemAsync(int id)
        {
            return database.Table<Comentario>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Comentario item)
        {
            if (item.id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> SaveItemAsyncPersonaje(Personaje item)
        {
            if (item.id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Comentario item)
        {
            return database.DeleteAsync(item);
        }
    }
}

//readonly SQLiteAsyncConnection database;

//public HaikyuuItemDatabase(string dbPath)
//{
//    database = new SQLiteAsyncConnection(dbPath);
//    database.CreateTableAsync<Comentario>().Wait();
//}

//public Task<List<Comentario>> GetItemsAsync()
//{
//    return database.Table<Comentario>().ToListAsync();
//}

//public Task<Comentario> GetItemAsync(int id)
//{
//    return database.Table<Comentario>().Where(i => i.id == id).FirstOrDefaultAsync();
//}

//public Task<int> SaveItemAsync(Comentario item)
//{
//    if (item.id != 0)
//    {
//        return database.UpdateAsync(item);
//    }
//    else
//    {
//        return database.InsertAsync(item);
//    }
//}

//public Task<int> DeleteItemAsync(Comentario item)
//{
//    return database.DeleteAsync(item);
//}