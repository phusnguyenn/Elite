using Elite.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace Elite.Common
{
    public class PagingResult
    {
        private const int ITEM_PER_PAGE = 8;
        public  Pager<Product> GetPaging(IEnumerable<Product> input, int? page)
        {
            int pageNo = 0;
            int totalProduct = input.Count();
            pageNo = page == null ? 1 : int.Parse(page.ToString());
            int inEachPageProductEndAt = pageNo * ITEM_PER_PAGE;
            int inEachPageProductStartsFrom = inEachPageProductEndAt - ITEM_PER_PAGE;
            input = input.Skip(inEachPageProductStartsFrom).Take(ITEM_PER_PAGE).ToList();
            Pager<Product> pager = new Pager<Product>(input.AsQueryable(), pageNo, ITEM_PER_PAGE, totalProduct);
            return pager;
        }
    }
}