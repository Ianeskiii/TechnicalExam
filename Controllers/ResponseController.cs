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
    public class ResponseController : ControllerBase
    {
        private readonly IRepository _repository;
        public ResponseController(ApplicationDbContext context, IRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost]
        
        public  async Task<ActionResult<IEnumerable<spokenToGuests>>> Post(string ResID, string userEmail)
        {
           
           if(ModelState.IsValid){
            var listOfCustomers = await _repository.FindByCondition<TalkToGuests>( x => x.Res_ID == ResID );
            //filtering Customers that in TalkToguest
            if(listOfCustomers.Count > 0 )
            {
                var listOfSpokenResID = await _repository.FindByCondition<spokenToGuests>( x => x.ResID == ResID );
                //filtering duplicate data to be insterted.
                if(listOfSpokenResID.Count <= 0){
                    spokenToGuests spoken = new spokenToGuests();
                    spoken.ResID = ResID;
                    spoken.userEmail = userEmail;
                    await _repository.CreateAsync<spokenToGuests>(spoken);
                    return Ok(spoken);
                }
                else {
                    //If data is duplicated in Talktoguest table - return message
                     return NotFound( new {body = "Customer with Reservation ID of " + ResID + " has been already spoken by park staff.."});
                }
            }
            else {
                //Return Error message if ResID doesnt belong in TalkToguest
                return NotFound( new {body = "A new record must be inserted into the spokenToGuests table with these details. A 200 response with an empty body is to be returned. "});
            }
           
           }
           //Return Invalid parameters.
            return NotFound( new {body = "A new record must be inserted into the spokenToGuests table with these details. A 200 response with an empty body is to be returned. "});

            

           
        }
    }
}