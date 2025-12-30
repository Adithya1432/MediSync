using UserService.Models;

namespace UserService.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> EmailExistsAsync(string email);
        Task CreateUserAsync(User user);
        Task CreatePatientAsync(Patient patient);
        Task CreateDoctorAsync(Doctor doctor);
    }

}
