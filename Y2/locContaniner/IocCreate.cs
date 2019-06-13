using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using IDAO;
using IBLL;
using BAL;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;

namespace locContaniner
{
    //ioc容器
    public class IocCreate
    {
        public static T CreateProductTypeDao<T>(string cname,string rname)
        {
            UnityContainer ioc = CreatIoc(cname);
            T ptd = ioc.Resolve<T>(rname);
            return ptd;
        }
        private static UnityContainer CreatIoc(string name)
        {
            UnityContainer ioc = new UnityContainer();
            ExeConfigurationFileMap exf = new ExeConfigurationFileMap();
            exf.ExeConfigFilename = @"../UI/Unity.config---";
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exf, ConfigurationUserLevel.None);
            UnityConfigurationSection cfs = (UnityConfigurationSection)cf.GetSection("unity");
            ioc.LoadConfiguration(cfs, name);
            return ioc;
        }
        public static T CreateProductTypeBLL<T>(string cname,string rname)
        {
            UnityContainer ioc = CreatIoc(cname);
            T ptb = ioc.Resolve<T>(rname);
            return ptb;
        }
    }
}
