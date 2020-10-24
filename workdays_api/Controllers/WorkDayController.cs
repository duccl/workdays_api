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
            return DateSystem.IsPublicHoliday(date,CountryCode.BR) || date.DayOfWeek != DayOfWeek.Saturday || date.DayOfWeek != DayOfWeek.Sunday;        
        }
        
        private Models.WorkDay FindPastWorkDay(int past_days)
        {
            DateTime work_day = DateTime.Now;
            int days_elapsed = 1;
            while(days_elapsed != (past_days + 1))
            {
                if(Is_work_day(work_day)){
                    work_day = work_day.AddDays(-days_elapsed);
                    days_elapsed += 1;
                }
            }
            var work_day_class = new Models.WorkDay();
            work_day_class.work_day = work_day;
            return work_day_class;
        }

        [HttpGet("before/{past_days}")]
        public Models.WorkDay GetPastDays(int past_days)
        {
            return FindPastWorkDay(past_days);
        }
    }
}
