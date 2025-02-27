using System.Text.RegularExpressions;
using Syscord.Core;
using Syscord.Users.Domain.Types;
using Syscord.Users.Domain.Types.StorageAbstractions;
using Syscord.Users.Service.Services.Creation.Requests;

namespace Syscord.Users.Service.Services.Creation.Handlers;

public sealed class UserRequisitesPreparationHandler(IUsersStorage usersStorage)
    : IHandler<UserCreationRequest, PreparedRequisites>
{
    private readonly Regex regex = new(@"\w+");

    public async Task<PreparedRequisites> HandleAsync(UserCreationRequest request)
    {
        var login = await ValidateAndPrepareLoginAsync(request.RawLogin);

        return new PreparedRequisites(
            new Dictionary<string, string>
            {
                { RequisiteNames.Login, login }
            });
    }

    private async Task<string> ValidateAndPrepareLoginAsync(string rawLogin)
    {
        if (string.IsNullOrEmpty(rawLogin) || !regex.IsMatch(rawLogin))
        {
            throw new IllegalProgramException();
        }

        var formatedLogin = rawLogin.ToLower();

        if (await usersStorage.IsUniqueRequisiteValueTakenAsync(RequisiteNames.Login, formatedLogin))
        {
            throw new IllegalProgramException();
        }

        return formatedLogin;
    }
}