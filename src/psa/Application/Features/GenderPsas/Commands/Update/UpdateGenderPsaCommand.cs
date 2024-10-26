using Application.Features.GenderPsas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GenderPsas.Commands.Update;

public class UpdateGenderPsaCommand : IRequest<UpdatedGenderPsaResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public class UpdateGenderPsaCommandHandler : IRequestHandler<UpdateGenderPsaCommand, UpdatedGenderPsaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenderPsaRepository _genderPsaRepository;
        private readonly GenderPsaBusinessRules _genderPsaBusinessRules;

        public UpdateGenderPsaCommandHandler(IMapper mapper, IGenderPsaRepository genderPsaRepository,
                                         GenderPsaBusinessRules genderPsaBusinessRules)
        {
            _mapper = mapper;
            _genderPsaRepository = genderPsaRepository;
            _genderPsaBusinessRules = genderPsaBusinessRules;
        }

        public async Task<UpdatedGenderPsaResponse> Handle(UpdateGenderPsaCommand request, CancellationToken cancellationToken)
        {
            GenderPsa? genderPsa = await _genderPsaRepository.GetAsync(predicate: gp => gp.Id == request.Id, cancellationToken: cancellationToken);
            await _genderPsaBusinessRules.GenderPsaShouldExistWhenSelected(genderPsa);
            genderPsa = _mapper.Map(request, genderPsa);

            await _genderPsaRepository.UpdateAsync(genderPsa!);

            UpdatedGenderPsaResponse response = _mapper.Map<UpdatedGenderPsaResponse>(genderPsa);
            return response;
        }
    }
}