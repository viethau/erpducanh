namespace DucAnhERP.Services
{
    public class PagingLink
    {
        public string Text { get; set; }

        public int Page { get; set; }

        public bool Enable { get; set; }

        public bool Active { get; set; }

        public PagingLink(int page, bool enable, string text)
        {
            Page = page;
            Enable = enable;
            Text = text;
        }
    }
}
