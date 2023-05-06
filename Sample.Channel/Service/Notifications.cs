using Sample.Channel.Data;
using Sample.Channel.Data.Domain;

namespace Sample.Channel.Service
{
    public class Notifications
    {
        private readonly IServiceProvider _serviceProvider;

        public Notifications(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }
        public bool Send()
        {
            Task.Run(async () =>
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var _database = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                        var msg = "register the notification.";
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
                    var a = e;
                }

            });
            return true;

        }
    }
}
