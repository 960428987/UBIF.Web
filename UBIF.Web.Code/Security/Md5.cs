using System;
using System.Security.Cryptography;
using System.Text;

namespace UBIF.Web.Code
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public class Md5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string md5(string str, int code)
        {
            string strEncrypt = string.Empty;
            if (code == 16)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                    //转换成字符串，并取9到25位
                    string sBuilder = BitConverter.ToString(data, 4, 8);
                    //BitConverter转换出来的字符串会在每个字符中间产生一个分隔符，需要去除掉
                    sBuilder = sBuilder.Replace("-", "");
                    strEncrypt =  sBuilder.ToString().ToLower();
                }
            }

            if (code == 32)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    string hash = sBuilder.ToString();
                    strEncrypt = hash.ToLower();
                }
            }

            return strEncrypt;
        }
    }
}
