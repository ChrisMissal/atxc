namespace Core.Features.People
{
    using MediatR;

    public class PersonCreatedNotification : IAsyncNotification
    {
        public PersonCreatedNotification(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}