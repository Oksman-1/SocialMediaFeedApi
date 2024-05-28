using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _repositoryContext;
	private readonly Lazy<IUserRepository> _userRepository;
	private readonly Lazy<IPostRepository> _postRepository;
	private readonly Lazy<ILikeRepository> _likeRepository;
	private readonly Lazy<IUserFollowedRepository> _userFollowedRepository;

	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
        _postRepository = new Lazy<IPostRepository>(() => new PostRepository(repositoryContext));
        _likeRepository = new Lazy<ILikeRepository>(() => new LikeRepository(repositoryContext));
        _userFollowedRepository = new Lazy<IUserFollowedRepository>(() => new UserFollowedRepository(repositoryContext));
	}

	public IUserRepository User => _userRepository.Value;
	public IPostRepository Post => _postRepository.Value;
	public ILikeRepository Like => _likeRepository.Value;
	public IUserFollowedRepository UserFollowed => _userFollowedRepository.Value;
	public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

		
	
}