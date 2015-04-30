using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.Common
{
    public interface IDataGenerator
    {
        void GenerateUsers();

        void GenerateTags();

        void GenerateTagTrees();

        void GenerateBookingCodes();

        void GenerateTimeEntries();
    }
}
