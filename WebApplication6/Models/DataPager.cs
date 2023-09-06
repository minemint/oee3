namespace WebApplication6.Models
{
    public class DataPager
    {
        public DataPager()
        {

        }

        public DataPager(int totalrows, int page, int pagesize = 10)
        {
            int currentpage = page;
            int totalpages = (int)Math.Ceiling((decimal)totalrows / pagesize);

            int startpage = currentpage - 5;
            int endpage = currentpage + 4;

            if (startpage <= 0)
            {
                endpage = endpage - (startpage - 1);
                startpage = 1;
            }

            if (endpage > totalpages)
            {
                endpage = totalpages;
            }

            StartPage = startpage;
            EndPage = endpage;
            TotalPages = totalpages;

            CurrentPage = currentpage;
            PageSize = pagesize;
            TotalRows = totalrows;
        }

        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
    }
}
