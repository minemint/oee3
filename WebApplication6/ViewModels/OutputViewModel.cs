using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.ViewModels
{
    public class OutputViewModel
    {
        [Key]
        public int OutputId { get; set; }

        [DataType(DataType.Date)]
        public DateTime OutputDate { get; set; }
        public string Tstart { get; set; }
        public string Tend { get; set; }
        public string ToyName { get; set; }
        public string Shift { get; set; }
        public string MachineNo { get; set; }
        public int? OutputQTY { get; set; }
        public int? Crate { get; set; }
        public int DefectId { get; set; }
        public string DefectName { get; set; }
        public int? DefectQty { get; set; }
        public string DcodeName { get; set; }
        public TimeSpan? DowntimeStart { get; set; }
        public TimeSpan? DowntimeEnd { get; set; }
        public TimeSpan? DowntimeHour { get; set; }
        public string DcodeId { get; set; }
        public int DownTimeId { get; set; }

    }
}
