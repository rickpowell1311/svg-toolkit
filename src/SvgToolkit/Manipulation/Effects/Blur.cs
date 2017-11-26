using System;
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
            var filterId = new SvgGuid(Guid.NewGuid());

            var filterElement = new XElement("filter");
            filterElement.SetAttributeValue("id", filterId);

            var blur = new XElement("feGaussianBlur");
            blur.SetAttributeValue("in", "SourceGraphic");
            blur.SetAttributeValue("stdDeviation", percentage * 100);

            filterElement.Add(blur);

            var outerGroup = svg.GetRootElement().Element("g");
            outerGroup.SetAttributeValue("filter", $"url(#{filterId})");

            var newOuterGroup = new XElement("g");
            newOuterGroup.Add(filterElement);
            newOuterGroup.Add(outerGroup);

            var root = svg.GetRootElement();
            root.ReplaceNodes(newOuterGroup);

            svg.OverrideXElement(root);
        }
    }
}
