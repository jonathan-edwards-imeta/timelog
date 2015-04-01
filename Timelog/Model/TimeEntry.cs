using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Timelog.Model
{
    public class TimeEntry
    {
        public int Id { get; set; }

        public DateTime TimeEntryCreated { get; set; }

        public decimal TimeEntryDuration { get; set; }

        public string TimeEntryDescription { get; set; }

        public virtual BookingCode BookingCode { get; set; }

        public DateTime TimeEntryDate { get; set; }
        
        public virtual User TimeEntryCreator { get; set; }

        public virtual User TimeEntryUser { get; set; }

    }
}