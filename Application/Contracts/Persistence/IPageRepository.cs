using Domain;

namespace Application.Contracts.Persistence;

public interface IPageRepository: IGenericRepository<StaticPage>
{
    Task<StaticPage?> GetStaticPageByUrl(string Url, bool isTrack = false);
}
