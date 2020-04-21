namespace WindowsFormsApplication1
{
    partial class QuotationAdd
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cus_id = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vir_id = new System.Windows.Forms.TextBox();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cus_id);
            this.groupBox8.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(243, 13);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(225, 62);
            this.groupBox8.TabIndex = 35;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "ลูกค้า";
            // 
            // cus_id
            // 
            this.cus_id.FormattingEnabled = true;
            this.cus_id.Location = new System.Drawing.Point(6, 22);
            this.cus_id.Name = "cus_id";
            this.cus_id.Size = new System.Drawing.Size(212, 34);
            this.cus_id.TabIndex = 3;
            this.cus_id.Text = "กรุณาเลือก";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vir_id);
            this.groupBox2.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 63);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "เลขที่";
            // 
            // vir_id
            // 
            this.vir_id.Enabled = false;
            this.vir_id.Location = new System.Drawing.Point(6, 23);
            this.vir_id.MaxLength = 255;
            this.vir_id.Name = "vir_id";
            this.vir_id.Size = new System.Drawing.Size(213, 34);
            this.vir_id.TabIndex = 1;
            // 
            // QuotationAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox8);
            this.Name = "QuotationAdd";
            this.Text = "QuotationAdd";
            this.Load += new System.EventHandler(this.QuotationAdd_Load);
            this.groupBox8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox cus_id;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox vir_id;
    }
}