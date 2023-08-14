using System;

namespace VentureCore
{
    [Flags]
    public enum Row
    {
        None = 0 ,
        First = 1,
        Last = 2,
        Leader = 4
    }
}
