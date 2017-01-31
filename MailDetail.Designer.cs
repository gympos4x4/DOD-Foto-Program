namespace PhotoMail
{
	partial class MailDetail
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
			this.label1 = new System.Windows.Forms.Label();
			this.tbEMail = new System.Windows.Forms.TextBox();
			this.btnSendMail = new System.Windows.Forms.Button();
			this.tbName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbSchool = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.label1.Location = new System.Drawing.Point(14, 79);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "EMail";
			// 
			// tbEMail
			// 
			this.tbEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.tbEMail.Location = new System.Drawing.Point(77, 76);
			this.tbEMail.Name = "tbEMail";
			this.tbEMail.Size = new System.Drawing.Size(320, 29);
			this.tbEMail.TabIndex = 3;
			// 
			// btnSendMail
			// 
			this.btnSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
			this.btnSendMail.Location = new System.Drawing.Point(18, 111);
			this.btnSendMail.Name = "btnSendMail";
			this.btnSendMail.Size = new System.Drawing.Size(379, 60);
			this.btnSendMail.TabIndex = 4;
			this.btnSendMail.Text = "Pošli E-Mail";
			this.btnSendMail.UseVisualStyleBackColor = true;
			this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
			// 
			// tbName
			// 
			this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.tbName.Location = new System.Drawing.Point(77, 6);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(320, 29);
			this.tbName.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.label5.Location = new System.Drawing.Point(12, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 24);
			this.label5.TabIndex = 9;
			this.label5.Text = "Meno";
			// 
			// tbSchool
			// 
			this.tbSchool.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.tbSchool.Location = new System.Drawing.Point(77, 41);
			this.tbSchool.Name = "tbSchool";
			this.tbSchool.Size = new System.Drawing.Size(320, 29);
			this.tbSchool.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.label4.Location = new System.Drawing.Point(12, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 24);
			this.label4.TabIndex = 7;
			this.label4.Text = "Škola";
			// 
			// MailDetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(423, 191);
			this.Controls.Add(this.btnSendMail);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbSchool);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbEMail);
			this.Name = "MailDetail";
			this.Text = "Mail";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbEMail;
		private System.Windows.Forms.Button btnSendMail;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbSchool;
		private System.Windows.Forms.Label label4;
	}
}

