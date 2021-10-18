namespace IsolateStorageSmpl
{
	partial class frmDSSample
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
			this.btnBackColor = new System.Windows.Forms.Button();
			this.txtSampleData = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.cdBackground = new System.Windows.Forms.ColorDialog();
			this.SuspendLayout();
			// 
			// btnBackColor
			// 
			this.btnBackColor.Location = new System.Drawing.Point(12, 29);
			this.btnBackColor.Name = "btnBackColor";
			this.btnBackColor.Size = new System.Drawing.Size(123, 62);
			this.btnBackColor.TabIndex = 0;
			this.btnBackColor.Text = "Задать цвет фона";
			this.btnBackColor.UseVisualStyleBackColor = true;
			this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
			// 
			// txtSampleData
			// 
			this.txtSampleData.Location = new System.Drawing.Point(12, 112);
			this.txtSampleData.Multiline = true;
			this.txtSampleData.Name = "txtSampleData";
			this.txtSampleData.Size = new System.Drawing.Size(260, 67);
			this.txtSampleData.TabIndex = 1;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(149, 185);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(123, 50);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Сохранить настройки";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(12, 185);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(123, 50);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Настройки по умолчанию";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// frmDSSample
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.txtSampleData);
			this.Controls.Add(this.btnBackColor);
			this.Name = "frmDSSample";
			this.Text = "Isolated Storage";
			
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnBackColor;
		private System.Windows.Forms.TextBox txtSampleData;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.ColorDialog cdBackground;
	}
}

