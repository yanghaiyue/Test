using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine($"Version: {Environment.Version}");
            //UrlMatchRuleInfoListEntity urlMatchRuleInfoList = null;

            //string fileName = string.Format(@"{0}\RuleXml\ruleInfo.xml", Environment.CurrentDirectory);
            //urlMatchRuleInfoList = XmlDataLoad(typeof(UrlMatchRuleInfoListEntity), fileName) as UrlMatchRuleInfoListEntity;
            //string url = "http://www.baicyun.com.cn:9700/baicmotorzt/mobilemaininfo.ashx/areadayspfcount?userCode=bmservice&clientType=IOS&ver=0&uid=a979272fdf96436f9c3a025591b954c6&dataType=yg&startDate=2018-01-26&endDate=";
            //Console.WriteLine(url.Length);


            //Regex regex;
            //foreach (UrlMatchRuleInfo item in urlMatchRuleInfoList.UrlMatchRuleInfoList)
            //{
            //    regex = new Regex(item.MatchRule);
            //    MatchCollection matches = regex.Matches(url);
            //    bool isMatch = regex.IsMatch(url);
            //}
            //UrlMatchRuleInfoListEntity.Point point = new UrlMatchRuleInfoListEntity.Point();
            //point.x = 123;
            //point.y = 456;
            //Peoson P = new Peoson();
            //P.name = "yhy";
            //int size = Marshal.SizeOf(point);
            //IntPtr pnt = Marshal.AllocHGlobal(size);
            //Marshal.StructureToPtr(point, pnt, false);
            //byte[] byteBuffer = new byte[size];
            //Marshal.Copy(byteBuffer, 0, pnt, size);
            //Marshal.Copy(pnt, byteBuffer, 0, size);
            //string result = Encoding.UTF8.GetString(byteBuffer);
            //object t = GetInstance<Point>();
            //object obj = Activator.CreateInstanceFrom(AppDomain.CurrentDomain, string.Empty, "Point");
            //Type type = typeof(UrlMatchRuleInfoListEntity.Point);
            //object instance = GetInstance("Test.UrlMatchRuleInfoListEntity+Point", pnt);
            //Dictionary<string, object> result = GetBaseData(instance);

            Console.ReadKey();

        }

        public static object GetInstance(string typeName, IntPtr ptr)
        {
            Type type = Type.GetType(typeName);
            //object instance = Activator.CreateInstance(type);
            object instance = Marshal.PtrToStructure(ptr, type);
            //return instance;
            return default(object);
        }

        public static Dictionary<string, object> GetBaseData(object obj)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Type type = obj.GetType();
            FieldInfo[] array = type.GetFields();

            foreach (FieldInfo item in array)
            {
                result.Add(item.Name, item.GetValue(obj));
            }

            return result;
        }

        /// <summary>
        /// 加载xml数据
        /// </summary>
        /// <param name="type">泛型类型</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static object XmlDataLoad(Type type, string fileName)
        {
            object result = null;

            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
                    {
                        XmlSerializer xs = new XmlSerializer(type);
                        result = xs.Deserialize(reader);
                    }
                }
            }

            catch (Exception ex)
            {
            }

            return result;
        }
    }
}
