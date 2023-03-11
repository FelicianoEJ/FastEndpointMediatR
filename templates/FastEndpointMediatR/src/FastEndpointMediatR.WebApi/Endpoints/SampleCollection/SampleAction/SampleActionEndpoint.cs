using FastEndpointMediatR.WebApi.Endpoints.SampleCollection.SampleAction.Request;
using FastEndpointMediatR.WebApi.Endpoints.SampleCollection.SampleAction.Response;
using ApplicationRequest = FastEndpointMediatR.Application.Features.SampleCollection.SampleAction.Request;
using ApplicationResponse = FastEndpointMediatR.Application.Features.SampleCollection.SampleAction.Response;

namespace WebApi.Endpoints.SampleCollection.SampleAction;

public class SampleActionEndpoint : Endpoint<SampleActionRequest, SampleActionResponse>
{
    private readonly IMediator _mediator;

    public SampleActionEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("/api");
        AllowAnonymous();
    }

    public async override Task HandleAsync(SampleActionRequest req, CancellationToken ct)
    {
        var applicationRequest = MapApiRequestToApplicationRequest(req);

        var applicationResponse = await _mediator.Send(applicationRequest, ct);

        await SendAsync(MapApplicationResponseToApiResponse(applicationResponse), 200, ct);
    }

    private static ApplicationRequest.SampleActionRequest MapApiRequestToApplicationRequest(SampleActionRequest sampleActionRequest) =>
        new(sampleActionRequest.Message);

    private static SampleActionResponse MapApplicationResponseToApiResponse(ApplicationResponse.SampleActionResponse response) =>
        new(){ Message = response.Message };
}
