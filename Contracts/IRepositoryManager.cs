namespace Contracts;

public interface IRepositoryManager
{
	IUserRepository User { get; }
	IPostRepository Post { get; }
    ILikeRepository Like { get; }
	IUserFollowedRepository UserFollowed { get; }
	Task SaveAsync();
}
