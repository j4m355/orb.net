using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using Orb.Core.Session;
using Orb.Data.Models;
using Orb.Data.Models.Media;
using RestSharp;

namespace Orb.Coms
{

    public class Api
    {
        public const string ApiBaseUri = "https://api.orb.com/orb/";

        /*Computer*/
        public const string computergetOnlineStatus = "xml/computer.getStatus";
        public const string computergetStatus = "xml/computer.getStatus";
        public const string computerrestartOrb = "xml/computer.restartOrb";
        public const string computerstopMediaCenter = "xml/computer.stopMediaCenter";
        public const string computerwakeUp = "xml/computer.wakeUp";

        /*Contacts*/
        public const string contactsaddContact = "xml/contacts.addContact";
        public const string contactsaddContactsToGroup = "xml/contacts.addContactsToGroup";
        public const string contactsaddGroup = "xml/contacts.addGroup";
        public const string contactsdeleteContacts = "xml/contacts.deleteContacts";
        public const string contactsdeleteGroup = "xml/contacts.deleteGroup";
        public const string contactseditContact = "xml/contacts.editContact";
        public const string contactsgetContacts = "xml/contacts.getContacts";
        public const string contactsgetGroups = "xml/contacts.getGroups";
        public const string contactsgetSettings = "xml/contacts.getSettings";
        public const string contactsremoveContactsFromGroup = "xml/contacts.removeContactsFromGroup";
        public const string contactssetSettings = "xml/contacts.setSettings";

        /*File*/
        public const string filebrowse = "xml/file.browse";
        public const string filegetSize = "xml/file.getSize";
        public const string fileupload = "xml/file.upload";

        /*Image*/
        public const string imagecrop = "xml/image.crop";
        public const string imagerotate = "xml/image.rotate";

        /*Media*/
        public const string mediacreatePermalink = "xml/media.createPermalink";
        public const string mediadelete = "xml/media.delete";
        public const string mediaremovePermalink = "xml/media.removePermalink";
        public const string mediarescanFolder = "xml/media.rescanFolder";
        public const string mediasearch = "xml/media.search";
        public const string mediasetFields = "xml/media.setFields";

        /*Playlists*/
        public const string playlistaddItems = "xml/playlist.addItems";
        public const string playlistchangeItemPosition = "xml/playlist.changeItemPosition";
        public const string playlistcreate = "xml/playlist.create";
        public const string playlistgetContent = "xml/playlist.getContent";
        public const string playlistremoveItems = "xml/playlist.removeItems";

        /*PVR*/
        public const string pvraddPass = "xml/pvr.addPass";
        public const string pvraddSchedule = "xml/pvr.addSchedule";
        public const string pvrstopRecording = "xml/pvr.stopRecording";

        /*Session*/
        public const string sessionkeepAlive = "xml/session.keepAlive";
        public const string sessionlogin = "xml/session.login";
        public const string sessionlogout = "xml/session.logout";

        /*Stream*/
        public const string Stream = "xml/stream";

        /*TV*/
        public const string tvgetTuners = "xml/tv.getTuners";
        public const string tvgetListings = "xml/tv.getListings";

        /*User*/
        public const string userdeleteSettings = "xml/user.deleteSettings";
        public const string usergetSettings = "xml/user.getSettings";
        public const string usergetSharers = "xml/user.getSharers";
        public const string usersetSettings = "xml/user.setSettings";



        public T getResponseFromOrb<T>(string apiFunq, string parameters) where T : new()
        {
            var request = new RestRequest { Resource = ApiBaseUri + apiFunq + "?" + parameters };
            var client = new RestClient();
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public T getResponseFromOrb<T>(RestRequest request, string apiFunq, string parameters) where T : new()
        {
            request.Resource = ApiBaseUri + apiFunq + "?" + parameters;
            var client = new RestClient();
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public string getManualAttributeFromOrbXmlNode(string apiFunq, string parameters, string node, string attribute)
        {
            var request = new RestRequest { Resource = ApiBaseUri + apiFunq + "?" + parameters };
            var client = new RestClient();
            var response = client.Execute(request);

            var returnvalue = getAttribute(response.Content,node,attribute);

            return returnvalue;
        }

     
        private string getAttribute(string xml, string node, string attribute)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var oXmlReader = new XmlNodeReader(doc);
            
            string result = "";
            while (oXmlReader.Read())
            {
                switch (oXmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (oXmlReader.Name == node)
                        {
                             result = oXmlReader.GetAttribute(attribute);
                        }
                        break;
                }
            }
            return result;
        }


   
    }


}
