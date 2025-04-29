using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface IToDoRepository
    {
        public bool Save();
        public bool Create(ToDo toDo);
        public bool Update(ToDo toDo);
        public bool Delete(int id);
        public bool Complete(int id);
        public bool SetPercent(int id, int percent);
        public ICollection<ToDo> GetAll();
        public ToDo? GetById(int id);
        public ICollection<ToDo>? GetIncoming(string when);

    }
}
