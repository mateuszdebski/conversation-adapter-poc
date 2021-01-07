namespace ConversationAdapter.Application.Results.Command
{
    public class CreateResult<T> : CommandResult where T : class
    {
        public T Result { get; set; }

        public CreateResult()
        {

        }

        public static CreateResult<T> FromResult(T result)
        {
            return new CreateResult<T>
            {
                Result = result,
                Status = CommandResultStatus.Success
            };
        }
    }
}