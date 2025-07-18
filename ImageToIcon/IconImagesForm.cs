namespace ImageToIcon;

public sealed partial class IconImagesForm : Form
{
    public IconImagesForm()
    {
        InitializeComponent();
    }
        
    public IconImagesForm(List<Image> images, string name)
    {
        InitializeComponent();

        if (DesignMode) return;

        Text = $@"{name} ({images.Count} sizes)";
        
        const int margin = 10;
        var x = margin;
        var y = margin;

        foreach (var image in images)
        {
            var pictureBox = new PictureBox()
            {
                BorderStyle = BorderStyle.Fixed3D,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Image = image,
                Location = new Point(x, y)
            };

            x += pictureBox.Width + margin;
            
            Controls.Add(pictureBox);
            
            toolTip.SetToolTip(pictureBox, $"Size {image.Width}x{image.Height}");
        }
    }
}