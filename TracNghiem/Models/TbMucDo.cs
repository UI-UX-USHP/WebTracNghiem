using System;
using System.Collections.Generic;

namespace TracNghiem.Models;

public partial class TbMucDo
{
    public int Id { get; set; }

    public string? TenMucDo { get; set; }

    public virtual ICollection<TbCauHoi> TbCauHois { get; set; } = new List<TbCauHoi>();
}
