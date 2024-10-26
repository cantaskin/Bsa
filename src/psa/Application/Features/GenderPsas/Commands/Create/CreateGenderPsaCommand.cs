using Application.Features.GenderPsas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GenderPsas.Commands.Create;

public class CreateGenderPsaCommand : IRequest<CreatedGenderPsaResponse>
{
    public required string Name { get; set; }

    public class CreateGenderPsaCommandHandler : IRequestHandler<CreateGenderPsaCommand, CreatedGenderPsaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenderPsaRepository _genderPsaRepository;
        private readonly GenderPsaBusinessRules _genderPsaBusinessRules;

        public CreateGenderPsaCommandHandler(IMapper mapper, IGenderPsaRepository genderPsaRepository,
                                         GenderPsaBusinessRules genderPsaBusinessRules)
        {
            _mapper = mapper;
            _genderPsaRepository = genderPsaRepository;
            _genderPsaBusinessRules = genderPsaBusinessRules;
        }

        public async Task<CreatedGenderPsaResponse> Handle(CreateGenderPsaCommand request, CancellationToken cancellationToken)
        {
            GenderPsa genderPsa = _mapper.Map<GenderPsa>(request);

            await _genderPsaRepository.AddAsync(genderPsa);

            CreatedGenderPsaResponse response = _mapper.Map<CreatedGenderPsaResponse>(genderPsa);
            return response;
        }
    }
}