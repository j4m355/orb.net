using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orb.Data.Models.Computer
{
    public class PcStatus
    {
        public string homeIP { get; set; }
        public string homeLocation { get; set; }
        public string CPUUsage { get; set; }
        public string totalRAM { get; set; }
        public string RAMUsage { get; set; }
        public string totalAudioFiles { get; set; }
        public string totalPhotoFiles { get; set; }
        public string totalVideoFiles { get; set; }
        public string totalDocumentFiles { get; set; }
    }
}
