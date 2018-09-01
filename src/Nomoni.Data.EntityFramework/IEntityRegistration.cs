using Microsoft.EntityFrameworkCore;

namespace Nomoni.Data.EntityFramework
{
    public interface IEntityRegistration
    {
        void RegisterEntities(ModelBuilder modelbuilder);
    }
}
