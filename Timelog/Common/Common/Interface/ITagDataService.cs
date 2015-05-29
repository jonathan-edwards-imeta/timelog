using Timelog.Model;

namespace Timelog.Common.Interface
{
    public interface ITagDataService : IGetAllDataService<Tag>
    {
        Tag Patch(Tag tag);
    }
}