using Restapi_WorkingWithFiles.Hypermedia;
using Restapi_WorkingWithFiles.Hypermedia.Abstract;

namespace Restapi_WorkingWithFiles.Data.VO
{
    public class BooksVO : ISupportHyperMedia
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Author { get; set; }
       public string Publisher { get; set; }
       public string Genre { get; set; }
       public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
