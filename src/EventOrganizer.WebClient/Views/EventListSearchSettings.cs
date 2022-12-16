namespace EventOrganizer.WebClient.Views
{
    public class EventListSearchSettings
    {
        public string Filter { get; set; }

        public IList<string> Tags { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
