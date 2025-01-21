using Microsoft.AspNetCore.Identity;

namespace QDevFullstack.Infra.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public Post Post { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
