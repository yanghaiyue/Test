using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
            string s = "r";
            // 将s转换为UTF8编码的字节数组
            byte[] b = Encoding.UTF8.GetBytes(s);
            MD5 md5 = MD5.Create();
            byte[] md5Encrypt = md5.ComputeHash(b);

            // 用十六进制格式输出这个字节数组
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write("{0:x2} ", b[i]);
            }
            Console.WriteLine();
            Console.ReadKey();

        }

        /// <summary>
        /// 对象转xml
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToXml(Type type, object obj)
        {
            string result = string.Empty;

            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(type);
                try
                {
                    xml.Serialize(stream, obj);
                    //Encoding.UTF8.GetString(stream.ToArray());
                    stream.Position = 0;
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    //LogHelper log = new LogHelper(logTye: LogHelper.LogType.Error.ToString());
                    //log.AddErrorLog(string.Format("{0}.{1}", typeof(ToolHelper).FullName, MethodBase.GetCurrentMethod().Name), ex);
                }
            }

            return result;
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
