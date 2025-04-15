namespace DockerTest
{
    internal class UserAccount
    {
        public string Name { get; }
        public int Age { get; }
        public long Balance { get; }
        public bool Suspended { get; }

        public UserAccount(string name, int age, long balance, bool suspended)
        {
            Name = name;
            Age = age;
            Balance = balance;
            Suspended = suspended;
        }
    }

    [Author("Manuel")]
    class Program
    {
        static List<UserAccount> users = new List<UserAccount> {
             new UserAccount("Andrew", 19, 350, false),
             new UserAccount("Graham", 36, -15, true),
             new UserAccount("Fred", 18, 10, false),
             new UserAccount("Stuart", 23, 1000, false),
             new UserAccount("Martyn", 26, 350, true),
             };

        public static void Main(string[] arg)
        {
            List<UserAccount> availableUsersOfAge = users.Where((UserAccount user) => user.Age > 18 && !user.Suspended && user.Balance > 0).ToList();

            foreach (var user in availableUsersOfAge)
            {
                Console.WriteLine($"{user.Name} {user.Age} {user.Balance} {user.Suspended}");

                var authorAttribute = (AuthorAttribute?)Attribute.GetCustomAttribute(typeof(Program), typeof(AuthorAttribute));
                if (authorAttribute != null)
                {
                    Console.WriteLine(authorAttribute.Name);
                }
            }
        }

        [AttributeUsage(AttributeTargets.Class)]
        public class AuthorAttribute : Attribute
        {
            public string Name;

            public AuthorAttribute(string name)
            {
                Name = name;
            }
        }
    }
}