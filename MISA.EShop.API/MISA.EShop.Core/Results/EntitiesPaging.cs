using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Results
{
    /// <summary>
    /// đối tượng trả về thông tin phân trang
    /// </summary>
    public class EntittiesPaging
    {
        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// Tổng số tất cả các bản ghi 
        /// </summary>
        public int TotalRecord { get; set; }

 
    }
}
