using OurJourney.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurJourney.Application.Common.Settings
{
    public class AppSettings
    {
        public string ApplicationName { get; set; }
        public string ApplicationDisplayName { get; set; }
        public string ApplicationId { get; set; }
        public long LongRequestTimeMilliseconds { get; set; }
        public long SlidingExpirationCacheTimeSeconds { get; set; }
        public MensajeUsuarioDTO GeneralErrorMessage { get; set; }
        public int MaximoDiasBuscar { get; set; }
        public int PageSizeExportar { get; set; }
        public string FileServerVoucher { get; set; }
        public string FileServerContratos { get; set; }
        public string FileServerDocumentosAdjuntos { get; set; }
        public string ArchivosPermitidos { get; set; }
        public string ArchivosPermitidosDocumentosAdjuntos { get; set; }
        public string FileServerDocumentosFirmadosTOC { get; set; }
        public string[] DestinatarioEmail { get; set; }
        public double UmbralMinimo { get; set; }
        public double UmbralMaximo { get; set; }
    }
}
