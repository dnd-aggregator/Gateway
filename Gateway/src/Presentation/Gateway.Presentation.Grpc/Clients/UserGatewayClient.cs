using Character.Validation;
using Gateway.Application.Contracts.Users;
using Gateway.Application.Models.Users;

namespace Gateway.Presentation.Grpc.Clients;

public class UserGatewayClient : IUserGatewayClient
{
    private readonly UserGrpcService.UserGrpcServiceClient _userGrpcService;

    public UserGatewayClient(UserGrpcService.UserGrpcServiceClient userGrpcService)
    {
        _userGrpcService = userGrpcService;
    }

    public async Task<long> RegisterUser(CreateUserGatewayRequest request, CancellationToken cancellationToken)
    {
        var grpcRequest = new CreateUserRequest()
        {
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
        };

        RegisterUserResponse result = await _userGrpcService.RegisterUserAsync(grpcRequest);

        return result.UserId;
    }

    public async Task<UserGatewayModel> GetUser(long userId, CancellationToken cancellationToken)
    {
        var grpcRequest = new GetUserRequest()
        {
            UserId = userId,
        };

        GetUserResponse result = await _userGrpcService.GetUserAsync(grpcRequest);

        return new UserGatewayModel(result.User.Id, result.User.Name, result.User.PhoneNumber);
    }
}