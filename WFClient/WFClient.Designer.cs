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
            btnSelect = new Button();
            btnSend = new Button();
            lbName = new Label();
            openFileDialogImg = new OpenFileDialog();
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
            lbSizeMb.Location = new Point(190, 250);
            lbSizeMb.Name = "lbSizeMb";
            lbSizeMb.Size = new Size(34, 20);
            lbSizeMb.TabIndex = 1;
            lbSizeMb.Text = "Mb:";
            // 
            // lbSizeWxH
            // 
            lbSizeWxH.AutoSize = true;
            lbSizeWxH.Location = new Point(190, 280);
            lbSizeWxH.Name = "lbSizeWxH";
            lbSizeWxH.Size = new Size(71, 20);
            lbSizeWxH.TabIndex = 2;
            lbSizeWxH.Text = "SizeWxH:";
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(10, 10);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(90, 30);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "SELECT";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnSend
            // 
            btnSend.Enabled = false;
            btnSend.Location = new Point(10, 50);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(90, 30);
            btnSend.TabIndex = 4;
            btnSend.Text = "SEND";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(190, 220);
            lbName.Name = "lbName";
            lbName.Size = new Size(49, 20);
            lbName.TabIndex = 5;
            lbName.Text = "Name";
            // 
            // openFileDialogImg
            // 
            openFileDialogImg.FileName = "openFileDialogImg";
            // 
            // WFClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 310);
            Controls.Add(lbName);
            Controls.Add(btnSend);
            Controls.Add(btnSelect);
            Controls.Add(lbSizeWxH);
            Controls.Add(lbSizeMb);
            Controls.Add(prBxSelect);
            Name = "WFClient";
            Text = "WFClient";
            FormClosed += WFClient_FormClosed;
            ((System.ComponentModel.ISupportInitialize)prBxSelect).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox prBxSelect;
        private Label lbSizeMb;
        private Label lbSizeWxH;
        private Button btnSelect;
        private Button btnSend;
        private Label lbName;
        private OpenFileDialog openFileDialogImg;
    }
}