namespace Win.UI;

partial class MainForm {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lblGenerator = new System.Windows.Forms.Label();
            this.rbRandom = new System.Windows.Forms.RadioButton();
            this.flpGenerator = new System.Windows.Forms.FlowLayoutPanel();
            this.rbComb = new System.Windows.Forms.RadioButton();
            this.rbCombRTL = new System.Windows.Forms.RadioButton();
            this.lblCount = new System.Windows.Forms.Label();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.lblResults = new System.Windows.Forms.Label();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnRegenerate = new System.Windows.Forms.Button();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.btnCopy = new System.Windows.Forms.Button();
            this.flpGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFormat
            // 
            this.cbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFormat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat.Location = new System.Drawing.Point(12, 83);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(429, 24);
            this.cbFormat.TabIndex = 5;
            this.cbFormat.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbFormat_DrawItem);
            this.cbFormat.SelectedIndexChanged += new System.EventHandler(this.cbFormat_SelectedIndexChanged);
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(12, 65);
            this.lblFormat.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(45, 15);
            this.lblFormat.TabIndex = 4;
            this.lblFormat.Text = "&Format";
            // 
            // lblGenerator
            // 
            this.lblGenerator.AutoSize = true;
            this.lblGenerator.Location = new System.Drawing.Point(117, 12);
            this.lblGenerator.Name = "lblGenerator";
            this.lblGenerator.Size = new System.Drawing.Size(59, 15);
            this.lblGenerator.TabIndex = 2;
            this.lblGenerator.Text = "Generator";
            // 
            // rbRandom
            // 
            this.rbRandom.AutoSize = true;
            this.rbRandom.Location = new System.Drawing.Point(214, 3);
            this.rbRandom.Name = "rbRandom";
            this.rbRandom.Size = new System.Drawing.Size(70, 19);
            this.rbRandom.TabIndex = 2;
            this.rbRandom.Text = "&Random";
            this.ttMain.SetToolTip(this.rbRandom, "Non-sequential; entirely random");
            this.rbRandom.UseVisualStyleBackColor = true;
            this.rbRandom.CheckedChanged += new System.EventHandler(this.GeneratorRadio_CheckedChanged);
            // 
            // flpGenerator
            // 
            this.flpGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpGenerator.AutoSize = true;
            this.flpGenerator.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpGenerator.Controls.Add(this.rbComb);
            this.flpGenerator.Controls.Add(this.rbCombRTL);
            this.flpGenerator.Controls.Add(this.rbRandom);
            this.flpGenerator.Location = new System.Drawing.Point(117, 28);
            this.flpGenerator.Name = "flpGenerator";
            this.flpGenerator.Size = new System.Drawing.Size(287, 25);
            this.flpGenerator.TabIndex = 3;
            this.flpGenerator.WrapContents = false;
            // 
            // rbComb
            // 
            this.rbComb.AutoSize = true;
            this.rbComb.Checked = true;
            this.rbComb.Location = new System.Drawing.Point(3, 3);
            this.rbComb.Name = "rbComb";
            this.rbComb.Size = new System.Drawing.Size(89, 19);
            this.rbComb.TabIndex = 0;
            this.rbComb.TabStop = true;
            this.rbComb.Text = "Comb/&Time";
            this.ttMain.SetToolTip(this.rbComb, "Sequential for most DBs");
            this.rbComb.UseVisualStyleBackColor = true;
            this.rbComb.CheckedChanged += new System.EventHandler(this.GeneratorRadio_CheckedChanged);
            // 
            // rbCombRTL
            // 
            this.rbCombRTL.AutoSize = true;
            this.rbCombRTL.Location = new System.Drawing.Point(98, 3);
            this.rbCombRTL.Name = "rbCombRTL";
            this.rbCombRTL.Size = new System.Drawing.Size(110, 19);
            this.rbCombRTL.TabIndex = 1;
            this.rbCombRTL.Text = "Comb/Time RT&L";
            this.ttMain.SetToolTip(this.rbCombRTL, "Sequential for MS SQL Server");
            this.rbCombRTL.UseVisualStyleBackColor = true;
            this.rbCombRTL.CheckedChanged += new System.EventHandler(this.GeneratorRadio_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(12, 12);
            this.lblCount.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(40, 15);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "&Count";
            // 
            // nudCount
            // 
            this.nudCount.AutoSize = true;
            this.nudCount.Location = new System.Drawing.Point(12, 30);
            this.nudCount.MinimumSize = new System.Drawing.Size(72, 0);
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(72, 23);
            this.nudCount.TabIndex = 1;
            this.nudCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCount.ValueChanged += new System.EventHandler(this.nudCount_ValueChanged);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 120);
            this.lblResults.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(39, 15);
            this.lblResults.TabIndex = 6;
            this.lblResults.Text = "&UUIDs";
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(12, 138);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(429, 175);
            this.txtResults.TabIndex = 7;
            this.txtResults.WordWrap = false;
            // 
            // btnRegenerate
            // 
            this.btnRegenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRegenerate.Location = new System.Drawing.Point(12, 326);
            this.btnRegenerate.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnRegenerate.Name = "btnRegenerate";
            this.btnRegenerate.Size = new System.Drawing.Size(75, 23);
            this.btnRegenerate.TabIndex = 9;
            this.btnRegenerate.Text = "R&egenerate";
            this.btnRegenerate.UseVisualStyleBackColor = true;
            this.btnRegenerate.Click += new System.EventHandler(this.btnRegenerate_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.AutoSize = true;
            this.btnCopy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCopy.Image = global::Win.UI.Properties.Resources.CopyHS;
            this.btnCopy.Location = new System.Drawing.Point(57, 116);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(22, 22);
            this.btnCopy.TabIndex = 8;
            this.ttMain.SetToolTip(this.btnCopy, "Copy UUIDs");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 361);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnRegenerate);
            this.Controls.Add(this.lblGenerator);
            this.Controls.Add(this.flpGenerator);
            this.Controls.Add(this.cbFormat);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.nudCount);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 0);
            this.Name = "MainForm";
            this.Text = "UUID Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.flpGenerator.ResumeLayout(false);
            this.flpGenerator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private ComboBox cbFormat;
    private Label lblFormat;
    private Label lblGenerator;
    private FlowLayoutPanel flpGenerator;
    private RadioButton rbRandom;
    private RadioButton rbComb;
    private Label lblCount;
    private NumericUpDown nudCount;
    private Label lblResults;
    private TextBox txtResults;
    private Button btnRegenerate;
    private RadioButton rbCombRTL;
    private ToolTip ttMain;
    private Button btnCopy;
}
