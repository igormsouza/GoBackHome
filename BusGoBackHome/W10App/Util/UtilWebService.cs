using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Runtime.Serialization.Json;

using W10App.DTO;
using System.Threading.Tasks;

namespace W10App.Util
{
    public static class UtilWebService
    {
        public static string UrlPath = "http://parkwestcommute.azurewebsites.net/api/apihome";
        public static async Task<ReturnDTO<RealTime>> GetTimeAsync(object activity, string path) 
        {
            var result = new ReturnDTO<RealTime>();
            var aux = new RealTime();
            try
            {

                if (UtilAccessibility.VerifyInternetAccess(activity))
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = await httpClient.GetStringAsync(path);

                        DataContractJsonSerializer serializer2 = new DataContractJsonSerializer(typeof(RealTime));
                        using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
                        {
                            aux = (RealTime)serializer2.ReadObject(ms);
                            result.Value = aux;
                            result.Return = aux.succeed;
                        }
                    }
                }
                else
                {
                    result.SetarMsgErro("Turn on your internet to update the information.");
                }

            }
            catch (System.Net.WebException)
            {
                result.SetarMsgErro("Sorry, there is a problem to connect with our services.");
            }
            catch (Exception)
            {
                result.SetarMsgErro("Error.");
            }

            return result;
        }
    }
}