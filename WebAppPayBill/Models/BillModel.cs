namespace WebAppPayBill.Models
{
    public class BillModel
    {
        public int bilId { get; set; }
        public string bilName { get; set; }
        public string bilDescription { get; set; }
        public int bilNumber { get; set; }
        public int bilContract { get; set; }
        public float bilValuePay { get; set; }
        public int State { get; set; }
        public string createUser { get; set; }
        public DateTime createDate { get; set; }
        public string updateUser { get; set; }
        public DateTime updateDate { get; set; }

    }
}
