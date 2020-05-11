namespace CafeManagerDestopApp
{
    partial class TableManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableList = new System.Windows.Forms.TableLayoutPanel();
            this.tableDetail1 = new CafeManagerDestopApp.TableDetail();
            this.SuspendLayout();
            // 
            // tableList
            // 
            this.tableList.AutoScroll = true;
            this.tableList.BackColor = System.Drawing.Color.Transparent;
            this.tableList.ColumnCount = 5;
            this.tableList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableList.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableList.Location = new System.Drawing.Point(0, 0);
            this.tableList.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tableList.Name = "tableList";
            this.tableList.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tableList.RowCount = 5;
            this.tableList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableList.Size = new System.Drawing.Size(905, 832);
            this.tableList.TabIndex = 0;
            // 
            // tableDetail1
            // 
            this.tableDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableDetail1.Location = new System.Drawing.Point(905, 0);
            this.tableDetail1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableDetail1.Name = "tableDetail1";
            this.tableDetail1.Size = new System.Drawing.Size(882, 832);
            this.tableDetail1.TabIndex = 1;
            // 
            // TableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableDetail1);
            this.Controls.Add(this.tableList);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TableManager";
            this.Size = new System.Drawing.Size(1787, 832);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableList;
        private TableDetail tableDetail1;
    }
}
