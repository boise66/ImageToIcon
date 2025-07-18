using System.Diagnostics;

namespace ImageToIcon;

public partial class MainForm : Form
{
    #region Types and definitions

    private string? _imageFilePath;
    private Image? _image;
    private Dictionary<CheckBox, int> _sizeByCheckBox = [];

    #endregion Types and definitions

    #region Constructor and initialization

    public MainForm()
    {
        InitializeComponent();

        if (DesignMode) return;

        for (var index = 0; index < imageSizesGroupBox.Controls.Count; index++)
        {
            if (imageSizesGroupBox.Controls[index] is not CheckBox sizeCheckBox) continue;

            _sizeByCheckBox[sizeCheckBox] = int.Parse(sizeCheckBox.Tag!.ToString()!);
        }

        destinationDirectoryTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
    }

    #endregion Constructor and initialization

    #region Private members

    private void LoadImageFile()
    {
        _image = null;
        _imageFilePath = null;
        imagePictureBox.Image = null;

        var filePath = imagePathTextBox.Text;

        // Sanity check.
        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath)) return;

        _image = Image.FromFile(filePath);
        _imageFilePath = filePath;

        imagePictureBox.Image = _image;
        iconFileNameTextBox.Text = Path.GetFileNameWithoutExtension(_imageFilePath);
    }

    private int[] GetSizeArray()
    {
        var sizes = (from sizeCheckBox in _sizeByCheckBox.Keys
                     where sizeCheckBox.Checked
                     select _sizeByCheckBox[sizeCheckBox])
            .ToList();

        sizes.Sort();

        return sizes.ToArray();
    }

    private void SaveIcon()
    {
        // Sanity check.
        if (_image == null) return;
        if (string.IsNullOrWhiteSpace(destinationDirectoryTextBox.Text)) return;
        if (string.IsNullOrWhiteSpace(iconFileNameTextBox.Text)) return;

        var destinationDirectory = destinationDirectoryTextBox.Text;
        var fileName = iconFileNameTextBox.Text + ".ico";
        var sizes = GetSizeArray();

        if (!Directory.Exists(destinationDirectory)) return;
        if (sizes.Length == 0) return;

        var iconPath = Path.Combine(destinationDirectory, fileName);

        var success = ImagingHelper.ConvertToIcon(_image, iconPath, sizes);

        if (success) return;

        MessageBox.Show(@"Failed to generate icon file.",
            @"Image To Icon", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    #endregion Private members

    #region Event handlers

    private void ImageBrowseButton_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog()
        {
            FileName = imagePathTextBox.Text
        };

        var response = openFileDialog.ShowDialog(this);

        if (response != DialogResult.OK) return;

        imagePathTextBox.Text = openFileDialog.FileName;

        LoadImageFile();
    }

    private void DestinationBrowseButton_Click(object sender, EventArgs e)
    {

    }

    private void LoadImageButton_Click(object sender, EventArgs e)
    {
        LoadImageFile();
    }

    private void SaveIconButton_Click(object sender, EventArgs e)
    {
        SaveIcon();
    }

    private void OpenInExplorerButton_Click(object sender, EventArgs e)
    {
        var directoryPath = destinationDirectoryTextBox.Text;
        if (!Directory.Exists(directoryPath)) return;

        if (!string.IsNullOrWhiteSpace(iconFileNameTextBox.Text))
        {
            var fileName = $"{iconFileNameTextBox.Text}.ico";
            var filePath = Path.Combine(directoryPath, fileName);

            if (File.Exists(filePath))
            {
                Process.Start("explorer.exe", "/select, " + filePath);
                return;
            }
        }

        Process.Start("explorer.exe", directoryPath);
    }

    #endregion Event handlers
}