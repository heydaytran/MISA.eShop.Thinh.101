using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Enum
{
    /// <summary>
    /// Chứa mã các mã code trả về khi có lỗi xảy ra
    /// CreatedBy: nctu 16.04.2021
    /// </summary>
    public enum ErrorCode
    {
        NONE = 0,
        NOTFOUND = 404,
        BADREQUEST = 400,
        NOCONTENT = 204,
        EXCEPTION = 500
    }
}
