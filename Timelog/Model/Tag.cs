using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Timelog.Model
{
    public class Tag
    {
          public int Id { get; set; }
                
        public string Text { get; set; }
        
        public TagType TagType{ get; set;}        
    }
}