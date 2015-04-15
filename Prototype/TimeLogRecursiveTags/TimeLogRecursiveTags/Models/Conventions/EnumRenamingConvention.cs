using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TimeLogRecursiveTags.Models.Conventions
{
    public class EnumRenamingConvention : IStoreModelConvention<EdmProperty>
    {
        public void Apply(EdmProperty property, DbModel model)
        {
            //TODO need to find a better way to finish this off.
            if (property.Name=="TagType")
            {
                property.Name = property.Name+"Id";
            }
        }
    }
}