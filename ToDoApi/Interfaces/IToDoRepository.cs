using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface IToDoRepository
    {
        public bool Save();
        public ICollection<ToDo> GetAll();
        public ToDo? GetById(int id);

    }
}
