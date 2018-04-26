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

    public class PersonKQInfoDataEntity
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement]
        public string ErrorMessage { get; set; }

        //[XmlElement]
        public PersonKQInfoListEntity Data { get; set; }
    }

    public class PersonKQInfoListEntity
    {
        private List<PersonKQInfo> _eSBEnvelop = new List<PersonKQInfo>();

        [XmlElement]
        public List<PersonKQInfo> ESBEnvelop
        {
            get { return _eSBEnvelop; }
            set { _eSBEnvelop = value; }
        }       
    }

    [XmlType("ESBEnvelop")]
    public class PersonKQInfo
    {
        private ESBHead _head = new ESBHead();
        private ESBBody _body = new ESBBody();

        [XmlElement(ElementName = "ESBHead")]
        public ESBHead Head
        {
            get { return _head; }
            set { _head = value; }
        }
        [XmlElement(ElementName = "ESBBody")]
        public ESBBody Body
        {
            get { return _body; }
            set { _body = value; }
        }
    }

    public class ESBHead
    {
        private string _messageType = "4";

        public string MessageType
        {
            get { return _messageType; }
            set { _messageType = value; }
        }
        public string SystemType { get; set; }
        public string RequesterId { get; set; }
        public string ResponderId { get; set; }
        public string ESBInTime { get; set; }
        public string ESBOutTime { get; set; }
        public string Version { get; set; }
        public string Reserved { get; set; }
    }

    public class ESBBody
    {
        private AppRequest _request = new AppRequest();

        [XmlElement(ElementName = "AppRequest")]
        public AppRequest Request
        {
            get { return _request; }
            set { _request = value; }
        }
    }

    public class AppRequest
    {
        private AppReqHead _responseHead = new AppReqHead();
        private AppReqBody _responseBody = new AppReqBody();

        [XmlElement(ElementName = "AppReqHead")]
        public AppReqHead ResponseHead
        {
            get { return _responseHead; }
            set { _responseHead = value; }
        }

        [XmlElement(ElementName = "AppReqBody")]
        public AppReqBody ResponseBody
        {
            get { return _responseBody; }
            set { _responseBody = value; }
        }
    }

    public class AppReqHead
    {
        private string _tradeCode = "DPSCRM02";

        public string TradeCode
        {
            get { return _tradeCode; }
            set { _tradeCode = value; }
        }
        public string ReqSerialNo { get; set; }
        public string TradeTime { get; set; }
        public string TradeDescription { get; set; }
        public string TradeLogLevel { get; set; }
    }

    public class AppReqBody
    {
        private TableData _table = new TableData();

        public TableData Table
        {
            get { return _table; }
            set { _table = value; }
        }
    }

    public class TableData
    {
        private string _id = "DPSCRM02";
        private string _name = "网点员工";
        private DataRows _rows = new DataRows();

        [XmlAttribute]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlElement(ElementName = "rows")]
        public DataRows Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }
    }

    public class DataRows
    {
        private DataRow _row = new DataRow();

        [XmlElement(ElementName = "row")]
        public DataRow Row
        {
            get { return _row; }
            set { _row = value; }
        }
    }

    public class DataRow
    {
        private string _TB_NETWORKUSERNAME = "皇甫永祥";

        [XmlAttribute]
        public string TB_NETWORKUSERNAME
        {
            get { return _TB_NETWORKUSERNAME; }
            set { _TB_NETWORKUSERNAME = value; }
        }
    }
}
