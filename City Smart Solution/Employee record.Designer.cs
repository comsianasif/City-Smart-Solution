namespace City_Smart_Solution
{
    partial class Employee_record
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.textsearch = new System.Windows.Forms.TextBox();
            this.rdname = new System.Windows.Forms.RadioButton();
            this.rdid = new System.Windows.Forms.RadioButton();
            this.rdsalary = new System.Windows.Forms.RadioButton();
            this.rdcnic = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(270, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 59);
            this.label1.TabIndex = 4;
            this.label1.Text = "View Employee Record";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(875, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 43);
            this.button2.TabIndex = 7;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button3.Location = new System.Drawing.Point(875, 226);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 43);
            this.button3.TabIndex = 8;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 287);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(976, 411);
            this.dataGridView1.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(71, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 26);
            this.label11.TabIndex = 33;
            this.label11.Text = " Search";
            // 
            // textsearch
            // 
            this.textsearch.BackColor = System.Drawing.SystemColors.Window;
            this.textsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textsearch.Location = new System.Drawing.Point(228, 117);
            this.textsearch.Multiline = true;
            this.textsearch.Name = "textsearch";
            this.textsearch.Size = new System.Drawing.Size(190, 29);
            this.textsearch.TabIndex = 1;
            // 
            // rdname
            // 
            this.rdname.AutoSize = true;
            this.rdname.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdname.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rdname.Location = new System.Drawing.Point(494, 120);
            this.rdname.Name = "rdname";
            this.rdname.Size = new System.Drawing.Size(67, 23);
            this.rdname.TabIndex = 2;
            this.rdname.TabStop = true;
            this.rdname.Text = "Name";
            this.rdname.UseVisualStyleBackColor = true;
            // 
            // rdid
            // 
            this.rdid.AutoSize = true;
            this.rdid.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdid.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rdid.Location = new System.Drawing.Point(594, 123);
            this.rdid.Name = "rdid";
            this.rdid.Size = new System.Drawing.Size(42, 23);
            this.rdid.TabIndex = 3;
            this.rdid.TabStop = true;
            this.rdid.Text = "ID";
            this.rdid.UseVisualStyleBackColor = true;
            // 
            // rdsalary
            // 
            this.rdsalary.AutoSize = true;
            this.rdsalary.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdsalary.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rdsalary.Location = new System.Drawing.Point(677, 123);
            this.rdsalary.Name = "rdsalary";
            this.rdsalary.Size = new System.Drawing.Size(69, 23);
            this.rdsalary.TabIndex = 4;
            this.rdsalary.TabStop = true;
            this.rdsalary.Text = "Salary";
            this.rdsalary.UseVisualStyleBackColor = true;
            // 
            // rdcnic
            // 
            this.rdcnic.AutoSize = true;
            this.rdcnic.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdcnic.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rdcnic.Location = new System.Drawing.Point(769, 123);
            this.rdcnic.Name = "rdcnic";
            this.rdcnic.Size = new System.Drawing.Size(60, 23);
            this.rdcnic.TabIndex = 5;
            this.rdcnic.TabStop = true;
            this.rdcnic.Text = "CNIC";
            this.rdcnic.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button6.Location = new System.Drawing.Point(875, 109);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(113, 43);
            this.button6.TabIndex = 6;
            this.button6.Text = "Search";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Employee_record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1036, 736);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.rdcnic);
            this.Controls.Add(this.rdsalary);
            this.Controls.Add(this.rdid);
            this.Controls.Add(this.rdname);
            this.Controls.Add(this.textsearch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Name = "Employee_record";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Employee_record_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox textsearch;
        private System.Windows.Forms.RadioButton rdname;
        private System.Windows.Forms.RadioButton rdid;
        private System.Windows.Forms.RadioButton rdsalary;
        private System.Windows.Forms.RadioButton rdcnic;
        private System.Windows.Forms.Button button6;
    }
}