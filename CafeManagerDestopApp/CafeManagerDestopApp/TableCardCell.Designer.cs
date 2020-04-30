namespace CafeManagerDestopApp
{
    partial class TableCardCell
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableCardCell));
            this.border_table_card = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.lbl_table_number = new System.Windows.Forms.Label();
            this.corner_radius_table_card = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // border_table_card
            // 
            this.border_table_card.Fixed = true;
            this.border_table_card.Horizontal = true;
            this.border_table_card.TargetControl = this.lbl_table_number;
            this.border_table_card.Vertical = true;
            // 
            // lbl_table_number
            // 
            this.lbl_table_number.BackColor = System.Drawing.Color.Transparent;
            this.lbl_table_number.Font = new System.Drawing.Font("Segoe UI", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_table_number.ForeColor = System.Drawing.Color.Black;
            this.lbl_table_number.Location = new System.Drawing.Point(42, 10);
            this.lbl_table_number.Name = "lbl_table_number";
            this.lbl_table_number.Size = new System.Drawing.Size(65, 50);
            this.lbl_table_number.TabIndex = 1;
            this.lbl_table_number.Text = "20";
            // 
            // corner_radius_table_card
            // 
            this.corner_radius_table_card.ElipseRadius = 10;
            this.corner_radius_table_card.TargetControl = this.lbl_table_number;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TableCardCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbl_table_number);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TableCardCell";
            this.Size = new System.Drawing.Size(146, 144);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl border_table_card;
        private Bunifu.Framework.UI.BunifuElipse corner_radius_table_card;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_table_number;
    }
}
