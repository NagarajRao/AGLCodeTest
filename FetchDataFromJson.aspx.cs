using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TestingCode.AGL
{
    public partial class FetchDataFromJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDataInfo();
        }

        private async void getDataInfo()
        {
            try
            {
                // Reading JSON from the server
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://agl-developer-test.azurewebsites.net/people.json");
                response.EnsureSuccessStatusCode();

                string RespBody = await response.Content.ReadAsStringAsync();
                
                // Deserializing the response
                var _deserialRespBody = JsonConvert.DeserializeObject<dynamic>(RespBody);

                // Building HTML to display the content
                StringBuilder htmlTable = new StringBuilder();

                htmlTable.Append("<table style='font-family:verdana;'>");
                htmlTable.Append("<tr><th style='font-size:13px;border-color:black; border-style:groove; border-width:thin'>Owners' Name</th><th style='font-size:13px;border-color:black; border-style:groove; border-width:thin'>Pets</th></tr>");

                foreach (var rsp in _deserialRespBody)
                {
                    htmlTable.Append("<tr><td style='font-size:13px;border-color:black; border-style:groove; border-width:thin'>" + rsp.name + "</td><td  style='border-color:black; border-style:groove; border-width:thin'></td></tr>");
                    if (rsp.pets != null)
                    {

                        // Sorting and Building HTML
                        List<string> sortedPetName = new List<string>();

                        foreach (var petname in rsp.pets)
                            sortedPetName.Add(petname.name.ToString() + "(" + petname.type.ToString() + ")");

                        var sortedVar = sortedPetName.OrderBy(name => name);

                        foreach (var petname in sortedVar)
                            htmlTable.Append("<tr><td  style='border-color:black; border-style:groove; border-width:thin'></td><td style='font-size: 11px; border-color:black; border-style:groove; border-width:thin'>" + petname.ToString() + "</td></tr>");
                        

                    }
                    else
                        htmlTable.Append("<tr><td  style='border-color:black; border-style:groove; border-width:thin'></td><td  style='font-size: 11px; border-color:black; border-style:groove; border-width:thin'> There are not pets for: " + rsp.name.ToString() + "</td></tr>");
                }
                htmlTable.Append("</table>");
                JsonValuPH.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
            catch (Exception ex) {
                lblMessage.Text = "Error Loading JSON File:" + ex.Message.ToString();
            }
        }
    }
}
