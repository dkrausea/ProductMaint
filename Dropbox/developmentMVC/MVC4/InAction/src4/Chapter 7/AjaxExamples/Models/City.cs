namespace AjaxExamples.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public string DisplayName
        {
            get { return Name + ", " + State; }
        }
    }
}