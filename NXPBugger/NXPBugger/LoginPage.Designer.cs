namespace NXPBugger
{
    partial class LoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            u = new TextBox();
            label1 = new Label();
            p = new TextBox();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // u
            // 
            u.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            u.Location = new Point(81, 21);
            u.Name = "u";
            u.Size = new Size(113, 23);
            u.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 1;
            label1.Text = "Username :";
            // 
            // p
            // 
            p.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            p.Location = new Point(81, 50);
            p.Name = "p";
            p.PasswordChar = '*';
            p.Size = new Size(113, 23);
            p.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 3;
            label2.Text = "Password :";
            // 
            // button1
            // 
            button1.Location = new Point(12, 89);
            button1.Name = "button1";
            button1.Size = new Size(182, 23);
            button1.TabIndex = 4;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(206, 128);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(p);
            Controls.Add(label1);
            Controls.Add(u);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NXPLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox u;
        private Label label1;
        private TextBox p;
        private Label label2;
        private Button button1;
    }
}