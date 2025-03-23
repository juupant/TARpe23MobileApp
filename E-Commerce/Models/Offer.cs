using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Offer
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public Color BgColor { get; set; }
        private static readonly string[] _lightColors = new string[]
        {
            "#E1F1E7","DAD1F9","FFFF00","D0F200","E28083","7FBDC7","EA978D"
        };
        public Offer(string title, string descriotion, string code, Color bgColor)
        {
            Title = title;
            Description = descriotion;
            Code = code;
            BgColor = bgColor;
        }
        private static Color RandomColor => Color.FromHex(_lightColors.OrderBy(c => Guid.NewGuid()).First());
        public static IEnumerable<Offer> GetOffers()
        {
            yield return new Offer("Up to 30% off", "30% off", "30FREE", RandomColor);
            yield return new Offer("Up to 50% off", "50% off", "50FREE", RandomColor);
            yield return new Offer("Up to 100% off", "100% off", "100FREE", RandomColor);
            yield return new Offer("Up to 25% off", "25% off", "25FREE", RandomColor);
        }

    }
}