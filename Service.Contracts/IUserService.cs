using Shared.DataTranferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsersAsync(bool trackChanges);
    Task<UserDTO> GetUserByIdAsync(Guid userId, bool trackChanges);
    Task<UserDTO> CreateUserAsync(UserForCreationDTO user);
    Task DeleteUserAsync(Guid userId, bool trackChanges);
}
