using AutoMapper;

using System.Threading.Tasks;

using TestsSystem.Business.Contracts;
using TestsSystem.Core.DTO;
using TestsSystem.Core.Enums;
using TestsSystem.Core.Models.DbData;
using TestsSystem.Core.Models.Server.Answers;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.Business.Services
{
    public class ServAppUsers : IServAppUsers
    {
        private readonly IMapper _mapper;
        private readonly IRepoRootUsers _rootUsers;
        private readonly IRepoStudents _students;
        private readonly IRepoPrepods _prepods;

        public ServAppUsers(
            IMapper mapper,
            IRepoRootUsers rootUsers,
            IRepoStudents students,
            IRepoPrepods prepods)
        {
            _mapper = mapper;
            _rootUsers = rootUsers;
            _students = students;
            _prepods = prepods;
        }

        public async Task<AnswerBase> GetAppUserAsync(EUserRole role, int id = 0, string email = null)
        {
            if (role == EUserRole.Non) return new AnswerFail
            {
                Reason = "Role must be or 'student' or 'prepod' or 'admin'"
            };
            if (id == 0 && email == null) return new AnswerFail
            {
                Reason = "You must specify at least one of the 'id' or 'email' arguments"
            };
            if (email == null)
            {
                var user = await GetAppUserByIdAsync(role, id);
                if (user == null) return new AnswerFail
                { 
                    Reason = "Such a user is not registered in the system"
                };
                return new AnswerAppUser { AppUser = user };
            }
            else
            {
                var user = await GetAppUserByEmailAsync(role, email);
                if (user == null) return new AnswerFail
                { 
                    Reason = "Such a user is not registered in the system"
                };
                return new AnswerAppUser { AppUser = user };
            };
        }

        public async Task<AnswerBase> GetAppUsersAsync(EUserRole role)
            => (role) switch
            {
                EUserRole.Student => new AnswerAppUsers
                {
                    AppUsers = await _students.ToListAsync()
                },
                EUserRole.Prepod => new AnswerAppUsers
                {
                    AppUsers = await _prepods.ToListAsync()
                },
                EUserRole.Admin => new AnswerAppUsers
                {
                    AppUsers = await _rootUsers.ToListAsync()
                },
                _ => new AnswerFail
                {
                    Reason = $"For role - '{role}' no users"
                }
            };

        public Task CreateAppUserAsync(DtoAppUser appUser)
            => (appUser.Role) switch
            {
                EUserRole.Student => _students.AddStudentAsync(_mapper.Map<Student>(appUser)),
                EUserRole.Prepod => _prepods.AddPrepodAsync(_mapper.Map<Prepod>(appUser)),
                _ => _rootUsers.AddAppUserAsync(_mapper.Map<RootUser>(appUser))
            };

        public Task DeleteAppUserAsync(int id, EUserRole role)
            => (role) switch
            {
                EUserRole.Student => DeleteStudentAsync(id),
                EUserRole.Prepod => DeletePrepodAsync(id),
                _ => DeleteAdminAsync(id)
            };

        public Task UpdateAppUserAsync(DtoAppUser appUser)
            => (appUser.Role) switch
            {
                EUserRole.Student => UpdateStudentAsync(appUser),
                EUserRole.Prepod => UpdatePrepodAsync(appUser),
                _ => UpdateAdminAsync(appUser)
            };

        private async Task<AppUser> GetAppUserByIdAsync(EUserRole role, int id)
            => (role) switch
            {
                EUserRole.Admin => await _rootUsers.GetAppUserByIdAsync(id),
                EUserRole.Student => await _students.GetStudentByIdAsync(id),
                EUserRole.Prepod => await _prepods.GetPrepodByIdAsync(id),
                _ => null
            };

        private async Task<AppUser> GetAppUserByEmailAsync(EUserRole role, string email)
            => (role) switch
            {
                EUserRole.Admin => await _rootUsers.GetAppUserByEmailAsync(email),
                EUserRole.Student => await _students.GetStudentByEmailAsync(email),
                EUserRole.Prepod => await _prepods.GetPrepodByEmailAsync(email),
                _ => null
            };

        private async Task DeleteStudentAsync(int id)
        {
            var student = await _students.GetStudentByIdAsync(id);
            if (student != null) await _students.DeleteStudentAsync(student);
        }

        private async Task DeletePrepodAsync(int id)
        {
            var prepod = await _prepods.GetPrepodByIdAsync(id);
            if (prepod != null) await _prepods.DeletePrepodAsync(prepod);
        }

        private async Task DeleteAdminAsync(int id)
        {
            var admin = await _rootUsers.GetAppUserByIdAsync(id);
            if (admin != null) await _rootUsers.DeleteAppUserAsync(admin);
        }

        private async Task UpdateStudentAsync(DtoAppUser dto)
        {
            var user = await _students.GetStudentByEmailAsync(dto.Email);
            await _students.EditStudentAsync(_mapper.Map(dto, user));
        }

        private async Task UpdatePrepodAsync(DtoAppUser dto)
        {
            var user = await _prepods.GetPrepodByEmailAsync(dto.Email);
            await _prepods.EditPrepodAsync(_mapper.Map(dto, user));
        }

        private async Task UpdateAdminAsync(DtoAppUser dto)
        {
            var user = await _rootUsers.GetAppUserByEmailAsync(dto.Email);
            await _rootUsers.EditAppUserAsync(_mapper.Map(dto, user));
        }
    }
}
