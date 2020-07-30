using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

public class TreeXml
{
    private XmlDocument xmlDoc = new XmlDocument();
    public string treePath = "LeftTree.xml";
    public TreeXml()
    {

    }
    public void LoadXml(string path)
    {
        xmlDoc.LoadXml(path.Trim());
    }
    public DataTable GetModule()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ModuleName", typeof(string));
        dt.Columns.Add("id", typeof(string));
        XmlNodeList nodes = xmlDoc.SelectNodes("tree/item");
        foreach (XmlNode node in nodes)
        {
            DataRow dr = dt.NewRow();
            dr["id"] = node.Attributes["id"].Value;
            dr["ModuleName"] = node.Attributes["id"].InnerText;
            dt.Rows.Add(dr);
        }
        return dt;
    }
    public DataTable GetSubModule(string module)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("SubModuleName", typeof(string));
        dt.Columns.Add("Url", typeof(string));
        dt.Columns.Add("src", typeof(string));
        XmlNodeList nodes = xmlDoc.SelectSingleNode("//*[@id='" + module + "']").ChildNodes;
        foreach (XmlNode node in nodes)
        {
            DataRow dr = dt.NewRow();
            dr["Url"] = node.ChildNodes[0].InnerText;
            dr["SubModuleName"] = node.ChildNodes[0].InnerText;
            dr["src"] = "";
            dt.Rows.Add(dr);
        }
        return dt;
    }
}
