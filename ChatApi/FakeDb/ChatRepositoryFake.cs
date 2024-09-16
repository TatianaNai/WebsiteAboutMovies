using ChatApi.FakeDb.Models;

namespace ChatApi.FakeDb
{
    public class ChatRepositoryFake
    {
        public static List<Message> Messages { get; } = new()
        {
            new Message { AuthorId = 1, AuthorName = "admin", Text = "Welcome to the chat" }
        };

        public List<Message> GetLast5Messages()
            => Messages.TakeLast(5).ToList();

        public void AddMessage(string userName, string text)
            => Messages.Add(new Message
            {
                AuthorName = userName,
                Text = text
            });

        public int Count()
            => Messages.Count();
    }
}
