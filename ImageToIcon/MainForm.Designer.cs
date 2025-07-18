namespace ImageToIcon
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new Label();
            imagePathTextBox = new TextBox();
            imageBrowseButton = new Button();
            imagePictureBox = new PictureBox();
            loadImageButton = new Button();
            label2 = new Label();
            size16CheckBox = new CheckBox();
            size24CheckBox = new CheckBox();
            size32CheckBox = new CheckBox();
            size48CheckBox = new CheckBox();
            size256CheckBox = new CheckBox();
            size20CheckBox = new CheckBox();
            size30CheckBox = new CheckBox();
            size40CheckBox = new CheckBox();
            size36CheckBox = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            imageSizesGroupBox = new GroupBox();
            label6 = new Label();
            destinationBrowseButton = new Button();
            destinationDirectoryTextBox = new TextBox();
            label7 = new Label();
            label3 = new Label();
            iconFileNameTextBox = new TextBox();
            saveIconButton = new Button();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)imagePictureBox).BeginInit();
            imageSizesGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 0;
            label1.Text = "Image to convert:";
            // 
            // imagePathTextBox
            // 
            imagePathTextBox.Location = new Point(12, 27);
            imagePathTextBox.Name = "imagePathTextBox";
            imagePathTextBox.Size = new Size(425, 23);
            imagePathTextBox.TabIndex = 1;
            // 
            // imageBrowseButton
            // 
            imageBrowseButton.Location = new Point(443, 27);
            imageBrowseButton.Name = "imageBrowseButton";
            imageBrowseButton.Size = new Size(60, 23);
            imageBrowseButton.TabIndex = 2;
            imageBrowseButton.Text = "Browse";
            imageBrowseButton.UseVisualStyleBackColor = true;
            imageBrowseButton.Click += ImageBrowseButton_Click;
            // 
            // imagePictureBox
            // 
            imagePictureBox.BorderStyle = BorderStyle.Fixed3D;
            imagePictureBox.Location = new Point(129, 56);
            imagePictureBox.Name = "imagePictureBox";
            imagePictureBox.Size = new Size(100, 84);
            imagePictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            imagePictureBox.TabIndex = 3;
            imagePictureBox.TabStop = false;
            // 
            // loadImageButton
            // 
            loadImageButton.Location = new Point(12, 56);
            loadImageButton.Name = "loadImageButton";
            loadImageButton.Size = new Size(88, 23);
            loadImageButton.TabIndex = 4;
            loadImageButton.Text = "Load image";
            loadImageButton.UseVisualStyleBackColor = true;
            loadImageButton.Click += LoadImageButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(117, 28);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 6;
            label2.Text = "125% scaling:";
            // 
            // size16CheckBox
            // 
            size16CheckBox.AutoSize = true;
            size16CheckBox.Checked = true;
            size16CheckBox.CheckState = CheckState.Checked;
            size16CheckBox.Location = new Point(12, 46);
            size16CheckBox.Name = "size16CheckBox";
            size16CheckBox.Size = new Size(55, 19);
            size16CheckBox.TabIndex = 0;
            size16CheckBox.Tag = "16";
            size16CheckBox.Text = "16x16";
            size16CheckBox.UseVisualStyleBackColor = true;
            // 
            // size24CheckBox
            // 
            size24CheckBox.AutoSize = true;
            size24CheckBox.Checked = true;
            size24CheckBox.CheckState = CheckState.Checked;
            size24CheckBox.Location = new Point(12, 71);
            size24CheckBox.Name = "size24CheckBox";
            size24CheckBox.Size = new Size(55, 19);
            size24CheckBox.TabIndex = 1;
            size24CheckBox.Tag = "24";
            size24CheckBox.Text = "24x24";
            size24CheckBox.UseVisualStyleBackColor = true;
            // 
            // size32CheckBox
            // 
            size32CheckBox.AutoSize = true;
            size32CheckBox.Checked = true;
            size32CheckBox.CheckState = CheckState.Checked;
            size32CheckBox.Location = new Point(12, 96);
            size32CheckBox.Name = "size32CheckBox";
            size32CheckBox.Size = new Size(55, 19);
            size32CheckBox.TabIndex = 2;
            size32CheckBox.Tag = "32";
            size32CheckBox.Text = "32x32";
            size32CheckBox.UseVisualStyleBackColor = true;
            // 
            // size48CheckBox
            // 
            size48CheckBox.AutoSize = true;
            size48CheckBox.Checked = true;
            size48CheckBox.CheckState = CheckState.Checked;
            size48CheckBox.Location = new Point(12, 121);
            size48CheckBox.Name = "size48CheckBox";
            size48CheckBox.Size = new Size(55, 19);
            size48CheckBox.TabIndex = 3;
            size48CheckBox.Tag = "48";
            size48CheckBox.Text = "48x48";
            size48CheckBox.UseVisualStyleBackColor = true;
            // 
            // size256CheckBox
            // 
            size256CheckBox.AutoSize = true;
            size256CheckBox.Checked = true;
            size256CheckBox.CheckState = CheckState.Checked;
            size256CheckBox.Location = new Point(12, 146);
            size256CheckBox.Name = "size256CheckBox";
            size256CheckBox.Size = new Size(67, 19);
            size256CheckBox.TabIndex = 4;
            size256CheckBox.Tag = "256";
            size256CheckBox.Text = "256x256";
            size256CheckBox.UseVisualStyleBackColor = true;
            // 
            // size20CheckBox
            // 
            size20CheckBox.AutoSize = true;
            size20CheckBox.Location = new Point(121, 45);
            size20CheckBox.Name = "size20CheckBox";
            size20CheckBox.Size = new Size(55, 19);
            size20CheckBox.TabIndex = 5;
            size20CheckBox.Tag = "20";
            size20CheckBox.Text = "20x20";
            size20CheckBox.UseVisualStyleBackColor = true;
            // 
            // size30CheckBox
            // 
            size30CheckBox.AutoSize = true;
            size30CheckBox.Location = new Point(121, 70);
            size30CheckBox.Name = "size30CheckBox";
            size30CheckBox.Size = new Size(55, 19);
            size30CheckBox.TabIndex = 6;
            size30CheckBox.Tag = "30";
            size30CheckBox.Text = "30x30";
            size30CheckBox.UseVisualStyleBackColor = true;
            // 
            // size40CheckBox
            // 
            size40CheckBox.AutoSize = true;
            size40CheckBox.Location = new Point(121, 95);
            size40CheckBox.Name = "size40CheckBox";
            size40CheckBox.Size = new Size(55, 19);
            size40CheckBox.TabIndex = 7;
            size40CheckBox.Tag = "40";
            size40CheckBox.Text = "40x40";
            size40CheckBox.UseVisualStyleBackColor = true;
            // 
            // size36CheckBox
            // 
            size36CheckBox.AutoSize = true;
            size36CheckBox.Location = new Point(223, 70);
            size36CheckBox.Name = "size36CheckBox";
            size36CheckBox.Size = new Size(55, 19);
            size36CheckBox.TabIndex = 8;
            size36CheckBox.Tag = "36";
            size36CheckBox.Text = "36x36";
            size36CheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.Location = new Point(361, 28);
            label4.Name = "label4";
            label4.Size = new Size(218, 137);
            label4.TabIndex = 8;
            label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 28);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 9;
            label5.Text = "Recommended:";
            // 
            // imageSizesGroupBox
            // 
            imageSizesGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            imageSizesGroupBox.Controls.Add(label6);
            imageSizesGroupBox.Controls.Add(label5);
            imageSizesGroupBox.Controls.Add(label4);
            imageSizesGroupBox.Controls.Add(size36CheckBox);
            imageSizesGroupBox.Controls.Add(size16CheckBox);
            imageSizesGroupBox.Controls.Add(label2);
            imageSizesGroupBox.Controls.Add(size40CheckBox);
            imageSizesGroupBox.Controls.Add(size30CheckBox);
            imageSizesGroupBox.Controls.Add(size24CheckBox);
            imageSizesGroupBox.Controls.Add(size20CheckBox);
            imageSizesGroupBox.Controls.Add(size256CheckBox);
            imageSizesGroupBox.Controls.Add(size32CheckBox);
            imageSizesGroupBox.Controls.Add(size48CheckBox);
            imageSizesGroupBox.Location = new Point(12, 158);
            imageSizesGroupBox.Name = "imageSizesGroupBox";
            imageSizesGroupBox.Size = new Size(585, 177);
            imageSizesGroupBox.TabIndex = 10;
            imageSizesGroupBox.TabStop = false;
            imageSizesGroupBox.Text = "Icon image sizes";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(218, 28);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 10;
            label6.Text = "150% scaling:";
            // 
            // destinationBrowseButton
            // 
            destinationBrowseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            destinationBrowseButton.Location = new Point(537, 356);
            destinationBrowseButton.Name = "destinationBrowseButton";
            destinationBrowseButton.Size = new Size(60, 23);
            destinationBrowseButton.TabIndex = 13;
            destinationBrowseButton.Text = "Browse";
            destinationBrowseButton.UseVisualStyleBackColor = true;
            destinationBrowseButton.Click += DestinationBrowseButton_Click;
            // 
            // destinationDirectoryTextBox
            // 
            destinationDirectoryTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            destinationDirectoryTextBox.Location = new Point(12, 356);
            destinationDirectoryTextBox.Name = "destinationDirectoryTextBox";
            destinationDirectoryTextBox.Size = new Size(519, 23);
            destinationDirectoryTextBox.TabIndex = 12;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(12, 338);
            label7.Name = "label7";
            label7.Size = new Size(120, 15);
            label7.TabIndex = 11;
            label7.Text = "Destination directory:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(12, 382);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 14;
            label3.Text = "Icon file name:";
            // 
            // iconFileNameTextBox
            // 
            iconFileNameTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            iconFileNameTextBox.Location = new Point(12, 400);
            iconFileNameTextBox.Name = "iconFileNameTextBox";
            iconFileNameTextBox.Size = new Size(278, 23);
            iconFileNameTextBox.TabIndex = 15;
            // 
            // saveIconButton
            // 
            saveIconButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveIconButton.Location = new Point(342, 399);
            saveIconButton.Name = "saveIconButton";
            saveIconButton.Size = new Size(75, 23);
            saveIconButton.TabIndex = 16;
            saveIconButton.Text = "Save file";
            saveIconButton.UseVisualStyleBackColor = true;
            saveIconButton.Click += SaveIconButton_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(296, 403);
            label8.Name = "label8";
            label8.Size = new Size(30, 15);
            label8.TabIndex = 17;
            label8.Text = ".ICO";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 435);
            Controls.Add(label8);
            Controls.Add(saveIconButton);
            Controls.Add(iconFileNameTextBox);
            Controls.Add(label3);
            Controls.Add(destinationBrowseButton);
            Controls.Add(destinationDirectoryTextBox);
            Controls.Add(label7);
            Controls.Add(imageSizesGroupBox);
            Controls.Add(loadImageButton);
            Controls.Add(imageBrowseButton);
            Controls.Add(imagePathTextBox);
            Controls.Add(label1);
            Controls.Add(imagePictureBox);
            Name = "MainForm";
            Text = "Image To Icon";
            ((System.ComponentModel.ISupportInitialize)imagePictureBox).EndInit();
            imageSizesGroupBox.ResumeLayout(false);
            imageSizesGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox imagePathTextBox;
        private Button imageBrowseButton;
        private PictureBox imagePictureBox;
        private Button loadImageButton;
        private Label label2;
        private CheckBox size16CheckBox;
        private CheckBox size24CheckBox;
        private CheckBox size32CheckBox;
        private CheckBox size48CheckBox;
        private CheckBox size256CheckBox;
        private CheckBox size20CheckBox;
        private CheckBox size30CheckBox;
        private CheckBox size40CheckBox;
        private CheckBox size36CheckBox;
        private Label label4;
        private Label label5;
        private GroupBox imageSizesGroupBox;
        private Label label6;
        private Button destinationBrowseButton;
        private TextBox destinationDirectoryTextBox;
        private Label label7;
        private Label label3;
        private TextBox iconFileNameTextBox;
        private Button saveIconButton;
        private Label label8;
    }
}
