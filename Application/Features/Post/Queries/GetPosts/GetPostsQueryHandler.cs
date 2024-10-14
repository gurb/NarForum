using Application.Contracts.Persistence;
using Application.Features.Post.Queries.GetAllPosts;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Queries.GetPosts
{
    public class GetPostsQueryHandler: IRequestHandler<GetPostsQuery, List<PostDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public GetPostsQueryHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<List<PostDTO>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            // query the database
            List<Domain.Post> posts;

            if(request.HeadingId != Guid.Empty)
            {
                posts = await _postRepository.GetPostsByHeadingId(request.HeadingId);
            }
            else
            {
                posts = await _postRepository.GetAsync();
            }

            // convert data objecs to DTOs
            var data = _mapper.Map<List<PostDTO>>(posts);

            // return list of DTOs
            return data;
        }
    }
}
