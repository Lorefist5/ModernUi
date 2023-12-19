using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using ModernUi.WPF.Services.Interfaces;
namespace ModernUi.WPF.Services
{
    public class DesktopFileSystem : IFileSystem
    {
        public Task<List<string>> GetFiles(string? folderPath = null)
        {
            if (folderPath == null) throw new Exception("Folder path can't be null");

            return Task.FromResult(FileSystem.GetFiles(folderPath).ToList());
        }

        public Task<string> PickFile(string? title = null, string? filters = null, bool multiSelect = false)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = title,
                Filter = filters,
                Multiselect = multiSelect
            };

            bool? result = openFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                // Return the selected file path
                return Task.FromResult(openFileDialog.FileName);
            }
            else
            {
                // User canceled the dialog or an error occurred
                return Task.FromResult(string.Empty);
            }
        }

        public Task<string> PickFolder(string? title = null, bool multiSelect = false)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            openFolderDialog.Title = title;
            openFolderDialog.Multiselect = multiSelect;
            bool? result = openFolderDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                // Return the selected folder path
                return Task.FromResult(openFolderDialog.FolderName);
            }
            else
            {
                return Task.FromResult(string.Empty);
            }
        }
    }
}
