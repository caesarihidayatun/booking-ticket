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
/// Summary description for News
/// </summary>
public class News
{
    private int newsId;

    public int NewsId
    {
        get { return newsId; }
        set { newsId = value; }
    }
    private string title;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    private string newsContent;

    public string NewsContent
    {
        get { return newsContent; }
        set { newsContent = value; }
    }
    private string author;

    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    private string images;

    public string Images
    {
        get { return images; }
        set { images = value; }
    }
    private int newsType;

    public int NewsType
    {
        get { return newsType; }
        set { newsType = value; }
    }
    private bool status;

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }
	public News()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
