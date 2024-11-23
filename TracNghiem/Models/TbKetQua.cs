using System;
using System.Collections.Generic;

namespace TracNghiem.Models;

public partial class TbKetQua
{
    public int Id { get; set; }

    public string? MaSinhVien { get; set; }

    public string? DapAn { get; set; }

    public int? MaDeThiCauHoi { get; set; }

    public virtual TbDeThiCauHoi? MaDeThiCauHoiNavigation { get; set; }

    public virtual TbThanhVien? MaSinhVienNavigation { get; set; }
}
