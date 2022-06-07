namespace Win.UI.Formatting;
internal class AttributeUuidFormatter : IUuidFormatter {
    public string Format(Guid value) => string.Format("[Guid(\"{0:D}\")]", value);
}
