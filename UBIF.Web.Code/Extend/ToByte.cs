#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：UBIF.Web.Code.Extend
* 项目描述 ：
* 类 名 称 ：Byte
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：UBIF.Web.Code.Extend
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/5/17 20:47:47
* 更新时间 ：2019/5/17 20:47:47
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace UBIF.Web.Code
{
   public static class ToByte
    {
		public static string ToString(this byte[] byteArray)
        {
            return byteArr.Length ==0 ? "" : System.Text.Encoding.Default.GetString(byteArray);
        }
        public static byte[] ToByteArr(this string str)
        {
            return str.Length == 0 ? new byte { } : System.Text.Encoding.Default.GetBytes(str);
        }
    }
}
