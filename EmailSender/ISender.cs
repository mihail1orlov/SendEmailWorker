using System.Threading;

namespace EmailSender
{
    public interface ISender
    {
        void Send(CancellationToken cancellationToken);
    }
}