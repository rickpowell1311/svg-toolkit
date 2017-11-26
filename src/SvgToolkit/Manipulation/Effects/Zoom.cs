namespace SvgToolkit.Manipulation.Effects
{
    public class Zoom : IEffect
    {
        public decimal Percentage { get; }

        public Zoom(decimal percentage)
        {
            this.Percentage = percentage;
        }

        public void Apply(Svg svg)
        {
            var svgRootElement = svg.GetRootElement();

            var width = svgRootElement.Attribute("width");
            var height = svgRootElement.Attribute("height");

            if (width != null && height != null)
            {
                svgRootElement.SetAttributeValue("width", int.Parse(width.Value) * Percentage);
                svgRootElement.SetAttributeValue("height", int.Parse(height.Value) * Percentage);
            }
        }
    }
}
