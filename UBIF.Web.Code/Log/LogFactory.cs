using log4net;
using log4net.Repository;
using System;
using System.IO;
using System.Web;
using UBIF.Web.Extend;
namespace UBIF.Web.Code
{
    public class LogFactory
    {
        public static ILoggerRepository repository { get; set; }
        static LogFactory()
        {
            repository = LogManager.CreateRepository("NETCoreRepository");
            string rootdir = AppContext.BaseDirectory;
            DirectoryInfo Dir = Directory.GetParent(rootdir);
            string root = Dir.Parent.Parent.FullName;
            log4net.Config.XmlConfigurator.Configure(repository, new FileInfo(root.Substring(0,root.Length - 4)+ "\\Configs\\log4net.config"));
        }
    }
}
