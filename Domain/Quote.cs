using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Quote: BaseEntity
    {
        [ForeignKey("PostId")]
        public Post? Post { get; set; }
        public Guid PostId { get; set; }
        
        [ForeignKey("QuotePostId")]
        public Post? QuotePost { get; set; }
        public Guid QuotePostId { get; set; }
    }
}
