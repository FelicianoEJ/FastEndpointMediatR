using FastEndpointMediatR.WebApi.Endpoints.SampleCollection.SampleAction.Request;

namespace WebApi.Endpoints.SampleCollection.SampleAction;

public class SampleActionValidator : Validator<SampleActionRequest>
{
    public SampleActionValidator()
    {
        RuleFor(r => r.Message).NotNull().WithMessage("Please provide a message.");
    }
}
