﻿using Application.Contracts.Persistence;
using Application.Features.Section.Commands.RemoveSection;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.RemoveCategory
{

    public class RemoveSectionCommandHandler : IRequestHandler<RemoveSectionCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;

        public RemoveSectionCommandHandler(IMapper mapper, ISectionRepository sectionRepository)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
        }

        public async Task<int> Handle(RemoveSectionCommand request, CancellationToken cancellationToken)
        {
            if (request.SectionId == null)
            {
                throw new NullReferenceException();
            }

            try
            {
                var section = await _sectionRepository.GetByIdAsyncWithTrack(request.SectionId!.Value);

                if (section != null)
                {
                    section.IsActive = !section.IsActive;
                    await _sectionRepository.UpdateAsync(section);
                    return section.Id;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return 0;

            // return record id
        }
    }
}