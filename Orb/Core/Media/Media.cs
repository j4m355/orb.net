using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using Orb.Coms;
using Orb.Core.Session;
using Orb.Data.Models;
using Orb.Data.Models.Media;
using RestSharp;


namespace Orb.Core.Media
{
    public static class Media
    {

        private static List<Item> SearchResults { get; set; }
        private static List<Item> temp { get; set; }

        private static string Query { get; set; }
        public static bool iveFullySearched { get; set; }

        public static List<Item> mediasearch(string query, bool refreshSearch = false)
        {
            Query = query.ToLower();
          

            if (refreshSearch || SearchResults == null || SearchResults.Any() == false)
            {
                FullSearch();
                MiniSearch();
            }
            else
            {
                MiniSearch();
            }

            return  temp;
        }




        private static void FullSearch()
        {
            ParamBuilder oParamBuilder = new ParamBuilder();
            SearchResults = new List<Item>();

            oParamBuilder.addParam("sid", StaticSessionSettings.sessionID);
            oParamBuilder.addParam("q", "");

            var oComm = new Api();
            var result = oComm.getResponseFromOrb<List<Item>>(Api.mediasearch, oParamBuilder.GetParamList());

            List<Item> Temp = new List<Item>();

            Temp = result;

            SearchResults.Clear();

            foreach (var item in Temp)
            {
                if (!string.IsNullOrWhiteSpace(item.field))
                    SearchResults.Add(item);
            }

            iveFullySearched = true;
        }

        private static void MiniSearch()
        {
            if (temp == null || SearchResults.Any() == false)
                temp = new List<Item>();
            else
                temp.Clear();

            temp.AddRange(SearchResults.Where(searchResult => searchResult.field.ToLower().Contains(Query)));
        }
    }




}
