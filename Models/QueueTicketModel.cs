using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace LoginModule.Models
{
    [Table("queue_tickets")]
    public class QueueTicketModel : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("queue_type_id")]
        public int QueueTypeId { get; set; }

        [Column("queue_number")]
        public string QueueNumber { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}