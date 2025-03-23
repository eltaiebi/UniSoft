using UniSoft.Application.DTOs;

namespace UniSoft.Application.Interfaces
{
    public interface IApplicationService
    {
        Task<ApplicationDto> GetApplicationDetailsAsync(int applicationId);
    }
    
}