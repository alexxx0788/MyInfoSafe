using System.Collections.Generic;
using IStor.DAL.Shared.Helper;
using IStorage.DAL.Model;
using IStorage.DAL.Repository.Db;

namespace IStorage.DAL.Repository
{
    public class NotesRepository : SqlRepository<Notes>
    {
        public NotesRepository(string connectionString) : base(connectionString) { }
    }
}
