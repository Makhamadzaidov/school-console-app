using School.Interfaces.Common;
using School.Models;

namespace School.Interfaces.Repositories
{
    public interface ITeacherRepository :
        ICreateable<Teacher>, IReadable<Teacher>, IUpdateable<Teacher>, IDeleteable<Teacher>
    {

    }
}
