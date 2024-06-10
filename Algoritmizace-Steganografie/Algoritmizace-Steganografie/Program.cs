using System.Drawing;
using System.Text;

string image = args[0];
string message = args[1];
Encoding ascii = Encoding.ASCII;

Bitmap bm = new Bitmap(image);
Color cLast = bm.GetPixel(bm.Width - 1, bm.Height - 1);
Color setPixLast = Color.FromArgb(cLast.R, cLast.G, Convert.ToByte(message.Length));
bm.SetPixel(bm.Width - 1, bm.Height - 1, setPixLast);

for (int i = 0; i < message.Length; i++)
{
    Color c = bm.GetPixel(i, 0);
    Color setPix = Color.FromArgb(c.R, c.G, Convert.ToByte(message[i]));
    bm.SetPixel(i, 0, setPix);

}
string image2 = image.Split(".bmp")[0] + "2.bmp";
bm.Save(image2);

Bitmap bm2 = new Bitmap(image2);
int lastPixel = bm2.GetPixel(bm2.Width - 1, bm2.Height - 1).B;
byte[] unicodeBytes = new byte[lastPixel];
for (int i = 0; i < lastPixel; i++)
{
    Color a = bm2.GetPixel(i, 0);
    unicodeBytes[i] = a.B;
}
char[] asciiChars = new char[ascii.GetCharCount(unicodeBytes, 0, unicodeBytes.Length)];
ascii.GetChars(unicodeBytes, 0, unicodeBytes.Length, asciiChars, 0);
string asciiString = new string(asciiChars);
Console.WriteLine(asciiString);

Console.ReadLine();