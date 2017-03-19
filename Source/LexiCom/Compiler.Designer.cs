namespace LexiCom
{
    partial class Militari
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LexGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexeme_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LexButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SynButton = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Syntax_Output = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LexPanel = new System.Windows.Forms.Panel();
            this.Code = new Lexicom.WinForms.RichTextBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.LexGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.LexPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LexGrid
            // 
            this.LexGrid.AllowUserToAddRows = false;
            this.LexGrid.AllowUserToDeleteRows = false;
            this.LexGrid.AllowUserToResizeColumns = false;
            this.LexGrid.AllowUserToResizeRows = false;
            this.LexGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LexGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.LexGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LexGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Lexeme_col,
            this.Token_col});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LexGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.LexGrid.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LexGrid.Location = new System.Drawing.Point(3, 27);
            this.LexGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LexGrid.Name = "LexGrid";
            this.LexGrid.ReadOnly = true;
            this.LexGrid.RowHeadersVisible = false;
            this.LexGrid.Size = new System.Drawing.Size(251, 246);
            this.LexGrid.TabIndex = 1;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // Lexeme_col
            // 
            this.Lexeme_col.HeaderText = "Lexeme";
            this.Lexeme_col.Name = "Lexeme_col";
            this.Lexeme_col.ReadOnly = true;
            // 
            // Token_col
            // 
            this.Token_col.HeaderText = "Token";
            this.Token_col.Name = "Token_col";
            this.Token_col.ReadOnly = true;
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.SystemColors.ControlText;
            this.Output.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output.ForeColor = System.Drawing.Color.Lime;
            this.Output.Location = new System.Drawing.Point(12, 368);
            this.Output.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(342, 134);
            this.Output.TabIndex = 3;
            this.Output.Text = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(0, 506);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(1247, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "version 1.0 (Beta Version) | Canaria | Quinit | Dinglasan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "Execute Program";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LexButton,
            this.toolStripSeparator1,
            this.SynButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 45);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1247, 66);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LexButton
            // 
            this.LexButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LexButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.LexButton.Image = global::Militari.Properties.Resources.Lexical1;
            this.LexButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LexButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LexButton.Name = "LexButton";
            this.LexButton.Size = new System.Drawing.Size(56, 63);
            this.LexButton.Text = "LEXICAL";
            this.LexButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LexButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.LexButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LexButton.Click += new System.EventHandler(this.LexButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 66);
            // 
            // SynButton
            // 
            this.SynButton.Enabled = false;
            this.SynButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SynButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.SynButton.Image = global::Militari.Properties.Resources.Syntax1;
            this.SynButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SynButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SynButton.Name = "SynButton";
            this.SynButton.Size = new System.Drawing.Size(56, 63);
            this.SynButton.Text = "SYNTAX";
            this.SynButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SynButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SynButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Black Ops One", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1247, 45);
            this.label2.TabIndex = 5;
            this.label2.Text = "Militari Compiler";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.count,
            this.Error,
            this.Line});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(360, 368);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(870, 134);
            this.dataGridView1.TabIndex = 12;
            // 
            // count
            // 
            this.count.HeaderText = "id";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // Error
            // 
            this.Error.HeaderText = "Syntax Error";
            this.Error.Name = "Error";
            this.Error.ReadOnly = true;
            this.Error.Width = 627;
            // 
            // Line
            // 
            this.Line.HeaderText = "Line";
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            // 
            // Syntax_Output
            // 
            this.Syntax_Output.BackColor = System.Drawing.SystemColors.ControlText;
            this.Syntax_Output.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Syntax_Output.ForeColor = System.Drawing.Color.Lime;
            this.Syntax_Output.Location = new System.Drawing.Point(360, 386);
            this.Syntax_Output.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Syntax_Output.Name = "Syntax_Output";
            this.Syntax_Output.ReadOnly = true;
            this.Syntax_Output.Size = new System.Drawing.Size(700, 116);
            this.Syntax_Output.TabIndex = 11;
            this.Syntax_Output.Text = "";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkCyan;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(479, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "LEXICAL ANALYZER";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LexPanel
            // 
            this.LexPanel.Controls.Add(this.LexGrid);
            this.LexPanel.Controls.Add(this.label3);
            this.LexPanel.Location = new System.Drawing.Point(973, 87);
            this.LexPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LexPanel.Name = "LexPanel";
            this.LexPanel.Size = new System.Drawing.Size(257, 273);
            this.LexPanel.TabIndex = 9;
            this.LexPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LexPanel_Paint);
            // 
            // Code
            // 
            this.Code.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Code.Location = new System.Drawing.Point(12, 113);
            this.Code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Code.Name = "Code";
            this.Code.NumberAlignment = System.Drawing.StringAlignment.Near;
            this.Code.NumberBackground1 = System.Drawing.SystemColors.ControlLight;
            this.Code.NumberBackground2 = System.Drawing.SystemColors.Window;
            this.Code.NumberBorder = System.Drawing.SystemColors.ActiveCaption;
            this.Code.NumberBorderThickness = 0F;
            this.Code.NumberColor = System.Drawing.Color.DarkGreen;
            this.Code.NumberFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Code.NumberLeadingZeroes = false;
            this.Code.NumberLineCounting = Lexicom.WinForms.RichTextBoxEx.LineCounting.CRLF;
            this.Code.NumberPadding = 2;
            this.Code.ShowLineNumbers = true;
            this.Code.Size = new System.Drawing.Size(955, 247);
            this.Code.TabIndex = 6;
            this.Code.Text = "";
            // 
            // Militari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1247, 532);
            this.Controls.Add(this.LexPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Syntax_Output);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Militari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MILITARI_MISSION";
            this.Load += new System.EventHandler(this.LexiCom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LexGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.LexPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView LexGrid;
        private System.Windows.Forms.RichTextBox Output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexeme_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token_col;
        private Lexicom.WinForms.RichTextBoxEx Code;
        private System.Windows.Forms.ToolStripButton LexButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton SynButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox Syntax_Output;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.Panel LexPanel;
        private System.Windows.Forms.Label label3;
    }
}

