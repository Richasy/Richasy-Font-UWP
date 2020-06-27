using Richasy.Font.UWP;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

internal class FontScript
{
    internal async Task InitFont(string fontName)
    {
        var nameFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/{fontName}.txt"));
        string content = await FileIO.ReadTextAsync(nameFile);
        var names = content.Split('\n').ToList();
        var font = SystemFont.GetSystemFonts().FirstOrDefault(p => p.Name == fontName);
        if (font != null)
        {
            var range = font.FontFace.UnicodeRanges.Last();
            uint first = range.First;
            int index = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = Convert.ToInt32(first); i < Convert.ToInt32(range.Last); i++)
            {
                string name = names[index];
                bool isDash = false;
                string tempName = "";

                for (int y = 0; y < name.Length; y++)
                {
                    if (y == 0)
                        tempName += name[y].ToString().ToUpper();
                    else
                    {
                        if (name[y] == '-' || name[y] == '_')
                            isDash = true;
                        else
                        {
                            if (isDash)
                            {
                                tempName += name[y].ToString().ToUpper();
                                isDash = false;
                            }
                            else
                                tempName += name[y];
                        }
                    }
                }
                tempName = tempName.Trim();
                sb.AppendLine($"{tempName} = \'\\u{i:X4}\',");
                index++;
            }
            string total = sb.ToString();
            var package = new DataPackage();
            package.SetText(total);
            Clipboard.SetContent(package);
        }
    }
}
