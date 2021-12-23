using MedicionHumedad.ViewModels.GenericFilter;
using MedicionHumedad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace MedicionHumedad.Services
{
    public static class Utility<T>
    {

        public static async Task<PaginatedList<T>> EntityFilter(PaginatedInputModel inputModel, List<T> entity, int count)
        {

            #region [Filter]  
            if (inputModel != null && inputModel.FilterParam.Any())
            {
                entity = FilterUtility.Filter<T>.FilteredData(inputModel.FilterParam, entity).ToList() ?? entity;
            }
            #endregion

            #region [Sorting]  
            if (inputModel != null && inputModel.SortParams.Count() > 0) // && Enum.IsDefined(typeof(SortingUtility.SortOrders), inputModel.SortParams.Select(x => x.SortOrder)))
            {
                entity = SortingUtility.Sorting<T>.SortData(entity, inputModel.SortParams).ToList();
            }
            #endregion

            #region [Grouping]  
            if (inputModel != null && inputModel.GroupingColumns != null && inputModel.GroupingColumns.Count() > 0)
            {
                entity = SortingUtility.Sorting<T>.GroupingData(entity, inputModel.GroupingColumns).ToList() ?? entity;
            }
            #endregion
            count = entity.Count;
            #region [Paging]  
            return await PaginatedList<T>.CreateAsync(entity, count, inputModel.CurrentPage, inputModel.PageSize);
            #endregion
        }
    }
    public static class Extensions
    {
        public static StringContent AsJson(this object o)
            => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
    }
}
