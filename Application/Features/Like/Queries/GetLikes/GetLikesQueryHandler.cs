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
            List<Domain.Like> likes = new List<Domain.Like>();


            if(request.HeadingId != Guid.Empty)
            {
                likes = await _likeRepository.GetAllAsync(x => x.HeadingId == request.HeadingId);
            }
            else if(request.PostId != Guid.Empty)
            {
                likes = await _likeRepository.GetAllAsync(x => x.PostId == request.PostId);
            }
            else if(request.UserName != null)
            {
                likes = await _likeRepository.GetAllAsync(x => x.UserName == request.UserName);
            }

            // convert data objecs to DTOs
            var data = _mapper.Map<List<LikeDTO>>(likes);

            // return list of DTOs
            return data;
        }
    }
}
