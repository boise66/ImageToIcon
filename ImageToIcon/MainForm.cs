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
        var sizes = new List<int>();

        foreach (var sizeCheckBox in _sizeByCheckBox.Keys)
        {
            if (!sizeCheckBox.Checked) continue;

            sizes.Add(_sizeByCheckBox[sizeCheckBox]);
        }

        sizes.Sort();

        return sizes.ToArray();
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

    }

    #endregion Event handlers
}