using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace LoginModule.Models
{
    [Table("users")]
    public class UserModel : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("fullname")]
        public string Fullname { get; set; }

        [Column("role")]
        public string Role { get; set; }
    }
}