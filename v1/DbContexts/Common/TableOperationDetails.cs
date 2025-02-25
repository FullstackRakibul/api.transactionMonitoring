namespace v1.DbContexts.Common
{
    public class TableOperationDetails
    {
        public int Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? DeleteBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        public bool IsDeleted { get; set; }

    }
}
