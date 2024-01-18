using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Model.SeedWork
{
     public class MetaData  // chứa tổng số bản ghi 
    {
        public int CurrentPage { get; set; } //Đây là trang hiện tại trong danh sách kết quả được phân trang (chỉ đọc và chỉ định trang hiện tại ng đag xem)
        public int TotalPages { get; set; } // Đây là tổng số trang trong danh sách kết quả đã được phân trang. (chỉ đọc và chỉ định tổng số trang có sẵn)
        public int PageSize {  get; set; }  // Đây là kích thước của mỗi trang trong danh sách kết quả. (đọc và gghi, cho phép thiết lập kích thước)
        public int TotalCount { get; set; } // Đây là tổng số mục trong danh sách kết quả chưa được phân trang.(đọc và ghi, cho phép thiết lập tổng số danh mục)
        public bool HasPrevious => CurrentPage > 1; // chỉ đọc và chỉ định xem có trang trước đó hay không. (Nếu CurrentPage lớn hơn 1, thuộc tính này sẽ trả về true, ngược lại là false.)
        public bool HasNext => CurrentPage < TotalPages; // chỉ đọc và chỉ định xem có trang tiếp theo hay không.Nếu CurrentPage nhỏ hơn TotalPages, thuộc tính này sẽ trả về true, ngược lại là false.

    }
}
