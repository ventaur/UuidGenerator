namespace Win.UI.Formatting;
internal class RegistryUuidFormatter : IUuidFormatter {
    public string Format(Guid value) => value.ToString("B");
}
