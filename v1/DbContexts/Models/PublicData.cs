namespace v1.DbContexts.Models
{
    public class PublicData : Common.TableOperationDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
