using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace Test
{
    [XmlRoot("Rules")]
    public class UrlMatchRuleInfoListEntity
    {
        private List<UrlMatchRuleInfo> _urlMatchRuleInfoList = new List<UrlMatchRuleInfo>();

        [XmlElement(ElementName = "Rule")]
        public List<UrlMatchRuleInfo> UrlMatchRuleInfoList
        {
            get { return _urlMatchRuleInfoList; }
            set { _urlMatchRuleInfoList = value; }
        }
    }

    [XmlType(TypeName = "Rule")]
    public class UrlMatchRuleInfo
    {
        private string _funcCode = string.Empty;
        private string _funcName = string.Empty;
        private string _matchRule = string.Empty;

        /// <summary>
        /// 功能模块代码
        /// </summary>
        [XmlElement(ElementName = "FuncCode")]
        public string FuncCode
        {
            get { return _funcCode; }
            set { _funcCode = value; }
        }

        /// <summary>
        /// 功能模块名称
        /// </summary>
        [XmlElement(ElementName = "FuncName")]
        public string FuncName
        {
            get { return _funcName; }
            set { _funcName = value; }
        }

        /// <summary>
        /// 匹配规则正则表达式
        /// </summary>
        [XmlElement(ElementName = "MatchRule")]
        public string MatchRule
        {
            get { return _matchRule; }
            set { _matchRule = value; }
        }
    }

    

    public struct PointNew
    {
        public string x1;
        public string y1;
    }

    public struct Peoson
    {
        public int age;
        public string name;
    }
}
