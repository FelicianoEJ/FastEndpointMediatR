using FastEndpointMediatR.Application.Features.SampleCollection.SampleAction.Response;

namespace FastEndpointMediatR.Application.Features.SampleCollection.SampleAction.Request;

public record SampleActionRequest(string? Message) : IRequest<SampleActionResponse>;
