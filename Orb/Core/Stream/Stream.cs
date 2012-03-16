using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using Orb.Coms;
using Orb.Core.Session;
using Orb.Data.Models.Stream;
using Orb.Exceptions;
using RestSharp;

namespace Orb.Core.Stream
{
    public class Stream
    {
       //private channel[] arrChannels = new channel[1025];
        public int lastChannel = 0;
        public const string FORMAT_3GP = "3gp";
        public const string FORMAT_RM = "rm";
        public const string FORMAT_ASX = "asx";
        public const string FORMAT_FLV = "flv";

        public const string TYPE_PC = "pc";
        public const string TYPE_PDA = "pda";
        public const string TYPE_PHONE = "phone";

        public string MediaTitle { get; set; }


        //public struct channel
        //{
        //    public string orbTitle;
        //    public string orbMediumID;
        //    public bool isFavorite;


        //    public ListItem listItem
        //    {
        //        get
        //        {
        //            string strFav;
        //            if (isFavorite)
        //            {
        //                strFav = " (FAV)";
        //            }
        //            else
        //            {
        //                strFav = "";
        //            }

        //            return new ListItem(orbMediumID, orbTitle + strFav);
        //        }
        //        set { value = listItem; }
        //    }
        //}


        //public ListItem GetChannelByName(string name)
        //{

        //    string title;
        //    // title = string.
        //    title = name.Replace(" (FAV)", "");
        //    title = title.Trim();

        //    for (int i = 0; i == 1024; i++)
        //    {
        //        Debug.Print(arrChannels[i].orbTitle);
        //        if (arrChannels[i].orbTitle == title)
        //        {
        //            return arrChannels[i]
        //                .listItem;
        //        }

        //    }
        //    return null;
        //}


        //public void RetrieveChannels()
        //{
        //    emptyArray();
        //    int intCounter = 1;

        //    var oComm = new Api();
        //    var oReader = oComm.ConvertStringToXmlReader(oComm.getResponseFromOrb(Api.tvgetListings, "sid=" + SessionSettings.sessionID));
        //    while (oReader.Read())
        //    {
        //        if (oReader.NodeType == XmlNodeType.Element)
        //        {
        //            if (oReader.Name == "channel")
        //            {
        //                arrChannels[intCounter] = new channel();
        //                arrChannels[intCounter].orbMediumID = oReader.GetAttribute("orbMediumId");
        //                arrChannels[intCounter].orbTitle = oReader.GetAttribute("title");
        //                if (Convert.ToInt16(oReader.GetAttribute("rating")) > 0)
        //                {
        //                    arrChannels[intCounter].isFavorite = true;
        //                }
        //                intCounter = intCounter + 1;

        //            }
        //        }
        //    }
        //    lastChannel = intCounter;
        //}

        //public ListItem GetChannel(int num)
        //{
        //    return arrChannels[num].listItem;
        //}

        //public ListItem GetChannel(string mediumid)
        //{
        //    dynamic intTeller = null;
        //    for (intTeller = 1; intTeller <= 1024; intTeller++)
        //    {
        //        if (arrChannels[intTeller].orbMediumID == mediumid)
        //        {
        //            return arrChannels[intTeller].listItem;
        //        }
        //    }
        //    return null;
        //}

        //public ListItem GetChannelByTitle(string title)
        //{
        //    dynamic intTeller = null;
        //    for (intTeller = 1; intTeller <= 1024; intTeller++)
        //    {
        //        if (arrChannels[intTeller].orbTitle == title)
        //        {
        //            return arrChannels[intTeller].listItem;
        //        }
        //    }
        //    return null;
        //}

        //public void emptyArray()
        //{
        //    lastChannel = 0;
        //}


        public string GetStreamingUri(string format, string orbMediumID, string type = TYPE_PC, int width = 0, int height = 0)
        {
            if (string.IsNullOrEmpty(orbMediumID))
                throw new OrbInternalError();

            var oParamBuilder = new ParamBuilder();
          
            oParamBuilder.addParam("sid",StaticSessionSettings.sessionID);
            oParamBuilder.addParam("streamFormat", format);
            oParamBuilder.addParam("mediumId", orbMediumID);
            oParamBuilder.addParam("type",type);
            if (height > 0)
                oParamBuilder.addParam("height", height.ToString());
            if (width > 0)
                oParamBuilder.addParam("width", width.ToString());

            Api oComm = new Api();

            var url = oComm.getManualAttributeFromOrbXmlNode(Api.Stream, oParamBuilder.GetParamList(), "item", "url");
            
            

            return url;
        }
        
    }

    //public class ListItem
    //{

    //    private object _value;

    //    private string _text;
    //    public ListItem(object value, string text)
    //    {
    //        _value = value;
    //        _text = text;
    //    }
    //    public object Value
    //    {
    //        get { return _value; }
    //        set { _value = value; }
    //    }

    //    public string Text
    //    {
    //        get { return _text; }
    //        set { _text = value; }
    //    }

    //    public override string ToString()
    //    {
    //        return _text;
    //    }

    //}
}
