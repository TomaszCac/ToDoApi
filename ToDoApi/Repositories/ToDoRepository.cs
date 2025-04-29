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

        public bool Complete(int id)
        {
            var toDo = _context.ToDos.Where(b => b.Id == id).FirstOrDefault();
            if (toDo != null)
            {
                toDo.CompletePercent = 100;
                _context.ToDos.Update(toDo);
            }
            return Save();
        }

        public bool Create(ToDo toDo)
        {
            toDo.Id = 0;
            _context.Add(toDo);
            return Save();
        }

        public bool Delete(int id)
        {
            var toDo = _context.ToDos.Where(b => b.Id == id).FirstOrDefault();
            if (toDo != null) { _context.Remove(toDo); }
            return Save();
        }

        public ICollection<ToDo> GetAll()
        {
            return _context.ToDos.ToList();
        }

        public ToDo? GetById(int id)
        {
            return _context.ToDos.Where(t => t.Id == id).FirstOrDefault();
        }

        public ICollection<ToDo>? GetIncoming(string when)
        {
            var time = DateTime.Now;
            switch (when)
            {
                case "today":
                    return _context.ToDos.Where(t => time.Date.AddDays(1) > t.Expiration).ToList();
                case "tomorrow":
                    return _context.ToDos.Where(t => time.Date.AddDays(2) > t.Expiration).ToList();
                case "week":
                    return _context.ToDos.Where(t => time.Date.AddDays(7) > t.Expiration).ToList();
                default:
                    return null;
            }
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SetPercent(int id, int percent)
        {
            var todo = _context.ToDos.Where(b => b.Id == id).FirstOrDefault();
            todo.CompletePercent = percent;
            _context.Update(todo);
            return Save();
        }

        public bool Update(ToDo toDo)
        {
            _context.Update(toDo);
            return Save();
        }
    }
}
