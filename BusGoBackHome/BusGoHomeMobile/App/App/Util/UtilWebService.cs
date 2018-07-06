using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Runtime.Serialization.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App.DTO;
using System.Threading.Tasks;

namespace App.Util
{
    public static class UtilWebService
    {
        public static string UrlPath = "http://parkwestcommute.azurewebsites.net/api/apihome";

        //public static T Get<T, S>(object activity, string path) where T : ReturnDTO<S>
        //{
        //    var result = Activator.CreateInstance<T>();

        //    if (UtilAccessibility.VerifyInternetAccess(activity))
        //    {
        //        try
        //        {
        //            using (var httpClient = new HttpClient())
        //            {
        //                var content = httpClient.GetStringAsync(path).Result;

        //                var serializer2 = new DataContractJsonSerializer(typeof(T));
        //                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
        //                {
        //                    result = (T)serializer2.ReadObject(ms);
        //                }
        //            }
        //        }
        //        catch (System.Net.WebException ex)
        //        {
        //            result.SetarMsgErro("Sorry, there is a problem to connect with our services.");
        //        }
        //        catch (Exception ex)
        //        {
        //            result.SetarMsgErro("Error.");
        //        }
        //    }
        //    else
        //    {
        //        result.SetarMsgErro("Turn on your internet to update the information.");
        //    }

        //    return result;
        //}

        //public static async Task<T> GetAsync<T, S>(object activity, string path) where T : ReturnDTO<S>
        //{
        //    var result = Activator.CreateInstance<T>();
        //    try
        //    {

        //        if (UtilAccessibility.VerifyInternetAccess(activity))
        //        {
        //            using (var httpClient = new HttpClient())
        //            {
        //                var content = await httpClient.GetStringAsync(path);

        //                DataContractJsonSerializer serializer2 = new DataContractJsonSerializer(typeof(T));
        //                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
        //                {
        //                    result = (T)serializer2.ReadObject(ms);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            result.SetarMsgErro("Turn on your internet to update the information.");
        //        }

        //    }
        //    catch (System.Net.WebException ex)
        //    {
        //        result.SetarMsgErro("Sorry, there is a problem to connect with our services.");
        //    }
        //    catch (Exception ex)
        //    {
        //        result.SetarMsgErro("Error.");
        //    }

        //    return result;
        //}

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
            catch (System.Net.WebException ex)
            {
                result.SetarMsgErro("Sorry, there is a problem to connect with our services.");
            }
            catch (Exception ex)
            {
                result.SetarMsgErro("Error.");
            }

            return result;
        }
    }
}