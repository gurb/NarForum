using Application.Contracts.Persistence;
using Application.Features.Post.Queries.GetAllPosts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Post.Queries.GetPostsWithPagination
{
    public class GetPostsWithPaginationQueryHandler : IRequestHandler<GetPostsWithPaginationQuery, PostsPaginationDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public GetPostsWithPaginationQueryHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<PostsPaginationDTO> Handle(GetPostsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            // query the database
            List<Domain.Post> posts;

            posts = await _postRepository.GetPostsByHeadingIdWithPagination(request.HeadingId!.Value, request.PageIndex!.Value, request.PageSize!.Value);

            // convert data objecs to DTOs
            var data = _mapper.Map<List<PostDTO>>(posts);

            PostsPaginationDTO dto = new PostsPaginationDTO
            {
                Posts = data,
                TotalCount =  _postRepository.GetPostsCountByHeadingId(request.HeadingId.Value)
            };

            // return list of DTOs
            return dto;
        }
    }
}
