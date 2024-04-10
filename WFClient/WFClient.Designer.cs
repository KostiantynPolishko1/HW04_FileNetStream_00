namespace WFClient
{
    partial class WFClient
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            prBxSelect = new PictureBox();
            lbSizeMb = new Label();
            lbSizeWxH = new Label();
            ((System.ComponentModel.ISupportInitialize)prBxSelect).BeginInit();
            SuspendLayout();
            // 
            // prBxSelect
            // 
            prBxSelect.Location = new Point(190, 10);
            prBxSelect.Name = "prBxSelect";
            prBxSelect.Size = new Size(200, 200);
            prBxSelect.SizeMode = PictureBoxSizeMode.Zoom;
            prBxSelect.TabIndex = 0;
            prBxSelect.TabStop = false;
            // 
            // lbSizeMb
            // 
            lbSizeMb.AutoSize = true;
            lbSizeMb.Location = new Point(190, 220);
            lbSizeMb.Name = "lbSizeMb";
            lbSizeMb.Size = new Size(34, 20);
            lbSizeMb.TabIndex = 1;
            lbSizeMb.Text = "Mb:";
            // 
            // lbSizeWxH
            // 
            lbSizeWxH.AutoSize = true;
            lbSizeWxH.Location = new Point(190, 250);
            lbSizeWxH.Name = "lbSizeWxH";
            lbSizeWxH.Size = new Size(71, 20);
            lbSizeWxH.TabIndex = 2;
            lbSizeWxH.Text = "SizeWxH:";
            // 
            // WFClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 300);
            Controls.Add(lbSizeWxH);
            Controls.Add(lbSizeMb);
            Controls.Add(prBxSelect);
            Name = "WFClient";
            Text = "WFClient";
            ((System.ComponentModel.ISupportInitialize)prBxSelect).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox prBxSelect;
        private Label lbSizeMb;
        private Label lbSizeWxH;
    }
}