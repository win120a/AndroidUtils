using System.Collections.Generic;

namespace AC.AndroidUtils.ADB.Interfaces
{
    public interface IFileManagmentService
    {
        List<string> ListFiles(string path, bool inRoot);
        void DeleteFile(string path, bool inRoot);
        void CopyFile(string orig, string dest, bool inRoot);
        void MoveFile(string orig, string dest, bool inRoot);
        FSObjectStatus GetFSObjectStatus(string pathToObject, bool inRoot);
    }

    public enum FSObjectStatus
    {
        Directory, File, PermissionDenied
    }
}
