using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace CarSystem.Console.XmlModels
{
    [Serializable]
    [XmlType("Queries")]
    public class QueryXmlModel
    {
        [XmlAttribute]
        public string OutputFileName { get; set; }

        public int OrderBy { get; set; }

        [XmlArrayItem(ElementName = "WhereClause")]
        public List<WhereClauseXmlModel> WhereClausesWhereClause { get; set; }
    }
}
