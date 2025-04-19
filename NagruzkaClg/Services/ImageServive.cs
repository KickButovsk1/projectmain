using System.IO;
using System.Text.Json;
using Microsoft.Win32;

namespace NagruzkaClg.Services;

public static class ImageServive
{
    public static string SaveImageWithDialog(byte[] imageData)
    {
        var saveFileDialog = new SaveFileDialog
        {
            Filter = "Image files (*.jpg, *.png)|*.jpg;*.png",
            DefaultExt = ".png"
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            
        }

        return null;
    }

}