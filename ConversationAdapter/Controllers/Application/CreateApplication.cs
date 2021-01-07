using System.ComponentModel.DataAnnotations;

namespace ConversationAdapter.Controllers.Application
{
    public class CreateApplication
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public long? AccountId { get; set; }
    }
}