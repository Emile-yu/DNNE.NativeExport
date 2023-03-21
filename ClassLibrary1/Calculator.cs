using System;
using System.Runtime.InteropServices;

namespace ClassLibrary1
{
    public class Calculator
    {
#if NETFRAMEWORK
    [DNNE.Export(EntryPoint = "IntIntInt")]
#else
       
     [UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
#endif

        public static Int64 UnmanagedIntIntInt(Int64 a, Int64 b)
        {
            return a + b;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static bool Test()
        {
            return true;
        }
    }
}

#if NETFRAMEWORK
namespace DNNE
{
    internal class ExportAttribute : Attribute
    {
        public ExportAttribute()
        {

        }

        public string EntryPoint { get; set; }
    }
}
#endif
