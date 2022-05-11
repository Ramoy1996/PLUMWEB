using System.ComponentModel.DataAnnotations.Schema;

namespace PLUMWEB.Data
{
    public class Farmer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string location { get; set; }

        [ForeignKey("ProduceId")]
        public Produce Produce { get; set; }
        public int ProduceId { get; set; }
    }
}
