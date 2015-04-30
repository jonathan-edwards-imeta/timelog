using System.Collections.Generic;
using Timelog.Model;
using Timelog.TestData.Properties;

namespace Timelog.TestData
{
    //Eventually all Test data will return its self.

    public class TagsTagTreesBookingCodes
    {
        public static List<Tag> Tags { get; private set; }

        public static List<TagTree> TagTrees { get; private set; }

        public static List<BookingCode> BookingCodes { get; private set; }

        static TagsTagTreesBookingCodes()
        {
            if (Tags != null && TagTrees != null && BookingCodes != null)
                return;

            Tags = new List<Tag>();
            TagTrees = new List<TagTree>();
            BookingCodes = new List<BookingCode>();

            if (!Settings.Default.CreateTags)
                return;

            var lloydsTag = new Tag() {Text = "Lloyds", TagType = TagType.Customer};
            var barcapTag = new Tag() {Text = "Barcap", TagType = TagType.Customer};
            var creditSuisseTag = new Tag() {Text = "Credit Suisse", TagType = TagType.Customer};
            var hsbcTag = new Tag() {Text = "HSBC", TagType = TagType.Customer};
            var scbTag = new Tag() {Text = "SCB", TagType = TagType.Customer};

            var bmoTag = new Tag() {Text = "BMO", TagType = TagType.Customer};
            var tdTag = new Tag() {Text = "TD", TagType = TagType.Customer};
            var phase1Tag = new Tag() { Text = "Phase1", TagType = TagType.Phase };
            var specTag = new Tag() { Text = "Spec", TagType = TagType.Project };
            var implTag = new Tag() { Text = "Implementation", TagType = TagType.Project };
            var downstreamTag = new Tag() {Text = "Downstream", TagType = TagType.Task};
            var mqTag = new Tag() { Text = "Mq", TagType = TagType.SubTask };

            Tags.Add(lloydsTag);
            Tags.Add(barcapTag);
            Tags.Add(creditSuisseTag);
            Tags.Add(hsbcTag);
            Tags.Add(scbTag);
            Tags.Add(bmoTag);
            Tags.Add(tdTag);
            Tags.Add(phase1Tag);
            Tags.Add(specTag);
            Tags.Add(implTag);
            Tags.Add(downstreamTag);
            Tags.Add(mqTag);

            if (!Settings.Default.CreateTagTrees)
                return;

            var tdTagTree = new TagTree() { Tag = tdTag };
            var tdPhase1TagTree = new TagTree() { Tag = phase1Tag, RelatedTagTree = tdTagTree };
            var tdPhase1SpecTagTree = new TagTree() { Tag = specTag, RelatedTagTree = tdPhase1TagTree };
            var tdPhase1SpecDownStreamTagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = tdPhase1SpecTagTree };
            var tdPhase1ImplementationTagTree = new TagTree() { Tag = implTag, RelatedTagTree = tdPhase1TagTree };
            var tdPhase1ImplementationDownStreamTagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = tdPhase1ImplementationTagTree };
            var tdPhase1ImplementationDownStreamMqTagTree = new TagTree() { Tag = mqTag, RelatedTagTree = tdPhase1ImplementationDownStreamTagTree };

            var bmoTagTree = new TagTree() { Tag = bmoTag };
            var bmoPhase1TagTree = new TagTree() { Tag = phase1Tag, RelatedTagTree = bmoTagTree };
            var bmoPhase1SpecTagTree = new TagTree() { Tag = specTag, RelatedTagTree = bmoPhase1TagTree };
            var bmoPhase1SpecDownStreamTagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = bmoPhase1SpecTagTree };
            var bmoPhase1ImplementationTagTree = new TagTree() { Tag = implTag, RelatedTagTree = bmoPhase1TagTree };
            var bmoPhase1ImplementationDownStreamTagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = bmoPhase1ImplementationTagTree };
            var bmoPhase1ImplementationDownStreamMqTagTree = new TagTree() { Tag = mqTag, RelatedTagTree = bmoPhase1ImplementationDownStreamTagTree };

            var twoBolteda = new TagTree() { Tag = bmoTag, RelatedTagTree = tdPhase1ImplementationDownStreamMqTagTree };
            var twoBoltedb = new TagTree() { Tag = phase1Tag, RelatedTagTree = twoBolteda };
            var twoBoltedc = new TagTree() { Tag = specTag, RelatedTagTree = twoBoltedb };
            var twoBoltedd = new TagTree() { Tag = downstreamTag, RelatedTagTree = twoBoltedc };
            var twoBoltede = new TagTree() { Tag = mqTag, RelatedTagTree = twoBoltedd };
            var twoBoltedf = new TagTree() { Tag = implTag, RelatedTagTree = twoBoltede };

            TagTrees.Add(tdTagTree);
            TagTrees.Add(tdPhase1TagTree);
            TagTrees.Add(tdPhase1SpecTagTree);
            TagTrees.Add(tdPhase1SpecDownStreamTagTree);
            TagTrees.Add(tdPhase1ImplementationTagTree);
            TagTrees.Add(tdPhase1ImplementationDownStreamTagTree);
            TagTrees.Add(tdPhase1ImplementationDownStreamMqTagTree);

            TagTrees.Add(bmoTagTree);
            TagTrees.Add(bmoPhase1TagTree);
            TagTrees.Add(bmoPhase1SpecTagTree);
            TagTrees.Add(bmoPhase1SpecDownStreamTagTree);
            TagTrees.Add(bmoPhase1ImplementationTagTree);
            TagTrees.Add(bmoPhase1ImplementationDownStreamTagTree);
            TagTrees.Add(bmoPhase1ImplementationDownStreamMqTagTree);

            TagTrees.Add(twoBolteda);
            TagTrees.Add(twoBoltedb);
            TagTrees.Add(twoBoltedc);
            TagTrees.Add(twoBoltedd);
            TagTrees.Add(twoBoltede);
            TagTrees.Add(twoBoltedf);

            if (!Settings.Default.CreateBookingCodes)
                return;

            var tdPhase1SpecBookingCode = new BookingCode() { TagTree = tdPhase1SpecTagTree };
            var tdPhase1SpecDownstreamBookingCode = new BookingCode() { TagTree = tdPhase1SpecDownStreamTagTree };
            var tdPhase1ImplBookingCode = new BookingCode() { TagTree = tdPhase1ImplementationTagTree };
            var tdPhase1ImplDownstreamBookingCode = new BookingCode() { TagTree = tdPhase1ImplementationDownStreamTagTree };
            var tdPhase1ImplDownstreamMqBookingCode = new BookingCode() { TagTree = tdPhase1ImplementationDownStreamMqTagTree };

            var bmoPhase1SpecBookingCode = new BookingCode() { TagTree = bmoPhase1SpecTagTree };
            var bmoPhase1SpecDownstreamBookingCode = new BookingCode() { TagTree = bmoPhase1SpecDownStreamTagTree };
            var bmoPhase1ImplBookingCode = new BookingCode() { TagTree = bmoPhase1ImplementationTagTree };
            var bmoPhase1ImplDownstreamBookingCode = new BookingCode() { TagTree = bmoPhase1ImplementationDownStreamTagTree };
            var bmoPhase1ImplDownstreamMqBookingCode = new BookingCode() { TagTree = bmoPhase1ImplementationDownStreamMqTagTree };

            var twoBoltedBooking = new BookingCode() { TagTree = twoBoltedf };

            BookingCodes.Add(tdPhase1SpecBookingCode);
            BookingCodes.Add(tdPhase1SpecDownstreamBookingCode);
            BookingCodes.Add(tdPhase1ImplBookingCode);
            BookingCodes.Add(tdPhase1ImplDownstreamBookingCode);
            BookingCodes.Add(tdPhase1ImplDownstreamMqBookingCode);

            BookingCodes.Add(bmoPhase1SpecBookingCode);
            BookingCodes.Add(bmoPhase1SpecDownstreamBookingCode);
            BookingCodes.Add(bmoPhase1ImplBookingCode);
            BookingCodes.Add(bmoPhase1ImplDownstreamBookingCode);
            BookingCodes.Add(bmoPhase1ImplDownstreamMqBookingCode);

            BookingCodes.Add(twoBoltedBooking);                  
        }
    }
}
