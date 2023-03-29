using Example.Core.Application.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models;
using System.Threading;
using System.Threading.Tasks;

namespace Example.App;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IUserService _userService;

    public Worker(ILogger<Worker> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int userId = 1;
        User user = _userService.GetById(userId);

        if (user == null)
            _logger.LogInformation("The user with id {userId} was not found.", userId);
        else
            _logger.LogInformation("The user {Name} was found.", user.Name);
    }
}