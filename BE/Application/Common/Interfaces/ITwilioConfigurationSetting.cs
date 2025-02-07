using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Common.Interfaces
{
    public interface ITwilioConfigurationSetting
    {
        Task<string> GetProjectWiseTwilioContactNo(string phone, int? patient_empi, int? appt_id);
        Task<bool> GetAllowRecordingStatus(string phone, int? patient_empi, int? appt_id);
    }
}
