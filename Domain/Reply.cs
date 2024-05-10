using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Reply: BaseEntity
    {
        [ForeignKey("PostId")]
        public Post? Post { get; set; }
        public int? PostId { get; set; }

        [ForeignKey("ReplyPostId")]
        public Post? ReplyPost { get; set; }
        public int? ReplyPostId { get; set; }
    }
}
