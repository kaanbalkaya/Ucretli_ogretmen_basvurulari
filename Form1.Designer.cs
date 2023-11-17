using System.Windows.Forms;

namespace Ücretli
{
    partial class Form1
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
            openFileBtn = new Button();
            openFileDialog = new OpenFileDialog();
            bransBtn = new Button();
            saveFileDialog = new SaveFileDialog();
            saveFileBtn = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // openFileBtn
            // 
            openFileBtn.Enabled = false;
            openFileBtn.Location = new Point(23, 66);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(75, 23);
            openFileBtn.TabIndex = 0;
            openFileBtn.Text = "Başvurular";
            openFileBtn.UseVisualStyleBackColor = true;
            openFileBtn.Visible = false;
            openFileBtn.Click += openFileBtn_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "xls dosyaları (*.xls)|*.xls|xlsx dosyaları (*.xlsx)|*.xlsx";
            // 
            // bransBtn
            // 
            bransBtn.Location = new Point(23, 21);
            bransBtn.Name = "bransBtn";
            bransBtn.Size = new Size(75, 23);
            bransBtn.TabIndex = 1;
            bransBtn.Text = "Branşlar";
            bransBtn.UseVisualStyleBackColor = true;
            bransBtn.Click += bransBtn_Click;
            // 
            // saveFileDialog
            // 
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "xls dosyaları (*.xls)|*.xls";
            // 
            // saveFileBtn
            // 
            saveFileBtn.Enabled = false;
            saveFileBtn.Location = new Point(23, 107);
            saveFileBtn.Name = "saveFileBtn";
            saveFileBtn.Size = new Size(109, 23);
            saveFileBtn.TabIndex = 4;
            saveFileBtn.Text = "Dosyaya Kaydet";
            saveFileBtn.UseVisualStyleBackColor = true;
            saveFileBtn.Visible = false;
            saveFileBtn.Click += saveFileBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveFileBtn);
            Controls.Add(bransBtn);
            Controls.Add(openFileBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button openFileBtn;
        private OpenFileDialog openFileDialog;
        private Button bransBtn;
        private SaveFileDialog saveFileDialog;
        private Button saveFileBtn;
        private FolderBrowserDialog folderBrowserDialog;
    }
}