//
// Copyright (c) 2004-2024 Jaroslaw Kowalski <jaak@jkowalski.net>, Kim Christensen, Julian Verdurmen
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

#if !NETSTANDARD1_3 && !NETSTANDARD1_5

namespace NLog.Internal
{
    using System.Net.Mail;

    /// <summary>
    /// Supports mocking of SMTP Client code.
    /// </summary>
    /// <remarks>
    /// Disabled Error CS0618  'SmtpClient' is obsolete: 'SmtpClient and its network of types are poorly designed,
    ///  we strongly recommend you use https://github.com/jstedfast/MailKit and https://github.com/jstedfast/MimeKit instead'
    /// </remarks>
#pragma warning disable 618
    internal sealed class MySmtpClient : SmtpClient, ISmtpClient
#pragma warning restore 618
    {
#if NET35 || MONO
        /// <summary>
        /// Sends a QUIT message to the SMTP server, gracefully ends the TCP connection, and releases all resources used by the current instance of the <see cref="T:System.Net.Mail.SmtpClient"/> class.
        /// </summary>
#pragma warning disable 108
        public void Dispose()
#pragma warning restore 108
        {
            // dispose was added in .NET Framework 4.0, previous frameworks don't need it but adding it here to make the
            // user experience the same across all
        }
#endif
    }
}

#endif
