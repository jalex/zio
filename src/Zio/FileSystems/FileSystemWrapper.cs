using System;
using System.Collections.Generic;
using System.IO;

namespace Zio.FileSystems {

    /// <summary>
    /// Wraps another <see cref="IFileSystem"/> instance.
    /// </summary>
    /// <seealso cref="IFileSystem" />
    public class FileSystemWrapper: IFileSystem {
        readonly bool _owned;

        /// <summary>
        /// Gets the original file system.
        /// </summary>
        public IFileSystem OrigFileSystem { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemWrapper"/> class.
        /// </summary>
        /// <param name="originFileSystem">The origin file system.</param>
        /// <param name="owned">True if <paramref name="originFileSystem"/> should be disposed when this instance is disposed.</param>
        public FileSystemWrapper(IFileSystem originFileSystem, bool owned = true) {
            this.OrigFileSystem = originFileSystem;
            _owned = owned;
        }

        #region IFileSystem members

        /// <inheritdoc />
        public void CreateDirectory(UPath path) {
            OrigFileSystem.CreateDirectory(path);
        }

        /// <inheritdoc />
        public bool DirectoryExists(UPath path) {
            return OrigFileSystem.DirectoryExists(path);
        }

        /// <inheritdoc />
        public void MoveDirectory(UPath srcPath, UPath destPath) {
            OrigFileSystem.MoveDirectory(srcPath, destPath);
        }

        /// <inheritdoc />
        public void DeleteDirectory(UPath path, bool isRecursive) {
            OrigFileSystem.DeleteDirectory(path, isRecursive);
        }

        /// <inheritdoc />
        public void CopyFile(UPath srcPath, UPath destPath, bool overwrite) {
            OrigFileSystem.CopyFile(srcPath, destPath, overwrite);
        }

        /// <inheritdoc />
        public void ReplaceFile(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors) {
            OrigFileSystem.ReplaceFile(srcPath, destPath, destBackupPath, ignoreMetadataErrors);
        }

        /// <inheritdoc />
        public long GetFileLength(UPath path) {
            return OrigFileSystem.GetFileLength(path);
        }

        /// <inheritdoc />
        public bool FileExists(UPath path) {
            return OrigFileSystem.FileExists(path);
        }

        /// <inheritdoc />
        public void MoveFile(UPath srcPath, UPath destPath) {
            OrigFileSystem.MoveFile(srcPath, destPath);
        }

        /// <inheritdoc />
        public void DeleteFile(UPath path) {
            OrigFileSystem.DeleteFile(path);
        }

        /// <inheritdoc />
        public Stream OpenFile(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None) {
            return OrigFileSystem.OpenFile(path, mode, access, share);
        }

        /// <inheritdoc />
        public FileAttributes GetAttributes(UPath path) {
            return OrigFileSystem.GetAttributes(path);
        }

        /// <inheritdoc />
        public void SetAttributes(UPath path, FileAttributes attributes) {
            OrigFileSystem.SetAttributes(path, attributes);
        }

        /// <inheritdoc />
        public DateTime GetCreationTime(UPath path) {
            return OrigFileSystem.GetCreationTime(path);
        }

        /// <inheritdoc />
        public void SetCreationTime(UPath path, DateTime time) {
            OrigFileSystem.SetCreationTime(path, time);
        }

        /// <inheritdoc />
        public DateTime GetLastAccessTime(UPath path) {
            return OrigFileSystem.GetLastAccessTime(path);
        }

        /// <inheritdoc />
        public void SetLastAccessTime(UPath path, DateTime time) {
            OrigFileSystem.SetLastAccessTime(path, time);
        }

        /// <inheritdoc />
        public DateTime GetLastWriteTime(UPath path) {
            return OrigFileSystem.GetLastWriteTime(path);
        }

        /// <inheritdoc />
        public void SetLastWriteTime(UPath path, DateTime time) {
            OrigFileSystem.SetLastWriteTime(path, time);
        }

        /// <inheritdoc />
        public IEnumerable<UPath> EnumeratePaths(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget) {
            return OrigFileSystem.EnumeratePaths(path, searchPattern, searchOption, searchTarget);
        }

        /// <inheritdoc />
        public bool CanWatch(UPath path) {
            return OrigFileSystem.CanWatch(path);
        }

        /// <inheritdoc />
        public IFileSystemWatcher Watch(UPath path) {
            return OrigFileSystem.Watch(path);
        }

        /// <inheritdoc />
        public string ConvertPathToInternal(UPath path) {
            return OrigFileSystem.ConvertPathToInternal(path);
        }

        /// <inheritdoc />
        public UPath ConvertPathFromInternal(string systemPath) {
            return OrigFileSystem.ConvertPathFromInternal(systemPath);
        }

        #endregion

        #region IDisposable members

        /// <inheritdoc />
        public void Dispose() {
            if(_owned) {
                OrigFileSystem.Dispose();
            }
        }

        #endregion
    }
}
