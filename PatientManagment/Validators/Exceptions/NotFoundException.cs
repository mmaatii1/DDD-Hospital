namespace PatientManagement.Core.Validators.Exceptions
{
    public abstract class NotFoundException : PipelineException
    {
        protected NotFoundException(string message)
            : base("Not Found", message)
        {
        }
    }
}
