
namespace pokemon
{
    partial class FinalSummary
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinalSummary));
			this.lblWinLose = new System.Windows.Forms.Label();
			this.listView2 = new System.Windows.Forms.ListView();
			this.lblTotalDamage = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.BtnSave = new System.Windows.Forms.Button();
			this.BtnQuit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblWinLose
			// 
			this.lblWinLose.BackColor = System.Drawing.Color.Transparent;
			this.lblWinLose.Font = new System.Drawing.Font("Impact", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWinLose.ForeColor = System.Drawing.Color.Black;
			this.lblWinLose.Location = new System.Drawing.Point(318, 18);
			this.lblWinLose.Name = "lblWinLose";
			this.lblWinLose.Size = new System.Drawing.Size(305, 106);
			this.lblWinLose.TabIndex = 0;
			this.lblWinLose.Text = "You Won!";
			// 
			// listView2
			// 
			this.listView2.HideSelection = false;
			this.listView2.Location = new System.Drawing.Point(62, 173);
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(813, 361);
			this.listView2.TabIndex = 2;
			this.listView2.UseCompatibleStateImageBehavior = false;
			// 
			// lblTotalDamage
			// 
			this.lblTotalDamage.BackColor = System.Drawing.Color.White;
			this.lblTotalDamage.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalDamage.Location = new System.Drawing.Point(92, 199);
			this.lblTotalDamage.Name = "lblTotalDamage";
			this.lblTotalDamage.Size = new System.Drawing.Size(754, 50);
			this.lblTotalDamage.TabIndex = 3;
			this.lblTotalDamage.Text = "label1";
			// 
			// lblTime
			// 
			this.lblTime.BackColor = System.Drawing.Color.White;
			this.lblTime.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTime.Location = new System.Drawing.Point(92, 249);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(754, 50);
			this.lblTime.TabIndex = 4;
			this.lblTime.Text = "label2";
			// 
			// listView1
			// 
			this.listView1.BackColor = System.Drawing.Color.Gray;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(42, 157);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(851, 392);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// BtnSave
			// 
			this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
			this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSave.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.BtnSave.FlatAppearance.BorderSize = 7;
			this.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
			this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnSave.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnSave.Location = new System.Drawing.Point(229, 425);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(176, 85);
			this.BtnSave.TabIndex = 5;
			this.BtnSave.Text = "Save results and quit";
			this.BtnSave.UseVisualStyleBackColor = false;
			// 
			// BtnQuit
			// 
			this.BtnQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.BtnQuit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnQuit.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
			this.BtnQuit.FlatAppearance.BorderSize = 7;
			this.BtnQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
			this.BtnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnQuit.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnQuit.Location = new System.Drawing.Point(508, 425);
			this.BtnQuit.Name = "BtnQuit";
			this.BtnQuit.Size = new System.Drawing.Size(176, 85);
			this.BtnQuit.TabIndex = 6;
			this.BtnQuit.Text = "Quit without saving";
			this.BtnQuit.UseVisualStyleBackColor = false;
			// 
			// FinalSummary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(933, 579);
			this.Controls.Add(this.BtnQuit);
			this.Controls.Add(this.BtnSave);
			this.Controls.Add(this.lblTime);
			this.Controls.Add(this.lblTotalDamage);
			this.Controls.Add(this.listView2);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.lblWinLose);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FinalSummary";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Final Summary";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWinLose;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.Label lblTotalDamage;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button BtnSave;
		private System.Windows.Forms.Button BtnQuit;
	}
}