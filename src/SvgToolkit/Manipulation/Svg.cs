using SvgToolkit.Manipulation.Effects;
using System;
using System.Xml.Linq;

namespace SvgToolkit.Manipulation
{
    public class Svg
    {
        private XElement svgElement;

        public Svg(XElement svgElement)
        {
            this.svgElement = svgElement;

            // Group all inner elements for manipulation
            var svgContents = svgElement.Elements();
            var svgContentsGroupWrapper = new XElement("g", svgContents);

            var newSvgElement = svgElement;
            newSvgElement.ReplaceNodes(svgContentsGroupWrapper);
        }

        internal XElement GetRootElement()
        {
            return svgElement;
        }

        public void ApplyEffect<T>(T effect) where T : IEffect
        {
            effect.Apply(this);
        }

        internal void OverrideXElement(XElement svgElement)
        {
            this.svgElement = svgElement;
        }

        public override string ToString()
        {
            var appendedHeader = @"<?xml version=""1.0"" encoding=""utf-8""?>";

            return $"{ appendedHeader }\r\n{svgElement.ToString(SaveOptions.None)}";
        }
    }
}
