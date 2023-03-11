using FastEndpointMediatR.Application.Features.SampleCollection.SampleAction.Request;
using FastEndpointMediatR.Application.Features.SampleCollection.SampleAction.Response;

namespace FastEndpointMediatR.Application.Features.SampleCollection.SampleAction;

public class SampleActionHandler : IRequestHandler<SampleActionRequest, SampleActionResponse>
{
    public Task<SampleActionResponse> Handle(SampleActionRequest request, CancellationToken cancellationToken)
    {
        return request.Message == "fail"
            ? Task.FromException<SampleActionResponse>(new Exception("Sample Exception"))
            : Task.FromResult(new SampleActionResponse(request.Message ?? "Hello, world!"));

    }
}
