using System.ComponentModel.DataAnnotations;

namespace ConversationAdapter.Controllers.Conversation
{
    public class CreateConversation
    {
        [Required]
        public long? AccountId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}