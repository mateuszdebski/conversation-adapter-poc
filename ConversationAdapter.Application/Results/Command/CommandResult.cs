using System.Collections.Generic;

namespace ConversationAdapter.Application.Results.Command
{
    public class CommandResult
    {
        public CommandResultStatus Status { get; set; }
        public IReadOnlyCollection<string> Messages { get; }
        public bool IsSuccess => Status == CommandResultStatus.Success;

        public static CommandResult FromStatus(CommandResultStatus status)
        {
            return new CommandResult
            {
                Status = status
            };
        }
    }
}