namespace WebAppPayBill.Models
{
    public class EnterpriseModel
    {
        public int entId { get; set; }
        public string entName { get; set; }
        public int etyId { get; set; }
        public int State { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }
        public DateTime modifyDate { get; set; }
        public string modifyUser { get; set; }
    }
}
