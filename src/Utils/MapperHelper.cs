using Ardalis.GuardClauses;

namespace CarRentalManagement.Utils;

public static class MapperHelper
{
    public static void MapFromViewModel<TViewModel, TEntity>(TEntity entity, TViewModel viewModel) 
        where TViewModel : class 
        where TEntity : class
    {
        
        Guard.Against.Null(entity);
        Guard.Against.Null(viewModel);

        var entityType = typeof(TEntity);
        var viewModelType = typeof(TViewModel);

        foreach (var viewModelProperty in viewModelType.GetProperties())
        {
            var entityProperty = entityType.GetProperty(viewModelProperty.Name);
                
            if (entityProperty == null || entityProperty.PropertyType != viewModelProperty.PropertyType || !entityProperty.CanWrite) 
                continue;
            
            var viewModelValue = viewModelProperty.GetValue(viewModel);
            var entityValue = entityProperty.GetValue(entity);
            if (viewModelValue != null && !viewModelValue.Equals(entityValue))
            {
                entityProperty.SetValue(entity, viewModelValue);
            }
        }
    }
}