using System.Collections.Generic;
using System.Linq;
using Timelog.DataAccess;
using Timelog.Model;

namespace TestData
{
    //Eventually all Test data will return its self.

    ///// <summary>
    ///// Work in Progress
    ///// </summary>
    //public class Tags
    //{
    //    public IEnumerable<Tag> Seed(TimeLogContext context)
    //    {
    //        IList<Tag> tags = new List<Tag>()
    //        {
    //            new Tag() {Text = "Lloyds", TagType = TagType.Customer},
    //            new Tag() {Text = "Barcap", TagType = TagType.Customer},
    //            new Tag() {Text = "Credit Suisse", TagType = TagType.Customer},
    //            new Tag() {Text = "HSBC", TagType = TagType.Customer},
    //            new Tag() {Text = "SCB", TagType = TagType.Customer},

    //            new Tag() {Text = "BMO", TagType = TagType.Customer},
    //            new Tag() {Text = "TD", TagType = TagType.Customer},
    //            new Tag() {Text = "Phase1", TagType = TagType.Phase},
    //            new Tag() {Text = "Spec", TagType = TagType.Project},
    //            new Tag() {Text = "Implementation", TagType = TagType.Project},
    //            new Tag() {Text = "Downstream", TagType = TagType.Task},
    //            new Tag() {Text = "Mq", TagType = TagType.SubTask}
    //        };

    //        foreach (var tag in tags)
    //        {
    //            context.Tags.Add(tag);    
    //        }
            
    //        context.SaveChanges();

    //        return tags;
    //    }
    //}

    ///// <summary>
    ///// Work in Progress
    ///// </summary>
    //public class TagTrees
    //{
    //    public IEnumerable<TagTree> Seed(TimeLogContext context, IEnumerable<Tag> tags )
    //    {
    //        var tdTagTree = new TagTree() { Tag = tags.FirstOrDefault(x=>x.Text=="TD")};
    //        var tdPhase1TagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Phase1"), RelatedTagTree = tdTagTree };
    //        var tdPhase1SpecTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Spec"), RelatedTagTree = tdPhase1TagTree };
    //        var tdPhase1SpecDownStreamTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Downstream"), RelatedTagTree = tdPhase1SpecTagTree };
    //        var tdPhase1ImplementationTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Implementation"), RelatedTagTree = tdPhase1TagTree };
    //        var tdPhase1ImplementationDownStreamTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Downstream"), RelatedTagTree = tdPhase1ImplementationTagTree };
    //        var tdPhase1ImplementationDownStreamMqTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Mq"), RelatedTagTree = tdPhase1ImplementationDownStreamTagTree };

    //        var bmoTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "BMO") };
    //        var bmoPhase1TagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Phase1"), RelatedTagTree = bmoTagTree };
    //        var bmoPhase1SpecTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Spec"), RelatedTagTree = bmoPhase1TagTree };
    //        var bmoPhase1SpecDownStreamTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Downstream"), RelatedTagTree = bmoPhase1SpecTagTree };
    //        var bmoPhase1ImplementationTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Implementation"), RelatedTagTree = bmoPhase1TagTree };
    //        var bmoPhase1ImplementationDownStreamTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Downstream"), RelatedTagTree = bmoPhase1ImplementationTagTree };
    //        var bmoPhase1ImplementationDownStreamMqTagTree = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Mq"), RelatedTagTree = bmoPhase1ImplementationDownStreamTagTree };

    //        var twoBolteda = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "BMO"), RelatedTagTree = tdPhase1ImplementationDownStreamMqTagTree };
    //        var twoBoltedb = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Phase1"), RelatedTagTree = twoBolteda };
    //        var twoBoltedc = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Spec"), RelatedTagTree = twoBoltedb };
    //        var twoBoltedd = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Downstream"), RelatedTagTree = twoBoltedc };
    //        var twoBoltede = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Mq"), RelatedTagTree = twoBoltedd };
    //        var twoBoltedf = new TagTree() { Tag = tags.FirstOrDefault(x => x.Text == "Implementation"), RelatedTagTree = twoBoltede };

    //        IList<TagTree> tagTrees = new List<TagTree>()
    //        { tdTagTree, tdPhase1TagTree, tdPhase1SpecTagTree, tdPhase1SpecDownStreamTagTree, tdPhase1ImplementationTagTree, 
    //            tdPhase1ImplementationDownStreamTagTree, tdPhase1ImplementationDownStreamMqTagTree, 
                
    //            bmoTagTree, bmoPhase1TagTree, bmoPhase1SpecTagTree, bmoPhase1SpecDownStreamTagTree, bmoPhase1ImplementationTagTree, 
    //            bmoPhase1ImplementationDownStreamTagTree, bmoPhase1ImplementationDownStreamMqTagTree,

    //            twoBolteda, twoBoltedb, twoBoltedc, twoBoltedd, twoBoltede, twoBoltedf
    //        };

    //        foreach (var tagTree in tagTrees)
    //        {
    //            context.TagTrees.Add(tagTree);
    //        }

    //        context.SaveChanges();

    //        return tagTrees;
    //    }
    //}




    public class TagsTagTreesBookingCodes
    {
        public void Seed(TimeLogContext context)
        {
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

            context.Tags.Add(lloydsTag);
            context.Tags.Add(barcapTag);
            context.Tags.Add(creditSuisseTag);
            context.Tags.Add(hsbcTag);
            context.Tags.Add(scbTag);
            context.Tags.Add(bmoTag);
            context.Tags.Add(tdTag);
            context.Tags.Add(phase1Tag);
            context.Tags.Add(specTag);
            context.Tags.Add(implTag);
            context.Tags.Add(downstreamTag);
            context.Tags.Add(mqTag);
            context.SaveChanges();

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

            context.TagTrees.Add(tdTagTree);
            context.TagTrees.Add(tdPhase1TagTree);
            context.TagTrees.Add(tdPhase1SpecTagTree);
            context.TagTrees.Add(tdPhase1SpecDownStreamTagTree);
            context.TagTrees.Add(tdPhase1ImplementationTagTree);
            context.TagTrees.Add(tdPhase1ImplementationDownStreamTagTree);
            context.TagTrees.Add(tdPhase1ImplementationDownStreamMqTagTree);

            context.TagTrees.Add(bmoTagTree);
            context.TagTrees.Add(bmoPhase1TagTree);
            context.TagTrees.Add(bmoPhase1SpecTagTree);
            context.TagTrees.Add(bmoPhase1SpecDownStreamTagTree);
            context.TagTrees.Add(bmoPhase1ImplementationTagTree);
            context.TagTrees.Add(bmoPhase1ImplementationDownStreamTagTree);
            context.TagTrees.Add(bmoPhase1ImplementationDownStreamMqTagTree);

            context.TagTrees.Add(twoBolteda);
            context.TagTrees.Add(twoBoltedb);
            context.TagTrees.Add(twoBoltedc);
            context.TagTrees.Add(twoBoltedd);
            context.TagTrees.Add(twoBoltede);
            context.TagTrees.Add(twoBoltedf);

            context.SaveChanges();



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

            context.BookingCodes.Add(tdPhase1SpecBookingCode);
            context.BookingCodes.Add(tdPhase1SpecDownstreamBookingCode);
            context.BookingCodes.Add(tdPhase1ImplBookingCode);
            context.BookingCodes.Add(tdPhase1ImplDownstreamBookingCode);
            context.BookingCodes.Add(tdPhase1ImplDownstreamMqBookingCode);

            context.BookingCodes.Add(bmoPhase1SpecBookingCode);
            context.BookingCodes.Add(bmoPhase1SpecDownstreamBookingCode);
            context.BookingCodes.Add(bmoPhase1ImplBookingCode);
            context.BookingCodes.Add(bmoPhase1ImplDownstreamBookingCode);
            context.BookingCodes.Add(bmoPhase1ImplDownstreamMqBookingCode);

            context.BookingCodes.Add(twoBoltedBooking);

            context.SaveChanges();
        }
    }
}
