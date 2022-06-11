using Win.UI.Formatting;

namespace Win.UI;

public partial class MainForm : Form {
    int _maxNameWidth;
    UuidGenerator _selectedGenerator;
    IList<Guid> _uuids = new List<Guid>();


    public MainForm() {
        InitializeComponent();
    }

    private int CalculateMaxNameWidth(List<UuidFormat> allFormats) {
        int maxNameWidth = 0;

        using var graphics = cbFormat.CreateGraphics();
        foreach (var format in allFormats) {
            var size = graphics.MeasureString(format.Name, cbFormat.Font);
            maxNameWidth = Math.Max(maxNameWidth, (int)size.Width);
        }

        return maxNameWidth;
    }

    private void MainForm_Load(object sender, EventArgs e) {
        var allFormats = UuidFormat.List.OrderBy(f => f.Value).ToList();

        _maxNameWidth = CalculateMaxNameWidth(allFormats);

        cbFormat.DataSource = allFormats;
        cbFormat.DisplayMember = nameof(UuidFormat.Name);
        cbFormat.ValueMember = nameof(UuidFormat.Value);

        rbComb.Tag = UuidGenerator.CombTime;
        rbCombRTL.Tag = UuidGenerator.CombTimeRTL;
        rbRandom.Tag = UuidGenerator.Random;
        _selectedGenerator = UuidGenerator.CombTime;

        GenerateUuids(true);
    }
    
    private void cbFormat_DrawItem(object sender, DrawItemEventArgs e) {
        var uuidFormat = (UuidFormat)cbFormat.Items[e.Index];

        e.DrawBackground();

        var x = e.Bounds.X;
        var y = e.Bounds.Y;
        var width = e.Bounds.Width;
        var height = e.Bounds.Height;

        var nameRect = new Rectangle(x, y, _maxNameWidth, height);
        var exampleRect = new Rectangle(_maxNameWidth, y, width - _maxNameWidth, height);

        using var brush = new SolidBrush(e.ForeColor);
        e.Graphics.DrawString(uuidFormat.Name, e.Font ?? Font, brush, nameRect);
        e.Graphics.DrawString($":  {uuidFormat.Example}", e.Font ?? Font, brush, exampleRect);
    }

    private void nudCount_ValueChanged(object sender, EventArgs e) {
        GenerateUuids(false);
    }

    private void GeneratorRadio_CheckedChanged(object sender, EventArgs e) {
        var control = (Control)sender;
        _selectedGenerator = (UuidGenerator)control.Tag;
        GenerateUuids(true);
    }

    private void cbFormat_SelectedIndexChanged(object sender, EventArgs e) {
        DisplayUuids();
    }

    private void btnRegenerate_Click(object sender, EventArgs e) {
        GenerateUuids(true);
    }

    private void GenerateUuids(bool regenerate) {
        var count = (int)nudCount.Value;
        
        if (regenerate) {
            _uuids.Clear();
        }

        if (_uuids.Count == count) return;

        // Trim the list.
        if (_uuids.Count > count) {
            _uuids = new List<Guid>(_uuids.Take(count));
            return;
        }

        // Add newly-generated UUIDs to the list.
        for (int i = _uuids.Count; i < count; i++) {
            _uuids.Add(_selectedGenerator.Generate());
        }

        DisplayUuids();
    }

    private void DisplayUuids() {
        var format = (UuidFormat)cbFormat.SelectedItem;
        txtResults.Lines = _uuids.Select(uuid => format.Format(uuid)).ToArray();
    }
}
