using Ardalis.SmartEnum;

namespace Win.UI.Formatting;
internal sealed class UuidFormat : SmartEnum<UuidFormat> {
    public static readonly UuidFormat Standard = new UuidFormat(nameof(Standard), 1, new StandardUuidFormatter(), "780bfdd6-239a-416e-bc86-72671661ef67");
    public static readonly UuidFormat Registry = new UuidFormat(nameof(Registry), 2, new RegistryUuidFormatter(), "{780bfdd6-239a-416e-bc86-72671661ef67}");
    public static readonly UuidFormat Attribute = new UuidFormat(nameof(Attribute), 3, new AttributeUuidFormatter(), "[Guid(\"780bfdd6-239a-416e-bc86-72671661ef67\")]");
    public static readonly UuidFormat Tag = new UuidFormat(nameof(Tag), 4, new TagUuidFormatter(), "<Guid(\"780bfdd6-239a-416e-bc86-72671661ef67\")>");
    public static readonly UuidFormat Stripped = new UuidFormat(nameof(Stripped), 5, new StrippedUuidFormatter(), "780bfdd6239a416ebc8672671661ef67");


    private IUuidFormatter _formatter;

    public string Example { get; }

    private UuidFormat(string name, int value, IUuidFormatter formatter, string example) : base(name, value) {
        _formatter = formatter;
        Example = example;
    }

    public string Format(Guid value) => _formatter.Format(value);
}
