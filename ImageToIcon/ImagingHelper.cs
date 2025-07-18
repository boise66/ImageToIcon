using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageToIcon;

/* DISCLAIMER
 *
 * This whole class was copied from this GitHub Gist: https://gist.github.com/darkfall/1656050
 * More specifically from this comment, which improved the original code significantly:
 * https://gist.github.com/darkfall/1656050?permalink_comment_id=2375789#gistcomment-2375789
 *
 * I have only made minor changes - mostly from ReSharper suggestions - as I analyzed the code to learn
 * how it works.
 *
 * /Bosse
 */

/// <summary>
/// Adapted from this gist: https://gist.github.com/darkfall/1656050
/// Provides helper methods for imaging
/// </summary>
public static class ImagingHelper
{
    public static readonly int[] DefaultSizes = [256, 48, 32, 16];

    /// <summary>
    /// Converts a PNG image to an icon (ico) with all the sizes windows likes
    /// </summary>
    /// <param name="inputBitmap">The input bitmap</param>
    /// <param name="output">The output stream</param>
    /// <param name="sizes">Array of image sizes to include in the .ICO file</param>
    /// <returns>Whether the icon was successfully generated</returns>
    public static bool ConvertToIcon(Bitmap inputBitmap, Stream output,
        int[]? sizes = null)
    {
        sizes ??= DefaultSizes;
        if (sizes.Length == 0) return false;

        // Generate bitmaps for all the sizes and toss them in streams
        var imageStreams = new List<MemoryStream>();

        foreach (var size in sizes)
        {
            var newBitmap = ResizeImage(inputBitmap, size, size);
            using var memoryStream = new MemoryStream();
            newBitmap.Save(memoryStream, ImageFormat.Png);
            imageStreams.Add(memoryStream);
        }

        using var iconWriter = new BinaryWriter(output);
        var offset = 0;

        // 0-1 reserved, 0
        iconWriter.Write((byte)0);
        iconWriter.Write((byte)0);

        // 2-3 image type, 1 = icon, 2 = cursor
        iconWriter.Write((short)1);

        // 4-5 number of images
        iconWriter.Write((short)sizes.Length);

        offset += 6 + (16 * sizes.Length);

        for (var i = 0; i < sizes.Length; i++)
        {
            // image entry 1
            // 0 image width
            iconWriter.Write((byte)sizes[i]);
            // 1 image height
            iconWriter.Write((byte)sizes[i]);

            // 2 number of colors
            iconWriter.Write((byte)0);

            // 3 reserved
            iconWriter.Write((byte)0);

            // 4-5 color planes
            iconWriter.Write((short)0);

            // 6-7 bits per pixel
            iconWriter.Write((short)32);

            // 8-11 size of image data
            iconWriter.Write((int)imageStreams[i].Length);

            // 12-15 offset of image data
            iconWriter.Write(offset);

            offset += (int)imageStreams[i].Length;
        }

        for (var i = 0; i < sizes.Length; i++)
        {
            // write image data
            // png data must contain the whole png data file
            iconWriter.Write(imageStreams[i].ToArray());
            imageStreams[i].Close();
        }

        iconWriter.Flush();

        return true;
    }

    /// <summary>
    /// Converts a PNG image to a icon (ico)
    /// </summary>
    /// <param name="input">The input stream</param>
    /// <param name="output">The output stream</param>
    /// <param name="sizes">Array of image sizes to include in the .ICO file</param>
    /// <returns>Whether the icon was successfully generated</returns>
    public static bool ConvertToIcon(Stream input, Stream output,
        int[]? sizes = null)
    {
        var inputBitmap = (Bitmap)Image.FromStream(input);
        return ConvertToIcon(inputBitmap, output, sizes);
    }

    /// <summary>
    /// Converts a PNG image to a icon (ico)
    /// </summary>
    /// <param name="inputPath">The input path</param>
    /// <param name="outputPath">The output path</param>
    /// <param name="sizes">Array of image sizes to include in the .ICO file</param>
    /// <returns>Whether the icon was successfully generated</returns>
    public static bool ConvertToIcon(string inputPath, string outputPath,
        int[]? sizes = null)
    {
        using var inputStream = new FileStream(inputPath, FileMode.Open);
        using var outputStream = new FileStream(outputPath, FileMode.OpenOrCreate);
        return ConvertToIcon(inputStream, outputStream, sizes);
    }

    /// <summary>
    /// Converts an image to a icon (ico)
    /// </summary>
    /// <param name="inputImage">The input image</param>
    /// <param name="outputPath">The output path</param>
    /// <param name="sizes">Array of image sizes to include in the .ICO file</param>
    /// <returns>Whether the icon was successfully generated</returns>
    public static bool ConvertToIcon(Image inputImage, string outputPath,
        int[]? sizes = null)
    {
        using var outputStream = new FileStream(outputPath, FileMode.OpenOrCreate);
        return ConvertToIcon(new Bitmap(inputImage), outputStream, sizes);
    }

    /// <summary>
    /// Resize the image to the specified width and height.
    /// Found on stackoverflow: https://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
    /// </summary>
    /// <param name="image">The image to resize.</param>
    /// <param name="width">The width to resize to.</param>
    /// <param name="height">The height to resize to.</param>
    /// <returns>The resized image.</returns>
    public static Bitmap ResizeImage(Image image, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using var graphics = Graphics.FromImage(destImage);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        using var wrapMode = new ImageAttributes();
        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);

        return destImage;
    }
}