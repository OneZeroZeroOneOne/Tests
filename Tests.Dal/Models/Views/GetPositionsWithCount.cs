using Microsoft.EntityFrameworkCore;

namespace Tests.Dal.Models.Views
{
    public class PositionsWithCount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public bool IsCandidate { get; set; }
        public int UserId { get; set; }
    }

    public static class ContextPositionWithCountExtension
    {
        public static ModelBuilder AddPositionWithCountView(this ModelBuilder model)
        {
            model.Entity<PositionsWithCount>(x =>
            {
                x.ToTable("View_GetPositionsWithCount");
                x.HasKey(x => x.Id);
            });

            return model;
        }
    }
}
