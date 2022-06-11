namespace Win.UI.Formatting;
internal class TagUuidFormatter : IUuidFormatter {
    public string Format(Guid value) => string.Format("<Guid(\"{0:D}\")>", value);
}
