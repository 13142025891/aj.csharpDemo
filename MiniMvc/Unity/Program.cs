using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
namespace Unity
{
    public interface IA { }
    public interface IB { }
    public interface IC { }
    public interface ID { }

    public class A : IA
    {
        public IB b { get; set; }

        //属性注入
        [Dependency]
        public IC c { get; set; }
        public ID d { get; set; }

        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="b"></param>
        public A(IB b)
        {
            this.b = b;
        }

        //方法注入
        [InjectionMethod]
        public void Initialize(ID d)
        {
            this.d = d;
        }

    }
    public class B : IB { }
    public class C : IC { }
    public class D : ID { }
    class Program
    {



        static void Main(string[] args)
        {
            //新建容器
            IUnityContainer container = new UnityContainer();
            //加载配置文件
            UnityConfigurationSection configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
            configuration.Configure(container, "defaultContarner");

            A a = container.Resolve<IA>() as A;
            if (null != a)
            {
                Console.WriteLine("a.b==null? {0}", a.b == null ? "yes" : "no");
                Console.WriteLine("a.c==null? {0}", a.c == null ? "yes" : "no");
                Console.WriteLine("a.d==null? {0}", a.d == null ? "yes" : "no");
            }
            Console.Read();
        }
    }
}
