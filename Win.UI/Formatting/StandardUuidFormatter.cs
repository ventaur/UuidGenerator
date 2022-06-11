namespace Win.UI.Formatting;
internal class StandardUuidFormatter : IUuidFormatter {
    public string Format(Guid value) => value.ToString("D");
}
