using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timelog.Model
{
    public class BookingCode
    {
        public int Id { get; set; }

        public TagTree TagTree {get;set;} 
            
    }
}