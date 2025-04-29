using ToDoApi.Data;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly MariaDatabaseContext _context;

        public ToDoRepository(MariaDatabaseContext context)
        {
            _context = context;
        }

        public ICollection<ToDo> GetAll()
        {
            return _context.ToDos.ToList();
        }

        public ToDo? GetById(int id)
        {
            return _context.ToDos.Where(t => t.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
