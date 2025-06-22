using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSearchFunction
{
    public class Search
    {
        public static Product LinearSearch(Product[] products, int targetId)
        {
            foreach (var product in products)
            {
                if(product.PID == targetId)
                    return product;
                
            }
            return null;
        }


        public static Product BinarySearch(Product[] products, int targetId)
        {
            int l = 0, r = products.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (products[mid].PID == targetId)
                    return products[mid];
                else if (products[mid].PID < targetId)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return null;
        }
    }
}
