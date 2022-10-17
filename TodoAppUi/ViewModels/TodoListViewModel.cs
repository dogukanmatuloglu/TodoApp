namespace TodoAppUi.ViewModels
{
    public class TodoListViewModel
    {
        public string Task { get; set; }
        public DateTime EndDate { get; set; }= DateTime.Now;
        public int UserId { get; set; } = 1;
        public int PriorityId { get; set; } = 1;
    }
}
