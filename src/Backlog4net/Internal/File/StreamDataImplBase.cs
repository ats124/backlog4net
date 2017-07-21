using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backlog4net.Internal.File
{
    public abstract class StreamDataImplBase<T> : IDisposable where T : StreamDataImplBase<T>, new()
    {
        private HttpResponseMessage response;

        public string FileName { get; private set; }

        public Stream Content { get; private set; }

        public static async Task<T> CreateaAsync(HttpResponseMessage response)
        {
            var content = response.Content;
            try
            {
                var obj = new T();
                obj.response = response;
                obj.FileName = content.Headers.ContentDisposition.FileNameStar ?? content.Headers.ContentDisposition.FileName;
                obj.Content = await content.ReadAsStreamAsync();
                return obj;
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
