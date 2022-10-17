namespace TodoAppUi.Models.Entities.Abstract
{
    public  abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual  int  CreatedBy { get; set; }
        public virtual  int ModifiedBy { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }


    }
}
