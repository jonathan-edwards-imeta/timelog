namespace Timelog.Model
{
    public class TagTree
    {
        public int Id {get;set; }

        public TagTree RelatedTagTree { get; set; }
        
        public Tag Tag { get; set; }


        //ToString()?
        public string TagTreePath
        {
            get { return BuildTagTreePath().TrimEnd('-'); }
        }

        internal string BuildTagTreePath()
        {
            var result = string.Empty;
            const string separator = "-";

            if (Tag != null)
            {
                if (RelatedTagTree != null)
                {
                    result += RelatedTagTree.BuildTagTreePath();
                }

                result += Tag.Text;
                result += separator;
            }

            return result;
        }
    }
}