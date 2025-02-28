namespace v1.DTOs
{
    public class CommonCollectionResponseDto
    {
        public Guid Id { get; set; }
        public string MerchantName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime CollectionDate { get; set; }
        public decimal CollectedAmount { get; set; }
        public string BankName { get; set; }
        public string? CheckNumber { get; set; }
        public string? ClearingBranch { get; set; }
        public DateTime? CheckSubmissionDate { get; set; }
        public string CollectionOfficer { get; set; }
        public string Region { get; set; }
        public string? Memo { get; set; }
        public byte[]? FileAttachment { get; set; }
        public List<BillDetailsDto> BillDetails { get; set; }


        // TableOperationDetails Properties
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
