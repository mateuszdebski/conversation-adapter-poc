using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversationAdapter.Domain.Applications
{
    [Table("Application")]
    public class Application
    {
        [Key]
        public string Id { get; set; }
        public long AccountId { get; set; }
        public string Name { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }

        public Application()
        {

        }

        public Application(string id, long accountId, string name, string privateKey, string publicKey)
        {
            Id = id;
            AccountId = accountId;
            Name = name;
            PrivateKey = privateKey;
            PublicKey = publicKey;
        }
    }
}