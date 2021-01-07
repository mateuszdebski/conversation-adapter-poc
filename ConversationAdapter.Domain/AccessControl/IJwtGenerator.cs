namespace ConversationAdapter.Domain.AccessControl
{
    public interface IJwtGenerator
    {
        string Generate(string applicationId, string userId, AccessControlList acl, string key);
    }
}