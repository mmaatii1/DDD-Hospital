namespace PatientManagement.Core.Validators.Exceptions
{
    public abstract class PipelineException : Exception
    {
        protected PipelineException(string title, string message)
            : base(message) =>
            Title = title;

        public string Title { get; }
    }
}
