using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
	private readonly Lazy<IUserService> _userService;
	private readonly Lazy<IPostService> _postService;
	private readonly Lazy<ILikeService> _likeService;
	private readonly Lazy<IUserFollowedService> _userFollowedService;

	public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IEntityCheckService entityCheck)
	{
		_userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper, entityCheck));
        _postService = new Lazy<IPostService>(() => new PostService(repositoryManager, logger, mapper, entityCheck));
        _likeService = new Lazy<ILikeService>(() => new LikeService(repositoryManager, logger, mapper, entityCheck));
        _userFollowedService = new Lazy<IUserFollowedService>(() => new UserFollowedService(repositoryManager, logger, mapper, entityCheck));
	}

	public IUserService UserService => _userService.Value;
	public IPostService PostService => _postService.Value;
	public ILikeService LikeService => _likeService.Value;
	public IUserFollowedService UserFollowedService => _userFollowedService.Value;
}
