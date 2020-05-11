using System;
using System.Collections.Generic;
using System.Text;

namespace WebSchedule.BusinessLayer.Helpers.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string ToConcatString(this byte[] arr)
        {
            return Encoding.UTF8.GetString(arr);
        }
    }
}
