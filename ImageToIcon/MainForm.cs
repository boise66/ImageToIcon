using System.Diagnostics;

namespace ImageToIcon;

public partial class MainForm : Form
{
    #region Types and definitions

    private string? _imageFilePath;
    private Image? _image;
    private readonly Dictionary<CheckBox, int> _sizeByCheckBox = [];

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
        
        SetStatusMessage("Ready.");
    }

    #endregion Constructor and initialization

    #region Private members

    private void LoadImageFile()
    {
        _image = null;
        _imageFilePath = null;
        imagePictureBox.Image = null;

        var filePath = imagePathTextBox.Text;

        if (string.IsNullOrWhiteSpace(filePath))
        {
            SetStatusMessage("Cannot load image. No file specified.");
            return;
        }
        
        if (!File.Exists(filePath))
        {
            SetStatusMessage("Cannot load image. Specified file does not exist.");
            return;
        }

        try
        {
            _image = Image.FromFile(filePath);
            if (_image == null)
            {
                SetStatusMessage("FAILED to load image. No image could be retrieved from the file.");
                return;
            }
        }
        catch (Exception e)
        {
            SetStatusMessage("FAILED to load image file. An exception occurred.");
            MessageBox.Show($@"Exception when loading image file:\n\n{e}",
                @"Image To Icon", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        SetStatusMessage("Image file loaded.");
        
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
        if (_image == null)
        {
            SetStatusMessage("Cannot generate icon. No image loaded.");
            return;
        }
        
        var sizes = GetSizeArray();
        
        if (sizes.Length == 0)
        {
            SetStatusMessage("Cannot generate icon. No sizes selected.");
            return;
        }

        if (string.IsNullOrWhiteSpace(iconFileNameTextBox.Text))
        {
            SetStatusMessage("Cannot generate icon. No file name specified.");
            return;
        }
        
        var destinationDirectory = destinationDirectoryTextBox.Text;
        
        if (string.IsNullOrWhiteSpace(destinationDirectory))
        {
            SetStatusMessage("Cannot generate icon. No destination directory specified.");
            return;
        }

        if (!Directory.Exists(destinationDirectory))
        {
            SetStatusMessage("Cannot generate icon. Destination directory does not exist.");
            return;
        }
        
        var fileName = iconFileNameTextBox.Text + ".ico";
        var iconPath = Path.Combine(destinationDirectory, fileName);

        if (File.Exists(iconPath))
        {
            var overwriteAcknowledgement =
                MessageBox.Show(@"The icon file already exists. Overwrite it?",
                    @"Image To Icon", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if (overwriteAcknowledgement == DialogResult.Cancel)
            {
                SetStatusMessage("Cancelled generation since file already exists.");
                return;
            }
        }
        
        var success = ImagingHelper.ConvertToIcon(_image, iconPath, sizes);

        if (!success)
        {
            SetStatusMessage("FAILED to generate icon file!");
            MessageBox.Show(@"Failed to generate icon file.",
                @"Image To Icon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        SetStatusMessage($"Successfully generated icon file {iconPath}");
        var name = string.IsNullOrWhiteSpace(ImagingHelper.LatestGeneratedFilePath)
            ? "unnamed"
            : Path.GetFileName(ImagingHelper.LatestGeneratedFilePath);
        ShowIconImages(ImagingHelper.LatestGeneratedImages, name);
    }

    private static void ShowIconImages(List<Image> images, string name)
    {
        var form = new IconImagesForm(images, name);
        form.Show();
    }

    private void SetStatusMessage(string message = "")
    {
        statusLabel.Text = message;
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