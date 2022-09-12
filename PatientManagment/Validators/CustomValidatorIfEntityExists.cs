using FluentValidation;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators
{
    public static class CustomValidatorIfEntityExists
    {
        private const string NotFound = "was not found";
        public static IRuleBuilderOptions<T, int> IsEntityExist<T, TEntity>(this IRuleBuilder<T, int> ruleBuilder, IGenericRepository<TEntity> repo, string? entityName = "Entity") where TEntity : class
        {

            return ruleBuilder.Must((context, id) =>
                {
                    var entity =  repo.GetByIdAsync(id).Result;

                    if (entity != null)
                    {
                        return true;
                    }

                    return false;
                })
                .WithMessage(entityName + NotFound);
        }
    }
}
