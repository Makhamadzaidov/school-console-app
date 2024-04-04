using School.Interfaces.Common;
using School.Models;

namespace School.Interfaces.Repositories
{
    public interface IRoomRepository :
        ICreateable<Room>, IReadable<Room>, IUpdateable<Room>, IDeleteable<Room>
    {

    }
}
