namespace PatientManagement.Core.Validators.Exceptions
{
    public sealed class EntityNotFoundException : NotFoundException
    {
        public EntityNotFoundException(int Id,Object entity)
            : base($"The entity of type {entity} with the identifier {Id} was not found.")
        {
        }
    }
}
