namespace ConversationAdapter.Application.AccessControl
{
    public class JwtTokenDto
    {
        public string Token { get; }

        public JwtTokenDto(string token)
        {
            Token = token;
        }
    }
}