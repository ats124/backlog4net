using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backlog4net.Internal.File
{
    public class AttachmentDataImpl : AttachmentData
    {
        private HttpResponseMessage response;

        private AttachmentDataImpl(HttpResponseMessage response, string filename, Stream content)
        {
            this.response = response;
            this.FileName = filename;
            this.Content = content;
        }       

        public string FileName { get; private set; }

        public Stream Content { get; private set; }

        public static async Task<AttachmentDataImpl> CreateaAsync(HttpResponseMessage response)
        {
            var content = response.Content;
            try
            {
                return new AttachmentDataImpl(response, content.Headers.ContentDisposition.FileName, await content.ReadAsStreamAsync());
            }
            catch (Exception)
            {
                content.Dispose();
                throw;
            }
        }
        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (response != null)
                    {
                        try { response.Content?.Dispose(); } catch { }
                        try { response.Dispose(); } catch { }
                    }
                }
                Content = null;
                response = null;
                disposedValue = true;
            }
        }

        // TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
        // ~AttachmentDataImpl() {
        //   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
        //   Dispose(false);
        // }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
