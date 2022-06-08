using Win.UI.Formatting;

namespace Win.UI;

public partial class MainForm : Form {
    int _maxNameWidth;


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
}
