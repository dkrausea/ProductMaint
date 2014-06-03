namespace CodeCampServerLite.UI.Domain
{
    public class Speaker
    {
        public Speaker(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Bio { get; set; }
    }
}