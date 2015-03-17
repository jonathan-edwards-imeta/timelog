using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeLogRecursiveTags.Models
{
    public class BookingCode
    {
        public int Id { get; set; }

        public TagTree TagTree {get;set;} 
            
    }
}