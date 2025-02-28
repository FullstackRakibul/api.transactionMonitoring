namespace v1.DTOs
{
    public class CreateCommonCollectionDto
    {
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
    }
}
