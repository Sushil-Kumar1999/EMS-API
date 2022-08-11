using System;

namespace EMS.Core.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entity, long id)
            : base($"Entity {entity} with id: {id} could not be found.")
        {
        }

        public EntityNotFoundException(string entity, string id)
            : base($"Entity {entity} with id: {id} could not be found.")
        {
        }
    }
}
