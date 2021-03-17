// 
// Copyright (c) 2004-2021 Jaroslaw Kowalski <jaak@jkowalski.net>, Kim Christensen, Julian Verdurmen
// 
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// * Redistributions of source code must retain the above copyright notice, 
//   this list of conditions and the following disclaimer. 
// 
// * Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution. 
// 
// * Neither the name of Jaroslaw Kowalski nor the names of its 
//   contributors may be used to endorse or promote products derived from this
//   software without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
// THE POSSIBILITY OF SUCH DAMAGE.
// 

using System;
using System.IO;

namespace NLog.Internal
{
    internal static class FileInfoExt
    {
        public static DateTime GetLastWriteTimeUtc(this FileInfo fileInfo)
        {
#if !SILVERLIGHT
            return fileInfo.LastWriteTimeUtc;
#else
            return fileInfo.LastWriteTime;
#endif
        }
        public static DateTime GetCreationTimeUtc(this FileInfo fileInfo)
        {
#if !SILVERLIGHT
            return fileInfo.CreationTimeUtc;
#else
            return fileInfo.CreationTime;
#endif
        }

        public static DateTime LookupValidFileCreationTimeUtc(this FileInfo fileInfo)
        {
            return FileInfoHelper.LookupValidFileCreationTimeUtc(fileInfo, (f) => f.GetCreationTimeUtc(), (f) => f.GetLastWriteTimeUtc()).Value;
        }

        public static DateTime LookupValidFileCreationTimeUtc(this FileInfo fileInfo, DateTime? fallbackTime)
        {
            if (fallbackTime > DateTime.MinValue)
                return FileInfoHelper.LookupValidFileCreationTimeUtc(fileInfo, (f) => f.GetCreationTimeUtc(), (f) => fallbackTime.Value, (f) => f.GetLastWriteTimeUtc()).Value;
            else
                return LookupValidFileCreationTimeUtc(fileInfo);
        }
    }
}
