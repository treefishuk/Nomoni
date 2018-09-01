using Microsoft.EntityFrameworkCore;

namespace Nomoni.Data.EntityFramework.Abstractions
{
    public interface IEntityRegistration
    {
        void RegisterEntities(ModelBuilder modelbuilder);
    }
}
