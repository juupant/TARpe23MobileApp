using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Api.Data.Entities
{
    [Table(nameof(Offer))]
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [Required, MaxLength(250)]
        public string Description { get; set; }
        [Required, MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(10)]
        public string BgColor { get; set; }
        public bool IsActive { get; set; }
        public Offer(int id, string title, string description, string code, string bgColor) : this()
        {
            Id = id;
            Title = title;
            Description = description;
            Code = code;
            BgColor = bgColor;
        }
        public Offer()
        {
        }
        private static readonly string[] _lightColors = new string[]
        {
            "#E1F1E7","DAD1F9","FFFF00","D0F200","E28083","7FBDC7","EA978D"
        };
        private static string RandomColor => _lightColors.OrderBy(c => Guid.NewGuid()).First();
        public static IEnumerable<Offer> GetInitialData()
        {
            return new List<Offer>() {
                new Offer(1,"Up to 30% off", "30% off", "30FREE", RandomColor),
                new Offer(2,"Up to 50% off", "50% off", "50FREE", RandomColor),
                new Offer(3,"Up to 100% off", "100% off", "100FREE", RandomColor),
                new Offer(4,"Up to 25% off", "25% off", "25FREE", RandomColor)
            };
        }
    }
}