using Sample.Channel.Data;
using Sample.Channel.Data.Domain;
using System.Threading.Channels;

namespace Sample.Channel.Service
{
    public class NotificationDispatcher : BackgroundService
    {
        private readonly Channel<string> _channel;
        private readonly IServiceProvider _serviceProvider;
        readonly ILogger<NotificationDispatcher> _logger;
        public NotificationDispatcher(
            Channel<string> channel,
            IServiceProvider serviceProvider,
            ILogger<NotificationDispatcher> logger
            )
        {
            _channel = channel;
            _serviceProvider = serviceProvider;
            _logger = logger;

        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!_channel.Reader.Completion.IsCompleted)
            {
                {
                    try
                    {
                        using (var scope = _serviceProvider.CreateScope())
                        {
                            var _database = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                            var msg = await _channel.Reader.ReadAsync();
                            var notification = new Notification()
                            {
                                Message = msg,
                            };

                            await _database.Notification.AddAsync(notification);
                            await _database.SaveChangesAsync();

                        }

                    }
                    catch (Exception e)
                    {
                        _logger.LogError("Error throwed");
                    }

                }
            }
        }
    }
}
