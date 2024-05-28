namespace Service.Contracts;

public interface IServiceManager
{
	IUserService UserService { get; }
	IPostService PostService { get; }
	ILikeService LikeService { get; }
	IUserFollowedService UserFollowedService { get; }

}
