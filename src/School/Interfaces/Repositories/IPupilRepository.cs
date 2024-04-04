using School.Interfaces.Common;
using School.Models;

namespace School.Interfaces.Repositories
{
    public interface IPupilRepository :
        ICreateable<Pupil>, IReadable<Pupil>, IUpdateable<Pupil>, IDeleteable<Pupil>
    {

    }
}
