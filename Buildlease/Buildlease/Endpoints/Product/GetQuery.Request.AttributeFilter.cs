
namespace Buildlease.Endpoints.Product
{
    public class AttributeFilter 
    {
        public int AttributeId { get; set; }
        public decimal? ValueNumberLowerBound { get; set; }
        public decimal? ValueNumberUpperBound { get; set; }
        public string[] ValueStringAllowed { get; set; }
    }
}
