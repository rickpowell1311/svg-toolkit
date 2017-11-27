using System.Xml.Linq;

namespace SvgToolkit.Manipulation.Effects.Utilities
{
    internal class SvgFilterGroup
    {
        private readonly XElement _filterContainer;
        private readonly SvgGuid _filterId;

        private XElement _filterElement;

        public SvgFilterGroup()
        {
            _filterId = SvgGuid.NewGuid();

            _filterContainer = new XElement("filter");
            _filterContainer.SetAttributeValue("id", _filterId);
        }

        public void SetFilter(XElement filter)
        {
            _filterElement = filter;
        }

        public void AddToSvg(Svg svg)
        {
            if (_filterElement != null)
            {
                _filterContainer.Add(_filterElement);

                var currentGroupElement = svg.GetRootElement().Element("g");
                currentGroupElement.SetAttributeValue("filter", $"url(#{_filterId.ToString()})");

                var newOuterGroup = new XElement("g");
                newOuterGroup.Add(_filterContainer);
                newOuterGroup.Add(currentGroupElement);

                var root = svg.GetRootElement();
                root.ReplaceNodes(newOuterGroup);
            }
        }
    }
}
