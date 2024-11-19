using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.Create;

public class CreateLanguageCommand : IRequest<CreatedLanguageResponse>
{
    public required string Name { get; set; }

    public required string LanguageCode { get; set; }

    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public CreateLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository,
                                         LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<CreatedLanguageResponse> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            Language language = _mapper.Map<Language>(request);

            await _languageRepository.AddAsync(language, cancellationToken);

            CreatedLanguageResponse response = _mapper.Map<CreatedLanguageResponse>(language);
            return response;
        }
    }
}