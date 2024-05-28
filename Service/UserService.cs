using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTranferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Service;

internal sealed class UserService : IUserService
{
    private readonly IRepositoryManager _repository;
    private readonly IEntityCheckService _entityCheck;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    
    public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IEntityCheckService entityCheck)
    {
        _repository = repository;
        _entityCheck = entityCheck;
        _logger = logger;
        _mapper = mapper;        
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsersAsync(bool trackChanges)
    {
        var users = await _repository.User.GetAllUsersAsync(trackChanges);

        var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);

        return usersDto;
    }

    public async Task<UserDTO> GetUserByIdAsync(Guid userId, bool trackChanges)
    {

        var user = await _entityCheck.CheckIfUserExists(userId, trackChanges);

        var userDto = _mapper.Map<UserDTO>(user);

        return userDto;
    }

    public async Task<UserDTO> CreateUserAsync(UserForCreationDTO user)
    {
        var userEntity = _mapper.Map<User>(user);

        _repository.User.CreateUser(userEntity);

        await _repository.SaveAsync();

        var userToReturn = _mapper.Map<UserDTO>(userEntity);

        return userToReturn;
    }

    public async Task DeleteUserAsync(Guid userId, bool trackChanges)
    {
        var user = await _entityCheck.CheckIfUserExists(userId, trackChanges);

        _repository.User.DeleteUser(user);

        await _repository.SaveAsync();
    }
}

