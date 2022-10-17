using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAppUi.Models.Entities.Concrete;

namespace TodoAppUi.Models.Configuration
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
           builder.Property(x => x.Task)
                                         .HasColumnType("nvarchar(max)").IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.TodoLists).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Priority).WithMany(x => x.TodoLists).HasForeignKey(x => x.PriorityId);
        }
    }
}
