using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using technicalExam.Data;
using technicalExam.Models;
using technicalExam.Models.Repositories;

namespace technicalExam.Controllers
{
    [ApiController]
    [Route("api/NPS/[controller]")]
    public class CustomersController : ControllerBase
    {`
        private readonly IRepository _repository;
        public CustomersController(ApplicationDbContext context, IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<Customers>>> Get(string parkCode, string arriving)
        {
            List<Customers> ListOfCustomersNeedsToTalk = new List<Customers>();
            var listOfCustomers = await _repository.FindByCondition<TalkToGuests>(x => x.Park_Code == parkCode && x.Arrived == arriving);
            if(listOfCustomers.Count > 1)
            {
                foreach(var list in listOfCustomers)
                {
                    Customers customer = new Customers();
                    customer.ReservationId = list.Res_ID;
                    customer.GuestName = list.Guest_Name;
                    customer.GuestMobile = list.Guest_Mobile;
                    customer.Arrived = list.Arrived;
                    customer.Depart = list.Depart;
                    customer.Category = list.Category;
                    customer.Nights = list.Nights_ThisRes;
                    customer.AreaName = list.Area_Name;

                    //Needs to validate the value prev_nps because of mismatch data type.
                    if(list.Prev_NPS==null || list.Prev_NPS == string.Empty)
                        customer.PreviousNPS = default(int);
                     else
                        customer.PreviousNPS = Convert.ToInt32(list.Prev_NPS);
                    customer.PreviousNPCComment = list.Prev_NPS_Comment;
                    ListOfCustomersNeedsToTalk.Add(customer);
                }    
                return ListOfCustomersNeedsToTalk;
            }
            return NotFound( new { body = "You must filter the contents of the talktoguests table by finding only records matching parkCode and arrived (exact string match)." });
        }
    }
}