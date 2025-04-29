using Microsoft.EntityFrameworkCore;
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
        // Marks specific record as completed by making it 100 percent complete
        public bool Complete(int id)
        {
            var toDo = _context.ToDos.Where(b => b.Id == id).FirstOrDefault();
            if (toDo != null)
            {
                toDo.CompletePercent = 100;
                _context.ToDos.Update(toDo);
                return Save();
            }
            return false;
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
            if (toDo != null) { 
                _context.Remove(toDo);
                return Save();
            }
            return false;   
        }

        public ICollection<ToDo> GetAll()
        {
            return _context.ToDos.ToList();
        }

        public ToDo? GetById(int id)
        {
            return _context.ToDos.Where(t => t.Id == id).FirstOrDefault();
        }

        // Gets records where they expire between certain time ranges
        // Variable today specifies if function should look for between now and:
        // today - today expiration date, tomorrow - tomorrow expiration day, week - 7 days of expiration day
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
        // Saves changes in the database
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        // Changes percent of completion by requested amount
        public bool SetPercent(int id, int percent)
        {
            var todo = _context.ToDos.Where(b => b.Id == id).FirstOrDefault();
            if (todo != null)
            {
                todo.CompletePercent = percent;
                _context.Update(todo);
                return Save();
            }
            return false;
        }

        public bool Update(ToDo toDo)
        {
            var x = _context.ToDos.Where(b => b.Id ==  toDo.Id).FirstOrDefault();
            if (x != null)
            {
                x.Title = toDo.Title;
                x.Description = toDo.Description;
                x.Expiration = toDo.Expiration;
                x.CompletePercent = toDo.CompletePercent;
                _context.Update(x);
                return Save();
            }
            return false;
        }
    }
}
