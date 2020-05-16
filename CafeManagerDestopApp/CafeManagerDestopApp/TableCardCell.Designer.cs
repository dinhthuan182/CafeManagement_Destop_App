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
            this.lbl_table_name = new System.Windows.Forms.Label();
            this.corner_radius_table_card = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.img_state = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.img_state)).BeginInit();
            this.SuspendLayout();
            // 
            // border_table_card
            // 
            this.border_table_card.Fixed = true;
            this.border_table_card.Horizontal = true;
            this.border_table_card.TargetControl = this.lbl_table_name;
            this.border_table_card.Vertical = true;
            // 
            // lbl_table_name
            // 
            this.lbl_table_name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_table_name.Font = new System.Drawing.Font("Segoe UI", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_table_name.ForeColor = System.Drawing.Color.Black;
            this.lbl_table_name.Location = new System.Drawing.Point(36, 10);
            this.lbl_table_name.Name = "lbl_table_name";
            this.lbl_table_name.Size = new System.Drawing.Size(75, 46);
            this.lbl_table_name.TabIndex = 1;
            this.lbl_table_name.Text = "20";
            this.lbl_table_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_table_name.Click += new System.EventHandler(this.lbl_table_name_Click);
            // 
            // corner_radius_table_card
            // 
            this.corner_radius_table_card.ElipseRadius = 10;
            this.corner_radius_table_card.TargetControl = this.lbl_table_name;
            // 
            // img_state
            // 
            this.img_state.Dock = System.Windows.Forms.DockStyle.Fill;
            this.img_state.Image = ((System.Drawing.Image)(resources.GetObject("img_state.Image")));
            this.img_state.Location = new System.Drawing.Point(0, 0);
            this.img_state.Name = "img_state";
            this.img_state.Size = new System.Drawing.Size(146, 144);
            this.img_state.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_state.TabIndex = 0;
            this.img_state.TabStop = false;
            this.img_state.Click += new System.EventHandler(this.img_state_Click);
            // 
            // TableCardCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbl_table_name);
            this.Controls.Add(this.img_state);
            this.Name = "TableCardCell";
            this.Size = new System.Drawing.Size(146, 144);
            ((System.ComponentModel.ISupportInitialize)(this.img_state)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl border_table_card;
        private Bunifu.Framework.UI.BunifuElipse corner_radius_table_card;
        private System.Windows.Forms.PictureBox img_state;
        private System.Windows.Forms.Label lbl_table_name;
    }
}
