﻿using System;
using System.Linq;
using System.Web;
using RdtClient.Data.Models.Data;

namespace RdtClient.Service.Helpers
{
    public static class Logger
    {
        public static String ToLog(this Download download)
        {
            var fileName = download.Path;

            if (!String.IsNullOrWhiteSpace(download.Link))
            {
                var uri = new Uri(download.Link);
                fileName = uri.Segments.Last();
                fileName = HttpUtility.UrlDecode(fileName);
            }

            var done = (Int32)((Double)download.BytesDone / download.BytesTotal) * 100;

            return $"for download {fileName} {done}% ({download.DownloadId})";
        }

        public static String ToLog(this Torrent torrent)
        {
            return $"for torrent {torrent.RdName} ({torrent.RdId} - {torrent.RdStatusRaw} {torrent.RdProgress}%) ({torrent.TorrentId})";
        }
    }
}
