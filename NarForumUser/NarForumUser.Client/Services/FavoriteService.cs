using AutoMapper;
using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models.Favorite;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;

public class FavoriteService : BaseHttpService, IFavoriteService
{
    private readonly IMapper _mapper;
    public FavoriteService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<ApiResponse<Guid>> AddFavorite(FavoriteVM like)
    {
        try
        {
            var command = _mapper.Map<AddFavoriteCommand>(like);
            await _client.AddFavoriteAsync(command);
            return new ApiResponse<Guid>
            {
                Success = true
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<List<FavoriteVM>> GetFavorites()
    {
        var likes = await _client.GetFavoritesAsync();
        var data = _mapper.Map<List<FavoriteVM>>(likes);

        return data;
    }

    public async Task<List<FavoriteVM>> GetFavoritesByHeadingId(Guid headingId)
    {
        var likes = await _client.GetFavoritesByHeadingIdAsync(headingId);
        var data = _mapper.Map<List<FavoriteVM>>(likes);

        return data;
    }

    public async Task<List<FavoriteVM>> GetFavoritesByHeadingIdAndUserName(Guid headingId, string username)
    {
        var likes = await _client.GetFavoritesByHeadingIdAndUserNameAsync(headingId, username);
        var data = _mapper.Map<List<FavoriteVM>>(likes);

        return data;
    }


    public async Task<List<FavoriteVM>> GetFavoritesByUserName(string username)
    {
        var likes = await _client.GetFavoritesByUserNameAsync(username);
        var data = _mapper.Map<List<FavoriteVM>>(likes);

        return data;
    }

    public async Task<FavoritesPaginationVM> GetFavoritesWithPagination(GetFavoritesWithPaginationQueryVM request)
    {
        GetFavoritesWithPaginationQuery query = _mapper.Map<GetFavoritesWithPaginationQuery>(request);

        var headingsPagination = await _client.GetFavoritesWithPaginationAsync(query);

        var data = _mapper.Map<FavoritesPaginationVM>(headingsPagination);

        return data;
    }
}
