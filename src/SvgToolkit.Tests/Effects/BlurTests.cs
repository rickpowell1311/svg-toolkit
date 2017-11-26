using SvgToolkit.Manipulation;
using SvgToolkit.Manipulation.Effects;
using System.Xml.Linq;
using Xunit;

namespace SvgToolkit.Tests.Effects
{
    public class BlurTests
    {
        [Fact]
        public void Blur_WithFiftyPercent_CanAddFilter()
        {
            var originalSvg = "<svg width=\"100\" height=\"200}\"><rect width=\"90\" height=\"90\" fill=\"green\" /></svg>";
            var svgElement = XElement.Parse(originalSvg);
            var svg = new Svg(svgElement);

            svg.ApplyEffect(new Blur(50));

            var result = svg.ToString();
        }
    }
}
