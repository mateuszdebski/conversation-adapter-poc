using System.Collections.Generic;
using System.Collections.Immutable;

namespace ConversationAdapter.Domain.AccessControl
{
    public class AccessControlList
    {
        public IImmutableDictionary<string, object> Paths { get; }

        private AccessControlList(IDictionary<string, object> paths)
        {
            Paths = paths.ToImmutableDictionary();
        }

        public static AccessControlList CreateUser()
        {
            var dictionary = new Dictionary<string, object>
            {
                {"/*/conversations/**", new object() }
            };

            return new AccessControlList(dictionary);
        }
    }
}