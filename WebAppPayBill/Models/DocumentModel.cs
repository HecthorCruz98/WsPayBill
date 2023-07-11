namespace WebAppPayBill.Models
{
    public class DocumentModel
    {
        public int docId { get; set; }
        public int usrId { get; set; }
        public int bilId { get; set; }
        public string docUrl { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }
        public DateTime modifyDate { get; set; }
        public string modifyUser { get; set; }
    }
}
