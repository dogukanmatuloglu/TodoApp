using TodoAppUi.Models.Entities.Abstract;

namespace TodoAppUi.Models.Entities.Concrete
{
    public class User:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<TodoList> TodoLists { get; set; }

    }

    
    
}
