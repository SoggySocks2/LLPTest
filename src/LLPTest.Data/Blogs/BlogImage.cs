namespace LLPTest.Data.Blogs
{
    public class BlogImage
    {
        public int Id { get; set; }
        public string Caption { get; set; }

        public BlogImage(string caption)
        {
            Caption = caption;
        }
    }
}
