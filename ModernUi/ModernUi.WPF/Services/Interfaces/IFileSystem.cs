using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUi.WPF.Services.Interfaces
{
    public interface IFileSystem
    {
        /// <summary>
        /// Displays a file picker dialog to allow the user to select a file.
        /// </summary>
        /// <param name="title">The title of the file picker dialog (optional).</param>
        /// <param name="filters">The file filters for the types of files to be displayed (optional).</param>
        /// <param name="multiSelect">Allows multiple files to be selected (optional).</param>
        /// <returns>The path of the selected file, or an empty string if canceled.</returns>
        Task<string> PickFile(string? title = null, string? filters = null, bool multiSelect = false);

        /// <summary>
        /// Displays a folder picker dialog to allow the user to select a folder.
        /// </summary>
        /// <param name="title">The title of the folder picker dialog (optional).</param>
        /// <param name="multiSelect">Allows multiple folders to be selected (optional).</param>
        /// <returns>The path of the selected folder, or an empty string if canceled.</returns>
        Task<string> PickFolder(string? title = null, bool multiSelect = false);

        /// <summary>
        /// Gets a list of file names in the specified folder.
        /// </summary>
        /// <param name="folderPath">The path to the folder.</param>
        /// <returns>A list of file names in the folder.</returns>
        Task<List<string>> GetFiles(string folderPath);
    }
}
