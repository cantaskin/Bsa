using Application.Features.GenderPsas.Constants;
using Application.Features.GenderPsas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GenderPsas.Commands.Delete;

public class DeleteGenderPsaCommand : IRequest<DeletedGenderPsaResponse>
{
    public Guid Id { get; set; }

    public class DeleteGenderPsaCommandHandler : IRequestHandler<DeleteGenderPsaCommand, DeletedGenderPsaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenderPsaRepository _genderPsaRepository;
        private readonly GenderPsaBusinessRules _genderPsaBusinessRules;

        public DeleteGenderPsaCommandHandler(IMapper mapper, IGenderPsaRepository genderPsaRepository,
                                         GenderPsaBusinessRules genderPsaBusinessRules)
        {
            _mapper = mapper;
            _genderPsaRepository = genderPsaRepository;
            _genderPsaBusinessRules = genderPsaBusinessRules;
        }

        public async Task<DeletedGenderPsaResponse> Handle(DeleteGenderPsaCommand request, CancellationToken cancellationToken)
        {
            GenderPsa? genderPsa = await _genderPsaRepository.GetAsync(predicate: gp => gp.Id == request.Id, cancellationToken: cancellationToken);
            await _genderPsaBusinessRules.GenderPsaShouldExistWhenSelected(genderPsa);

            await _genderPsaRepository.DeleteAsync(genderPsa!);

            DeletedGenderPsaResponse response = _mapper.Map<DeletedGenderPsaResponse>(genderPsa);
            return response;
        }
    }
}