namespace WindowsFormsApplication1
{
    partial class SparesAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SparesAdd));
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spares_qty = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.spares_unit = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spares_name = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.spares_cost_price = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.spares_unit_price = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.spares_detail = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Crimson;
            this.btn_delete.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(555, 161);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(123, 34);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "ลบข้อมูล";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_save.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(555, 81);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(123, 34);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "บันทึก";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click_1);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Orange;
            this.btn_close.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(555, 121);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(123, 34);
            this.btn_close.TabIndex = 9;
            this.btn_close.Text = "ยกเลิก";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spares_qty);
            this.groupBox2.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(30, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 63);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "จำนวนคงเหลือ *";
            // 
            // spares_qty
            // 
            this.spares_qty.Location = new System.Drawing.Point(6, 23);
            this.spares_qty.MaxLength = 10;
            this.spares_qty.Name = "spares_qty";
            this.spares_qty.Size = new System.Drawing.Size(213, 34);
            this.spares_qty.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.spares_unit);
            this.groupBox3.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(299, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 62);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "หน่วยนับ *";
            // 
            // spares_unit
            // 
            this.spares_unit.Location = new System.Drawing.Point(6, 21);
            this.spares_unit.MaxLength = 100;
            this.spares_unit.Name = "spares_unit";
            this.spares_unit.Size = new System.Drawing.Size(213, 34);
            this.spares_unit.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.spares_name);
            this.groupBox1.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 63);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ชื่ออะไหล่ *";
            // 
            // spares_name
            // 
            this.spares_name.Location = new System.Drawing.Point(6, 23);
            this.spares_name.MaxLength = 100;
            this.spares_name.Name = "spares_name";
            this.spares_name.Size = new System.Drawing.Size(213, 34);
            this.spares_name.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.spares_cost_price);
            this.groupBox6.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(30, 100);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(225, 62);
            this.groupBox6.TabIndex = 32;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ราคาต้นทุน *";
            // 
            // spares_cost_price
            // 
            this.spares_cost_price.Location = new System.Drawing.Point(6, 21);
            this.spares_cost_price.MaxLength = 10;
            this.spares_cost_price.Name = "spares_cost_price";
            this.spares_cost_price.Size = new System.Drawing.Size(213, 34);
            this.spares_cost_price.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.spares_unit_price);
            this.groupBox4.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(299, 100);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 62);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ราคาขาย *";
            // 
            // spares_unit_price
            // 
            this.spares_unit_price.Location = new System.Drawing.Point(6, 21);
            this.spares_unit_price.MaxLength = 10;
            this.spares_unit_price.Name = "spares_unit_price";
            this.spares_unit_price.Size = new System.Drawing.Size(213, 34);
            this.spares_unit_price.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.spares_detail);
            this.groupBox5.Font = new System.Drawing.Font("Angsana New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(299, 30);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(225, 63);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "รายละเอียด *";
            // 
            // spares_detail
            // 
            this.spares_detail.Location = new System.Drawing.Point(6, 23);
            this.spares_detail.MaxLength = 100;
            this.spares_detail.Name = "spares_detail";
            this.spares_detail.Size = new System.Drawing.Size(213, 34);
            this.spares_detail.TabIndex = 1;
            // 
            // SparesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 418);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SparesAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "จัดการข้อมูลอะไหล่";
            this.Load += new System.EventHandler(this.SparesAdd_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox spares_qty;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox spares_unit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox spares_name;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox spares_cost_price;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox spares_unit_price;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox spares_detail;
    }
}