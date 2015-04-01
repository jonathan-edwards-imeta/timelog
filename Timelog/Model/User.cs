using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Timelog.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}