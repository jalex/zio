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
        public virtual void CreateDirectory(UPath path) {
            OrigFileSystem.CreateDirectory(path);
        }

        /// <inheritdoc />
        public virtual bool DirectoryExists(UPath path) {
            return OrigFileSystem.DirectoryExists(path);
        }

        /// <inheritdoc />
        public virtual void MoveDirectory(UPath srcPath, UPath destPath) {
            OrigFileSystem.MoveDirectory(srcPath, destPath);
        }

        /// <inheritdoc />
        public virtual void DeleteDirectory(UPath path, bool isRecursive) {
            OrigFileSystem.DeleteDirectory(path, isRecursive);
        }

        /// <inheritdoc />
        public virtual void CopyFile(UPath srcPath, UPath destPath, bool overwrite) {
            OrigFileSystem.CopyFile(srcPath, destPath, overwrite);
        }

        /// <inheritdoc />
        public virtual void ReplaceFile(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors) {
            OrigFileSystem.ReplaceFile(srcPath, destPath, destBackupPath, ignoreMetadataErrors);
        }

        /// <inheritdoc />
        public virtual long GetFileLength(UPath path) {
            return OrigFileSystem.GetFileLength(path);
        }

        /// <inheritdoc />
        public virtual bool FileExists(UPath path) {
            return OrigFileSystem.FileExists(path);
        }

        /// <inheritdoc />
        public virtual void MoveFile(UPath srcPath, UPath destPath) {
            OrigFileSystem.MoveFile(srcPath, destPath);
        }

        /// <inheritdoc />
        public virtual void DeleteFile(UPath path) {
            OrigFileSystem.DeleteFile(path);
        }

        /// <inheritdoc />
        public virtual Stream OpenFile(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None) {
            return OrigFileSystem.OpenFile(path, mode, access, share);
        }

        /// <inheritdoc />
        public virtual FileAttributes GetAttributes(UPath path) {
            return OrigFileSystem.GetAttributes(path);
        }

        /// <inheritdoc />
        public virtual void SetAttributes(UPath path, FileAttributes attributes) {
            OrigFileSystem.SetAttributes(path, attributes);
        }

        /// <inheritdoc />
        public virtual DateTime GetCreationTime(UPath path) {
            return OrigFileSystem.GetCreationTime(path);
        }

        /// <inheritdoc />
        public virtual void SetCreationTime(UPath path, DateTime time) {
            OrigFileSystem.SetCreationTime(path, time);
        }

        /// <inheritdoc />
        public virtual DateTime GetLastAccessTime(UPath path) {
            return OrigFileSystem.GetLastAccessTime(path);
        }

        /// <inheritdoc />
        public virtual void SetLastAccessTime(UPath path, DateTime time) {
            OrigFileSystem.SetLastAccessTime(path, time);
        }

        /// <inheritdoc />
        public virtual DateTime GetLastWriteTime(UPath path) {
            return OrigFileSystem.GetLastWriteTime(path);
        }

        /// <inheritdoc />
        public virtual void SetLastWriteTime(UPath path, DateTime time) {
            OrigFileSystem.SetLastWriteTime(path, time);
        }

        /// <inheritdoc />
        public virtual IEnumerable<UPath> EnumeratePaths(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget) {
            return OrigFileSystem.EnumeratePaths(path, searchPattern, searchOption, searchTarget);
        }

        /// <inheritdoc />
        public virtual bool CanWatch(UPath path) {
            return OrigFileSystem.CanWatch(path);
        }

        /// <inheritdoc />
        public virtual IFileSystemWatcher Watch(UPath path) {
            return OrigFileSystem.Watch(path);
        }

        /// <inheritdoc />
        public virtual string ConvertPathToInternal(UPath path) {
            return OrigFileSystem.ConvertPathToInternal(path);
        }

        /// <inheritdoc />
        public virtual UPath ConvertPathFromInternal(string systemPath) {
            return OrigFileSystem.ConvertPathFromInternal(systemPath);
        }

        #endregion

        #region IDisposable members

        /// <inheritdoc />
        public virtual void Dispose() {
            if(_owned) {
                OrigFileSystem.Dispose();
            }
        }

        #endregion
    }
}
