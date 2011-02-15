using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Function
/// </summary>
public class Function
{
    public Function()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string RemoveSpecialChars(string str)
    {
        string[] chars = new string[] { ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "-", "_", "(", ")", ":", "|", "[", "]" };
        for (int i = 0; i < chars.Length; i++)
        {
            if (str.Contains(chars[i]))
            {
                str = str.Replace(chars[i], "");
            }
        }
        return str;
    }
}
