using TodoAppUi.Models.Entities.Abstract;

namespace TodoAppUi.Models.Entities.Concrete
{
    public class TodoList:EntityBase
    {
        public string Task { get; set; }
        public DateTime EndDate { get; set; }
        public Priority Priority { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int PriorityId { get; set; }
    }
}
