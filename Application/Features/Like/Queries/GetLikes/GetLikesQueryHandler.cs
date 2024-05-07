using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Like.Queries.GetLikes
{
    public class GetLikesQueryHandler : IRequestHandler<GetLikesQuery, List<LikeDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;

        public GetLikesQueryHandler(IMapper mapper, ILikeRepository likeRepository)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
        }

        public async Task<List<LikeDTO>> Handle(GetLikesQuery request, CancellationToken cancellationToken)
        {
            // query the database
            var favorites = new List<Domain.Like>();

            // convert data objecs to DTOs
            var data = _mapper.Map<List<LikeDTO>>(favorites);

            // return list of DTOs
            return data;
        }
    }
}
