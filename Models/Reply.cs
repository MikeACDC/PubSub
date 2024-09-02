namespace PubSub.Models
{
    public  class Reply : Message
    {
        public Guid ReplyID { get; set; }

        public Guid RequestID { get; set; }
    }
}
