using Application.Features.GenderPsas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GenderPsas.Queries.GetById;

public class GetByIdGenderPsaQuery : IRequest<GetByIdGenderPsaResponse>
{
    public Guid Id { get; set; }

    public class GetByIdGenderPsaQueryHandler : IRequestHandler<GetByIdGenderPsaQuery, GetByIdGenderPsaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenderPsaRepository _genderPsaRepository;
        private readonly GenderPsaBusinessRules _genderPsaBusinessRules;

        public GetByIdGenderPsaQueryHandler(IMapper mapper, IGenderPsaRepository genderPsaRepository, GenderPsaBusinessRules genderPsaBusinessRules)
        {
            _mapper = mapper;
            _genderPsaRepository = genderPsaRepository;
            _genderPsaBusinessRules = genderPsaBusinessRules;
        }

        public async Task<GetByIdGenderPsaResponse> Handle(GetByIdGenderPsaQuery request, CancellationToken cancellationToken)
        {
            GenderPsa? genderPsa = await _genderPsaRepository.GetAsync(predicate: gp => gp.Id == request.Id, cancellationToken: cancellationToken);
            await _genderPsaBusinessRules.GenderPsaShouldExistWhenSelected(genderPsa);

            GetByIdGenderPsaResponse response = _mapper.Map<GetByIdGenderPsaResponse>(genderPsa);
            return response;
        }
    }
}