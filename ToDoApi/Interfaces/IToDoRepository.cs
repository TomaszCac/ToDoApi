using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface IToDoRepository
    {
        public bool Save();
        public bool Create(ToDo toDo);
        public bool Update(ToDo toDo);
        public ICollection<ToDo> GetAll();
        public ToDo? GetById(int id);
        public ICollection<ToDo>? GetIncoming(string when);

    }
}
