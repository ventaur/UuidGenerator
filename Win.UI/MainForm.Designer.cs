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
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbFormat
            // 
            this.cbFormat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Location = new System.Drawing.Point(12, 12);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(424, 24);
            this.cbFormat.TabIndex = 0;
            this.cbFormat.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbFormat_DrawItem);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbFormat);
            this.Name = "MainForm";
            this.Text = "UUID Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

    }

    #endregion

    private ComboBox cbFormat;
}
