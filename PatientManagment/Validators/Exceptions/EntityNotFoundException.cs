namespace PatientManagement.Core.Validators.Exceptions
{
    public sealed class EntityNotFoundException : NotFoundException
    {
        public EntityNotFoundException(Object entity)
            : base($"The entity of type {entity} with this identifier was not found.")
        {
        }
    }
}
