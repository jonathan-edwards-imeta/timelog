using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Timelog.Model
{
    public class TagTree
    {
        public int Id {get;set; }

        public TagTree RelatedTagTree { get; set; }
        
        public Tag Tag { get; set; }

        public string TagTreePath
        {
            get
            {
                string t = Tag.Text;
                t += "-";
                t += RelatedTagTree.TagTreePath;
                return t;
            }
        }
    }
}