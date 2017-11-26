using SvgToolkit.Manipulation;
using SvgToolkit.Manipulation.Effects;
using SvgToolkit.Tests.Utilities;
using System.Xml.Linq;
using Xunit;

namespace SvgToolkit.Tests.Effects
{
    public class ZoomTests
    {
        [Fact]
        public void Zoom_WithTwoHundredPercent_DoublesWidthAndHeightValues()
        {
            var originalWidth = 100;
            var originalHeight = 150;

            var originalSvg = $"<svg width=\"{originalWidth}\" height=\"{originalHeight}\"></svg>";
            var svgElement = XElement.Parse(originalSvg);
            var svg = new Svg(svgElement);

            var zoom = new Zoom(2);
            zoom.Apply(svg);

            var modifiedSvg = svg.ToString();

            var expectedSvg = new Svg(
                XElement.Parse($"<svg width=\"{originalWidth * zoom.Percentage}\" height=\"{originalHeight * zoom.Percentage}\"></svg>"))
                .ToString();

            Assert.Equal(new MinifiedString(expectedSvg), new MinifiedString(modifiedSvg));
        }
    }
}
