namespace PatientManagement.Core.Validators.Exceptions
{
    public abstract class BadRequestException : PipelineException
    {
        protected BadRequestException(string message)
            : base("Bad Request", message)
        {
        }
    }
}