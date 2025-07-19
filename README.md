# Image To Icon

I needed to make some icons (.ico) from existing image files, and decided to make a small
application for it. Found a class for the conversion in a
[GitHub Gist](https://gist.github.com/darkfall/1656050), and decided to use the code from
[this comment there](https://gist.github.com/darkfall/1656050?permalink_comment_id=2375789#gistcomment-2375789).

I prettified that code a bit, and parameterized the array of icon sizes to produce, but
basically, the `ImagingHelper` class is straight from that comment.

And then I added a form from where you select the original image, select sizes, and run the
conversion.