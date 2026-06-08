using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace LoginModule.Models
{
    [Table("queue_types")]
    public class QueueTypeModel : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_active")]
        //public bool Status { get; set; }
        public bool IsActive { get; set; }
    }
}