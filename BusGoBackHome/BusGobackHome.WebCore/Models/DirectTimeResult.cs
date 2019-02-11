using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusGobackHome.WebCore.Models
{
    public class DirectTimeResult
    {
        public DirectTimeResult()
        {
            Time = new List<DateTime>();
            Result = new List<int>();

            FillTime();
            CalculateDueTime();
        }

        private void FillTime()
        {
            //// fixed times http://bustracker.expressbus.ie/routes/860/O/Park_West-Westmoreland_Street
            ////09:30
            //Time.Add(DateTime.Today.AddHours(9).AddMinutes(30));
            ////11:00   
            //Time.Add(DateTime.Today.AddHours(11));
            ////12:00   
            //Time.Add(DateTime.Today.AddHours(12));
            ////12:45   
            //Time.Add(DateTime.Today.AddHours(12).AddMinutes(45));
            ////13:45   
            //Time.Add(DateTime.Today.AddHours(13).AddMinutes(45));
            ////16:00   
            //Time.Add(DateTime.Today.AddHours(16));
            ////16:20   
            //Time.Add(DateTime.Today.AddHours(16).AddMinutes(20));
            ////16:40   
            //Time.Add(DateTime.Today.AddHours(16).AddMinutes(40));
            ////17:00   
            //Time.Add(DateTime.Today.AddHours(17));
            ////17:20   
            //Time.Add(DateTime.Today.AddHours(17).AddMinutes(20));
            ////17:40   
            //Time.Add(DateTime.Today.AddHours(17).AddMinutes(40));
            ////18:00   
            //Time.Add(DateTime.Today.AddHours(18));
            ////18:20   
            //Time.Add(DateTime.Today.AddHours(18).AddMinutes(20));
            ////18:40   
            //Time.Add(DateTime.Today.AddHours(18).AddMinutes(40));
            ////19:00  
            //Time.Add(DateTime.Today.AddHours(19));
            ////19:30   
            //Time.Add(DateTime.Today.AddHours(19).AddMinutes(30));
            ////20:00
            //Time.Add(DateTime.Today.AddHours(20));

            // Imelda's email
            Time.Add(DateTime.Today.AddHours(7).AddMinutes(00));
            Time.Add(DateTime.Today.AddHours(7).AddMinutes(30));
            Time.Add(DateTime.Today.AddHours(8).AddMinutes(00));
            Time.Add(DateTime.Today.AddHours(8).AddMinutes(30));
            Time.Add(DateTime.Today.AddHours(9).AddMinutes(00));
            Time.Add(DateTime.Today.AddHours(9).AddMinutes(30));
            Time.Add(DateTime.Today.AddHours(16).AddMinutes(00));
            Time.Add(DateTime.Today.AddHours(16).AddMinutes(30));
            Time.Add(DateTime.Today.AddHours(17).AddMinutes(00));
            Time.Add(DateTime.Today.AddHours(17).AddMinutes(30));
            Time.Add(DateTime.Today.AddHours(18).AddMinutes(00));
            Time.Add(DateTime.Today.AddHours(18).AddMinutes(30));
            Time.Add(DateTime.Today.AddHours(19).AddMinutes(00));
            Time.Add(DateTime.Today.AddHours(19).AddMinutes(30));
        }

        private void CalculateDueTime()
        {
            var aux = Time.Where(o => o >= DateTime.Now).ToList();
            foreach (var item in aux)
            {
                int dueMin = (int)item.Subtract(DateTime.Now).TotalMinutes;
                Result.Add(dueMin);
            }
        }

        public string Name { get { return "860"; } }

        private IList<DateTime> Time { get; set; }

        public IList<int> Result { get; set; }

    }
}
