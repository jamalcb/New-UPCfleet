namespace UPCFleet.Models
{
    public class TransactionViewModel
    {
        public Transaction Transactions { get; set; }
        public Barge Barges { get; set; }
        public List<Transfer> transfers { get; set; }

    }
}
