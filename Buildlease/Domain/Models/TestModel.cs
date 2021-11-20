namespace Domain.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Value { get; set; }

        public TestModel Parent { get; set; }
    }
}
