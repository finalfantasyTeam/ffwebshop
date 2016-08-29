using System;

namespace WebShop
{
    public interface IAuditable
    {
        DateTime? CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
