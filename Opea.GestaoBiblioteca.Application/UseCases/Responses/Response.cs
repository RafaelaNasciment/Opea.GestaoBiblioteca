using Flunt.Notifications;

namespace Opea.GestaoBiblioteca.Application.UseCases.Responses
{
    public sealed class Response<TDataResponse>
    {
        public bool Success { get; }
        public TDataResponse? Data { get; }
        public IReadOnlyCollection<Notification> Notifications { get; }

        private static readonly IReadOnlyCollection<Notification> Empty = [];

        private Response(bool success, TDataResponse? data, IReadOnlyCollection<Notification> notifications)
        {
            Success = success;
            Data = data;
            Notifications = notifications ?? Empty;
        }

        public static Response<TDataResponse> Ok(TDataResponse data) =>
            new Response<TDataResponse>(success: true, data: data, notifications: Empty);

        public static Response<TDataResponse> Fail(IEnumerable<Notification> notifications) =>
            new(success: false, data: default, notifications: (notifications ?? Enumerable.Empty<Notification>()).ToArray());

        public static Response<TDataResponse> Fail(Notification notification) =>
            new(success: false, data: default, notifications: [notification]);

        public static Response<TDataResponse> Fail(string key, string message) =>
            new(success: false, data: default, notifications: [new Notification(key, message)]);
    }
}
