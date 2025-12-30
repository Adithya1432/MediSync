using System.Security.Cryptography;
using System.Text;
using UserService.DTOs;
using UserService.Interfaces;
using UserService.Models;

namespace UserService.Services
{
    public class UsersService : IUserService
    {
        private readonly IUserRepository _repository;

        public UsersService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task PatientSignupAsync(PatientSignupDto dto)
        {
            if (await _repository.EmailExistsAsync(dto.Email))
                throw new InvalidOperationException("Email already exists");


            var userId = Guid.NewGuid();

            var user = new User
            {
                UserId = userId,
                FullName = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Password = Hash(dto.Password),
                Role = "Patient",
                AccountStatus = "Active",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            

            if (dto.Gender != null)
            {
                var patient = new Patient
                {
                    UserId = userId,
                    DateOfBirth = dto.DateOfBirth,
                    Gender = dto.Gender
                };

                await _repository.CreateUserAsync(user);

                await _repository.CreatePatientAsync(patient);
            }
        }

        public async Task DoctorSignupAsync(DoctorSignupDto dto)
        {
            try
            {
                if (await _repository.EmailExistsAsync(dto.Email))
                    throw new InvalidOperationException("Email already exists");


                var userId = Guid.NewGuid();

                var user = new User
                {
                    UserId = userId,
                    FullName = dto.Name,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    Password = Hash(dto.Password),
                    Role = "Doctor",
                    AccountStatus = "Pending Approval",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                

                if (dto.RegistrationNumber != null)
                {
                    var doctor = new Doctor
                    {
                        UserId = userId,
                        RegistrationNumber = dto.RegistrationNumber,
                        Specialty = dto.Specialty,
                        YearsOfExperience = dto.YearsOfExperience,
                        ConsultationType = dto.ConsultationType,
                        DateOfBirth = dto.DateOfBirth,
                        Gender = dto.Gender
                    };
                    await _repository.CreateUserAsync(user);
                    await _repository.CreateDoctorAsync(doctor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private static string Hash(string password)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(
                sha.ComputeHash(Encoding.UTF8.GetBytes(password))
            );
        }
    }
}

