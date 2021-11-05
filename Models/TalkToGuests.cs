using System;
using System.ComponentModel.DataAnnotations;

namespace technicalExam.Models
{
    public class TalkToGuests
    {
       public string Park_Code { get; set; }
       public string PM_Email { get; set; }
       public string Category { get; set; }
       public string Guest_Name { get; set; }
       public string Guest_Mobile { get; set; }
        [Key]
       public string Res_ID { get; set; }
       public string Arrived { get; set; }
       public string Depart { get; set; }
       public string Nights_ThisRes { get; set; }
       public string Revenue_ThisRes { get; set; }
       public string Prior_Visits { get; set; }
       public string Prior_Revenue { get; set; }
       public string Prior_Nights { get; set; }
       public string Member_Status { get; set; }
       public string Area_Name { get; set; }
       public string Prev_ResID { get; set; }
       public string Prev_NPS { get; set; }
       public string Prev_NPS_Comment { get; set; }
       public string HaveVisited { get; set; }
    }

}