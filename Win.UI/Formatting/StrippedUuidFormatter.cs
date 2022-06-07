namespace Win.UI.Formatting;
internal class StrippedUuidFormatter : IUuidFormatter {
    public string Format(Guid value) => value.ToString("N");
}
