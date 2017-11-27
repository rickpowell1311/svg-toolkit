using SvgToolkit.Manipulation.Effects.Utilities;
using System.Xml.Linq;

namespace SvgToolkit.Manipulation.Effects
{
    public class Blur : IEffect
    {
        private readonly decimal percentage;

        public Blur(decimal percentage)
        {
            this.percentage = percentage;
        }

        public void Apply(Svg svg)
        {
            var filterId = SvgGuid.NewGuid();

            var blur = new XElement("feGaussianBlur");
            blur.SetAttributeValue("in", "SourceGraphic");
            blur.SetAttributeValue("stdDeviation", percentage * 100);

            var filterGroup = new SvgFilterGroup();
            filterGroup.SetFilter(blur);
            filterGroup.AddToSvg(svg);
        }
    }
}
