using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nager.Date;
using Microsoft.Extensions.Logging;

namespace workdays_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkDayController : ControllerBase
    {
        private readonly ILogger<WorkDayController> _logger;

        public WorkDayController(ILogger<WorkDayController> logger)
        {
            _logger = logger;
        }

        private bool Is_work_day(DateTime date)
        {
            return !DateSystem.IsPublicHoliday(date,CountryCode.BR) && 
                   date.DayOfWeek != DayOfWeek.Saturday &&
                   date.DayOfWeek != DayOfWeek.Sunday;        
        }

        private Models.WorkDay FindWorkDay(int days){
            DateTime work_day = DateTime.Now;
            int absolute_days_value = System.Math.Abs(days);
            bool is_past = days < 0;
            while(absolute_days_value != 0){
                work_day = work_day.AddDays( is_past ? -1 : 1);
                if( Is_work_day(work_day)){
                    absolute_days_value -= 1;
                }
            }
            var work_day_class_instance = new Models.WorkDay();
            work_day_class_instance.work_day = work_day;
            return work_day_class_instance;
        }

        [HttpGet("before/{past_days}")]
        public Models.WorkDay GetPastDays(int past_days)
        {
            return FindWorkDay(-past_days);
        }

        [HttpGet("after/{next_days}")]
        public Models.WorkDay GetNextDays(int next_days)
        {
            return FindWorkDay(next_days);
        }
    }
}
