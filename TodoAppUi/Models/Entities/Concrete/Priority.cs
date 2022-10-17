using TodoAppUi.Models.Entities.Abstract;

namespace TodoAppUi.Models.Entities.Concrete
{
    public class Priority:EntityBase
    {
        public string Name { get; set; }

        public ICollection<TodoList> TodoLists { get; set; }

    }
}
