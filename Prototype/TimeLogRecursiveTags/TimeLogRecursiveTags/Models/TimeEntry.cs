using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TimeLogRecursiveTags.Models
{
    public class TimeEntry
    {

        public int Id { get; set; }
                
        public DateTime TimeEntryCreated { get; set; }

        public decimal TimeEntryDuration { get; set; }

        public string TimeEntryDescription { get; set; }

        //TODO do we need this?
        [ForeignKey("BookingCode")]
        public int BookingCodeId { get; set; }
        public virtual BookingCode BookingCode { get; set; }

        public DateTime TimeEntryDate { get; set; }


        //[ForeignKey("TimeEntryCreator")]
        //public int TimeEntryCreatorId { get; set; }
        //public virtual User TimeEntryCreator { get; set; }


        [ForeignKey("TimeEntryUser")]
        public int TimeEntryUserId { get; set; }
        public virtual User TimeEntryUser { get; set; }

    }
}