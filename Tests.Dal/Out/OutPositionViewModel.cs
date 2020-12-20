namespace Tests.Dal.Out
{
    public class OutPositionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class OutPositionsWithCount : OutPositionViewModel
    {
        public int Count { get; set; }
        public bool IsCandidate { get; set; }
    }
}
