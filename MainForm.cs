// Decompiled with JetBrains decompiler
// Type: GuidGenerator.MainForm
// Assembly: GuidGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4D01F6CC-86EF-46D3-A5C5-F256DCDE10DF
// Assembly location: C:\DigitalInstalls\GuidGenerator.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GuidGenerator
{
  public class MainForm : Form
  {
    private List<Guid> _currentGuids = new List<Guid>();
    private List<Guid> _currentGuidCombs = new List<Guid>();
    private GuidFormat _selectedFormat;
    private IContainer components;
    private GroupBox grpFormat;
    private RadioButton rbDashless;
    private RadioButton rbRaw;
    private RadioButton rbTag;
    private RadioButton rbAttribute;
    private RadioButton rbRegistry;
    private GroupBox grpResults;
    private Label lblGuidResult;
    private Button btnRegenerate;
    private Button btnExit;
    private Label lblGuidCombResult;
    private Button btnCopyGuid;
    private ImageList ImageList;
    private Button btnCopyGuidComb;
    private TableLayoutPanel tlpResults;
    private Label label1;
    private Label label2;
    private TableLayoutPanel tlpMultiResults;
    private Label label3;
    private Label label4;
    private TextBox txtGuidCombResults;
    private TextBox txtGuidResults;
    private TabControl tcResults;
    private TabPage tabSingle;
    private TabPage tabMultiple;
    private FlowLayoutPanel flpMultipleCount;
    private Label label5;
    private NumericUpDown nudGuidCount;
    private FlowLayoutPanel flowLayoutPanel2;
    private Button btnCopyGuidCombs;
    private FlowLayoutPanel flowLayoutPanel1;
    private Button btnCopyGuids;

    public MainForm() => this.InitializeComponent();

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.SetupUi();
      this.GenerateGuids();
    }

    private void SetupUi()
    {
      this.rbRaw.Tag = (object) GuidFormat.Raw;
      this.rbRegistry.Tag = (object) GuidFormat.Registry;
      this.rbAttribute.Tag = (object) GuidFormat.Attribute;
      this.rbTag.Tag = (object) GuidFormat.Tag;
      this.rbDashless.Tag = (object) GuidFormat.Dashless;
      this.rbRaw.Checked = true;
      this._selectedFormat = GuidFormat.Raw;
    }

    private void GenerateGuids()
    {
      int num = 1;
      if (this.tcResults.SelectedTab == this.tabMultiple)
        num = (int) this.nudGuidCount.Value;
      this._currentGuids.Clear();
      this._currentGuidCombs.Clear();
      for (int index = 0; index < num; ++index)
      {
        this._currentGuids.Add(MainForm.GenerateStandardGuid());
        this._currentGuidCombs.Add(MainForm.GenerateGuidComb());
        Thread.Sleep(5);
      }
      this.DisplayGuids(this._selectedFormat);
    }

    private void DisplayGuids(GuidFormat format)
    {
      if (this.tcResults.SelectedTab == this.tabSingle)
      {
        this.lblGuidResult.Text = MainForm.FormatGuid(this._currentGuids[0], format);
        this.lblGuidCombResult.Text = MainForm.FormatGuid(this._currentGuidCombs[0], format);
      }
      else
      {
        this.txtGuidResults.Lines = this._currentGuids.Select<Guid, string>((Func<Guid, string>) (guid => MainForm.FormatGuid(guid, format))).ToArray<string>();
        this.txtGuidCombResults.Lines = this._currentGuidCombs.Select<Guid, string>((Func<Guid, string>) (guid => MainForm.FormatGuid(guid, format))).ToArray<string>();
      }
    }

    private static string FormatGuid(Guid guid, GuidFormat format)
    {
      switch (format)
      {
        case GuidFormat.Raw:
          return guid.ToString("D");
        case GuidFormat.Registry:
          return guid.ToString("B");
        case GuidFormat.Attribute:
          return string.Format("[Guid(\"{0:D}\")]", (object) guid);
        case GuidFormat.Tag:
          return string.Format("<Guid(\"{0:D}\")>", (object) guid);
        case GuidFormat.Dashless:
          return guid.ToString("N");
        default:
          return guid.ToString();
      }
    }

    private static Guid GenerateStandardGuid() => Guid.NewGuid();

    private static Guid GenerateGuidComb()
    {
      byte[] byteArray = Guid.NewGuid().ToByteArray();
      DateTime dateTime = new DateTime(1900, 1, 1);
      DateTime now = DateTime.Now;
      TimeSpan timeSpan = new TimeSpan(now.Ticks - dateTime.Ticks);
      TimeSpan timeOfDay = now.TimeOfDay;
      byte[] bytes1 = BitConverter.GetBytes(timeSpan.Days);
      byte[] bytes2 = BitConverter.GetBytes((long) (timeOfDay.TotalMilliseconds / 3.333333));
      Array.Reverse((Array) bytes1);
      Array.Reverse((Array) bytes2);
      Array.Copy((Array) bytes1, bytes1.Length - 2, (Array) byteArray, byteArray.Length - 6, 2);
      Array.Copy((Array) bytes2, bytes2.Length - 4, (Array) byteArray, byteArray.Length - 4, 4);
      return new Guid(byteArray);
    }

    private void FormatRadioClick(object sender, EventArgs e)
    {
      this._selectedFormat = (GuidFormat) ((Control) sender).Tag;
      this.DisplayGuids(this._selectedFormat);
    }

    private void btnCopyGuid_Click(object sender, EventArgs e) => Clipboard.SetText(this.lblGuidResult.Text);

    private void btnCopyGuidComb_Click(object sender, EventArgs e) => Clipboard.SetText(this.lblGuidCombResult.Text);

    private void btnCopyGuids_Click(object sender, EventArgs e) => Clipboard.SetText(this.txtGuidResults.Text);

    private void btnCopyGuidCombs_Click(object sender, EventArgs e) => Clipboard.SetText(this.txtGuidCombResults.Text);

    private void btnRegenerate_Click(object sender, EventArgs e) => this.GenerateGuids();

    private void btnExit_Click(object sender, EventArgs e) => Application.Exit();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.grpFormat = new GroupBox();
      this.rbDashless = new RadioButton();
      this.rbRaw = new RadioButton();
      this.rbTag = new RadioButton();
      this.rbAttribute = new RadioButton();
      this.rbRegistry = new RadioButton();
      this.grpResults = new GroupBox();
      this.tcResults = new TabControl();
      this.tabSingle = new TabPage();
      this.tlpResults = new TableLayoutPanel();
      this.btnCopyGuid = new Button();
      this.ImageList = new ImageList(this.components);
      this.lblGuidCombResult = new Label();
      this.btnCopyGuidComb = new Button();
      this.lblGuidResult = new Label();
      this.label1 = new Label();
      this.label2 = new Label();
      this.tabMultiple = new TabPage();
      this.tlpMultiResults = new TableLayoutPanel();
      this.txtGuidCombResults = new TextBox();
      this.label3 = new Label();
      this.label4 = new Label();
      this.txtGuidResults = new TextBox();
      this.flpMultipleCount = new FlowLayoutPanel();
      this.label5 = new Label();
      this.nudGuidCount = new NumericUpDown();
      this.btnRegenerate = new Button();
      this.btnExit = new Button();
      this.btnCopyGuids = new Button();
      this.btnCopyGuidCombs = new Button();
      this.flowLayoutPanel1 = new FlowLayoutPanel();
      this.flowLayoutPanel2 = new FlowLayoutPanel();
      this.grpFormat.SuspendLayout();
      this.grpResults.SuspendLayout();
      this.tcResults.SuspendLayout();
      this.tabSingle.SuspendLayout();
      this.tlpResults.SuspendLayout();
      this.tabMultiple.SuspendLayout();
      this.tlpMultiResults.SuspendLayout();
      this.flpMultipleCount.SuspendLayout();
      this.nudGuidCount.BeginInit();
      this.flowLayoutPanel1.SuspendLayout();
      this.flowLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      this.grpFormat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFormat.Controls.Add((Control) this.rbDashless);
      this.grpFormat.Controls.Add((Control) this.rbRaw);
      this.grpFormat.Controls.Add((Control) this.rbTag);
      this.grpFormat.Controls.Add((Control) this.rbAttribute);
      this.grpFormat.Controls.Add((Control) this.rbRegistry);
      this.grpFormat.Location = new Point(12, 12);
      this.grpFormat.Name = "grpFormat";
      this.grpFormat.Padding = new Padding(3, 3, 3, 0);
      this.grpFormat.Size = new Size(448, 142);
      this.grpFormat.TabIndex = 0;
      this.grpFormat.TabStop = false;
      this.grpFormat.Text = "GUID Format";
      this.rbDashless.AutoSize = true;
      this.rbDashless.Location = new Point(6, 111);
      this.rbDashless.Name = "rbDashless";
      this.rbDashless.Size = new Size(218, 17);
      this.rbDashless.TabIndex = 4;
      this.rbDashless.Text = "&5. Dashless format: xxxxxxxxxxxx ... xxxxx";
      this.rbDashless.UseVisualStyleBackColor = true;
      this.rbDashless.Click += new EventHandler(this.FormatRadioClick);
      this.rbRaw.AutoSize = true;
      this.rbRaw.Location = new Point(6, 19);
      this.rbRaw.Name = "rbRaw";
      this.rbRaw.Size = new Size(200, 17);
      this.rbRaw.TabIndex = 0;
      this.rbRaw.Tag = (object) "";
      this.rbRaw.Text = "&1. Raw format: xxxxxxxx-xxxx ... xxxxx";
      this.rbRaw.UseVisualStyleBackColor = true;
      this.rbRaw.Click += new EventHandler(this.FormatRadioClick);
      this.rbTag.AutoSize = true;
      this.rbTag.Location = new Point(6, 88);
      this.rbTag.Name = "rbTag";
      this.rbTag.Size = new Size(247, 17);
      this.rbTag.TabIndex = 3;
      this.rbTag.Text = "&4. Tag format: <Guid(\"xxxxxxxx-xxxx ... xxxxx\")>";
      this.rbTag.UseVisualStyleBackColor = true;
      this.rbTag.Click += new EventHandler(this.FormatRadioClick);
      this.rbAttribute.AutoSize = true;
      this.rbAttribute.Location = new Point(6, 65);
      this.rbAttribute.Name = "rbAttribute";
      this.rbAttribute.Size = new Size(261, 17);
      this.rbAttribute.TabIndex = 2;
      this.rbAttribute.Text = "&3. Attribute format: [Guid(\"xxxxxxxx-xxxx ... xxxxx\")]";
      this.rbAttribute.UseVisualStyleBackColor = true;
      this.rbAttribute.Click += new EventHandler(this.FormatRadioClick);
      this.rbRegistry.AutoSize = true;
      this.rbRegistry.Location = new Point(6, 42);
      this.rbRegistry.Name = "rbRegistry";
      this.rbRegistry.Size = new Size(224, 17);
      this.rbRegistry.TabIndex = 1;
      this.rbRegistry.Tag = (object) "";
      this.rbRegistry.Text = "&2. Registry format: {xxxxxxxx-xxxx ... xxxxx}";
      this.rbRegistry.UseVisualStyleBackColor = true;
      this.rbRegistry.Click += new EventHandler(this.FormatRadioClick);
      this.grpResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpResults.Controls.Add((Control) this.tcResults);
      this.grpResults.Location = new Point(12, 160);
      this.grpResults.Name = "grpResults";
      this.grpResults.Padding = new Padding(3, 3, 3, 0);
      this.grpResults.Size = new Size(448, 218);
      this.grpResults.TabIndex = 1;
      this.grpResults.TabStop = false;
      this.grpResults.Text = "&Results";
      this.tcResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcResults.Appearance = TabAppearance.FlatButtons;
      this.tcResults.Controls.Add((Control) this.tabSingle);
      this.tcResults.Controls.Add((Control) this.tabMultiple);
      this.tcResults.Location = new Point(3, 16);
      this.tcResults.Name = "tcResults";
      this.tcResults.SelectedIndex = 0;
      this.tcResults.Size = new Size(442, 199);
      this.tcResults.TabIndex = 0;
      this.tabSingle.Controls.Add((Control) this.tlpResults);
      this.tabSingle.Location = new Point(4, 25);
      this.tabSingle.Name = "tabSingle";
      this.tabSingle.Padding = new Padding(3);
      this.tabSingle.Size = new Size(434, 170);
      this.tabSingle.TabIndex = 0;
      this.tabSingle.Text = "Single";
      this.tabSingle.UseVisualStyleBackColor = true;
      this.tlpResults.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.tlpResults.ColumnCount = 3;
      this.tlpResults.ColumnStyles.Add(new ColumnStyle());
      this.tlpResults.ColumnStyles.Add(new ColumnStyle());
      this.tlpResults.ColumnStyles.Add(new ColumnStyle());
      this.tlpResults.Controls.Add((Control) this.btnCopyGuid, 0, 0);
      this.tlpResults.Controls.Add((Control) this.lblGuidCombResult, 2, 1);
      this.tlpResults.Controls.Add((Control) this.btnCopyGuidComb, 0, 1);
      this.tlpResults.Controls.Add((Control) this.lblGuidResult, 2, 0);
      this.tlpResults.Controls.Add((Control) this.label1, 1, 0);
      this.tlpResults.Controls.Add((Control) this.label2, 1, 1);
      this.tlpResults.Dock = DockStyle.Fill;
      this.tlpResults.Location = new Point(3, 3);
      this.tlpResults.Name = "tlpResults";
      this.tlpResults.RowCount = 3;
      this.tlpResults.RowStyles.Add(new RowStyle());
      this.tlpResults.RowStyles.Add(new RowStyle());
      this.tlpResults.RowStyles.Add(new RowStyle());
      this.tlpResults.Size = new Size(428, 164);
      this.tlpResults.TabIndex = 0;
      this.btnCopyGuid.AutoSize = true;
      this.btnCopyGuid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.btnCopyGuid.FlatStyle = FlatStyle.Popup;
      this.btnCopyGuid.ImageIndex = 0;
      this.btnCopyGuid.ImageList = this.ImageList;
      this.btnCopyGuid.Location = new Point(3, 3);
      this.btnCopyGuid.Name = "btnCopyGuid";
      this.btnCopyGuid.Size = new Size(22, 22);
      this.btnCopyGuid.TabIndex = 0;
      this.btnCopyGuid.UseVisualStyleBackColor = true;
      this.btnCopyGuid.Click += new EventHandler(this.btnCopyGuid_Click);
      this.ImageList.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("ImageList.ImageStream");
      this.ImageList.TransparentColor = Color.Magenta;
      this.ImageList.Images.SetKeyName(0, "Copy.bmp");
      this.lblGuidCombResult.Anchor = AnchorStyles.Left;
      this.lblGuidCombResult.AutoSize = true;
      this.lblGuidCombResult.Location = new Point(103, 35);
      this.lblGuidCombResult.Name = "lblGuidCombResult";
      this.lblGuidCombResult.Size = new Size(91, 13);
      this.lblGuidCombResult.TabIndex = 5;
      this.lblGuidCombResult.Text = "Guid.comb Result";
      this.btnCopyGuidComb.AutoSize = true;
      this.btnCopyGuidComb.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.btnCopyGuidComb.FlatStyle = FlatStyle.Popup;
      this.btnCopyGuidComb.ImageIndex = 0;
      this.btnCopyGuidComb.ImageList = this.ImageList;
      this.btnCopyGuidComb.Location = new Point(3, 31);
      this.btnCopyGuidComb.Name = "btnCopyGuidComb";
      this.btnCopyGuidComb.Size = new Size(22, 22);
      this.btnCopyGuidComb.TabIndex = 3;
      this.btnCopyGuidComb.UseVisualStyleBackColor = true;
      this.btnCopyGuidComb.Click += new EventHandler(this.btnCopyGuidComb_Click);
      this.lblGuidResult.Anchor = AnchorStyles.Left;
      this.lblGuidResult.AutoSize = true;
      this.lblGuidResult.Location = new Point(103, 7);
      this.lblGuidResult.Name = "lblGuidResult";
      this.lblGuidResult.Size = new Size(62, 13);
      this.lblGuidResult.TabIndex = 2;
      this.lblGuidResult.Text = "Guid Result";
      this.label1.Anchor = AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(31, 7);
      this.label1.Name = "label1";
      this.label1.Size = new Size(37, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "GUID:";
      this.label2.Anchor = AnchorStyles.Left;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(31, 35);
      this.label2.Name = "label2";
      this.label2.Size = new Size(66, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "GUID.comb:";
      this.tabMultiple.Controls.Add((Control) this.tlpMultiResults);
      this.tabMultiple.Location = new Point(4, 25);
      this.tabMultiple.Name = "tabMultiple";
      this.tabMultiple.Padding = new Padding(3);
      this.tabMultiple.Size = new Size(434, 170);
      this.tabMultiple.TabIndex = 1;
      this.tabMultiple.Text = "Multiple";
      this.tabMultiple.UseVisualStyleBackColor = true;
      this.tlpMultiResults.ColumnCount = 2;
      this.tlpMultiResults.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tlpMultiResults.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tlpMultiResults.Controls.Add((Control) this.flowLayoutPanel2, 1, 1);
      this.tlpMultiResults.Controls.Add((Control) this.flowLayoutPanel1, 0, 1);
      this.tlpMultiResults.Controls.Add((Control) this.txtGuidCombResults, 1, 2);
      this.tlpMultiResults.Controls.Add((Control) this.txtGuidResults, 0, 2);
      this.tlpMultiResults.Controls.Add((Control) this.flpMultipleCount, 0, 0);
      this.tlpMultiResults.Dock = DockStyle.Fill;
      this.tlpMultiResults.Location = new Point(3, 3);
      this.tlpMultiResults.Name = "tlpMultiResults";
      this.tlpMultiResults.RowCount = 3;
      this.tlpMultiResults.RowStyles.Add(new RowStyle());
      this.tlpMultiResults.RowStyles.Add(new RowStyle());
      this.tlpMultiResults.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tlpMultiResults.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tlpMultiResults.Size = new Size(428, 164);
      this.tlpMultiResults.TabIndex = 4;
      this.txtGuidCombResults.BorderStyle = BorderStyle.FixedSingle;
      this.txtGuidCombResults.Dock = DockStyle.Fill;
      this.txtGuidCombResults.Location = new Point(217, 51);
      this.txtGuidCombResults.Multiline = true;
      this.txtGuidCombResults.Name = "txtGuidCombResults";
      this.txtGuidCombResults.ReadOnly = true;
      this.txtGuidCombResults.Size = new Size(208, 110);
      this.txtGuidCombResults.TabIndex = 4;
      this.txtGuidCombResults.WordWrap = false;
      this.label3.Anchor = AnchorStyles.Left;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(3, 4);
      this.label3.Name = "label3";
      this.label3.Size = new Size(42, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "G&UIDs:";
      this.label4.Anchor = AnchorStyles.Left;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(3, 4);
      this.label4.Name = "label4";
      this.label4.Size = new Size(71, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "GUID.comb&s:";
      this.txtGuidResults.BorderStyle = BorderStyle.FixedSingle;
      this.txtGuidResults.Dock = DockStyle.Fill;
      this.txtGuidResults.Location = new Point(3, 51);
      this.txtGuidResults.Multiline = true;
      this.txtGuidResults.Name = "txtGuidResults";
      this.txtGuidResults.ReadOnly = true;
      this.txtGuidResults.Size = new Size(208, 110);
      this.txtGuidResults.TabIndex = 2;
      this.txtGuidResults.WordWrap = false;
      this.flpMultipleCount.AutoSize = true;
      this.flpMultipleCount.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.tlpMultiResults.SetColumnSpan((Control) this.flpMultipleCount, 2);
      this.flpMultipleCount.Controls.Add((Control) this.label5);
      this.flpMultipleCount.Controls.Add((Control) this.nudGuidCount);
      this.flpMultipleCount.Dock = DockStyle.Fill;
      this.flpMultipleCount.Location = new Point(0, 0);
      this.flpMultipleCount.Margin = new Padding(0);
      this.flpMultipleCount.Name = "flpMultipleCount";
      this.flpMultipleCount.Size = new Size(428, 26);
      this.flpMultipleCount.TabIndex = 0;
      this.label5.Anchor = AnchorStyles.Left;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(3, 6);
      this.label5.Name = "label5";
      this.label5.Size = new Size(41, 13);
      this.label5.TabIndex = 0;
      this.label5.Text = "&Count: ";
      this.nudGuidCount.Location = new Point(50, 3);
      this.nudGuidCount.Minimum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.nudGuidCount.Name = "nudGuidCount";
      this.nudGuidCount.Size = new Size(66, 20);
      this.nudGuidCount.TabIndex = 1;
      this.nudGuidCount.Value = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.btnRegenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRegenerate.Location = new Point(12, 391);
      this.btnRegenerate.Name = "btnRegenerate";
      this.btnRegenerate.Size = new Size(100, 23);
      this.btnRegenerate.TabIndex = 2;
      this.btnRegenerate.Text = "Re&generate";
      this.btnRegenerate.UseVisualStyleBackColor = true;
      this.btnRegenerate.Click += new EventHandler(this.btnRegenerate_Click);
      this.btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnExit.Location = new Point(385, 391);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new Size(75, 23);
      this.btnExit.TabIndex = 3;
      this.btnExit.Text = "E&xit";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new EventHandler(this.btnExit_Click);
      this.btnCopyGuids.AutoSize = true;
      this.btnCopyGuids.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.btnCopyGuids.FlatStyle = FlatStyle.Popup;
      this.btnCopyGuids.ImageIndex = 0;
      this.btnCopyGuids.ImageList = this.ImageList;
      this.btnCopyGuids.Location = new Point(48, 0);
      this.btnCopyGuids.Margin = new Padding(0);
      this.btnCopyGuids.Name = "btnCopyGuids";
      this.btnCopyGuids.Size = new Size(22, 22);
      this.btnCopyGuids.TabIndex = 1;
      this.btnCopyGuids.UseVisualStyleBackColor = true;
      this.btnCopyGuids.Click += new EventHandler(this.btnCopyGuids_Click);
      this.btnCopyGuidCombs.AutoSize = true;
      this.btnCopyGuidCombs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.btnCopyGuidCombs.FlatStyle = FlatStyle.Popup;
      this.btnCopyGuidCombs.ImageIndex = 0;
      this.btnCopyGuidCombs.ImageList = this.ImageList;
      this.btnCopyGuidCombs.Location = new Point(77, 0);
      this.btnCopyGuidCombs.Margin = new Padding(0);
      this.btnCopyGuidCombs.Name = "btnCopyGuidCombs";
      this.btnCopyGuidCombs.Size = new Size(22, 22);
      this.btnCopyGuidCombs.TabIndex = 1;
      this.btnCopyGuidCombs.UseVisualStyleBackColor = true;
      this.btnCopyGuidCombs.Click += new EventHandler(this.btnCopyGuidCombs_Click);
      this.flowLayoutPanel1.AutoSize = true;
      this.flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.flowLayoutPanel1.Controls.Add((Control) this.label3);
      this.flowLayoutPanel1.Controls.Add((Control) this.btnCopyGuids);
      this.flowLayoutPanel1.Location = new Point(0, 26);
      this.flowLayoutPanel1.Margin = new Padding(0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new Size(70, 22);
      this.flowLayoutPanel1.TabIndex = 1;
      this.flowLayoutPanel2.AutoSize = true;
      this.flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.flowLayoutPanel2.Controls.Add((Control) this.label4);
      this.flowLayoutPanel2.Controls.Add((Control) this.btnCopyGuidCombs);
      this.flowLayoutPanel2.Location = new Point(214, 26);
      this.flowLayoutPanel2.Margin = new Padding(0);
      this.flowLayoutPanel2.Name = "flowLayoutPanel2";
      this.flowLayoutPanel2.Size = new Size(99, 22);
      this.flowLayoutPanel2.TabIndex = 3;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(472, 426);
      this.Controls.Add((Control) this.grpResults);
      this.Controls.Add((Control) this.btnExit);
      this.Controls.Add((Control) this.btnRegenerate);
      this.Controls.Add((Control) this.grpFormat);
      this.MaximizeBox = false;
      this.Name = nameof (MainForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "GUID Generator";
      this.Load += new EventHandler(this.MainForm_Load);
      this.grpFormat.ResumeLayout(false);
      this.grpFormat.PerformLayout();
      this.grpResults.ResumeLayout(false);
      this.tcResults.ResumeLayout(false);
      this.tabSingle.ResumeLayout(false);
      this.tlpResults.ResumeLayout(false);
      this.tlpResults.PerformLayout();
      this.tabMultiple.ResumeLayout(false);
      this.tlpMultiResults.ResumeLayout(false);
      this.tlpMultiResults.PerformLayout();
      this.flpMultipleCount.ResumeLayout(false);
      this.flpMultipleCount.PerformLayout();
      this.nudGuidCount.EndInit();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.flowLayoutPanel2.ResumeLayout(false);
      this.flowLayoutPanel2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
