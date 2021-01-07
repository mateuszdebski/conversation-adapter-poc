namespace ConversationAdapter.Domain.Applications
{
    public class CreatedApplication
    {
        public string Id { get; }
        public string Name { get; }
        public string PrivateKey { get; }
        public string PublicKey { get; }

        public CreatedApplication(string id, string name, string privateKey, string publicKey)
        {
            Id = id;
            Name = name;
            PrivateKey = privateKey;
            PublicKey = publicKey;
        }
    }
}