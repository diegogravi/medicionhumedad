using System;
using System.Collections.Generic;
using System.Text;
using static MedicionHumedad.ViewModels.GenericFilter.FilterUtility;
using static MedicionHumedad.ViewModels.GenericFilter.SortingUtility;

namespace MedicionHumedad.ViewModels
{
    /// <summary>  
    /// This class contains properites used for paging, sorting, grouping, filtering and will be used as a parameter model  
    ///   
    /// SortOrder   - enum of sorting orders  
    /// SortColumn  - Name of the column on which sorting has to be done,  
    ///               as for now sorting can be performed only on one column at a time.  
    ///FilterParams - Filtering can be done on multiple columns and for one column multiple values can be selected  
    ///               key :- will be column name, Value :- will be array list of multiple values  
    ///GroupingColumns - It will contain column names in a sequence on which grouping has been applied   
    ///PageNumber   - Page Number to be displayed in UI, default to 1  
    ///PageSize     - Number of items per page, default to 25  
    /// </summary>  
    public class PaginatedInputModel
    {
        public IEnumerable<SortingParams> SortParams { set; get; }
        public IEnumerable<FilterParams> FilterParam { get; set; }
        public IEnumerable<string> GroupingColumns { get; set; } = null;
        int currentPage = 1;
        public int CurrentPage { get { return currentPage; } set { if (value > 1) currentPage = value; } }

        int pageSize = 10;
        public int PageSize { get { return pageSize; } set { if (value > 1) pageSize = value; } }

        //public class SortingParams
        //{
        //    public SortOrders SortOrder { get; set; } = SortOrders.Asc;
        //    public string ColumnName { get; set; }
        //}

        ///// <summary>  
        ///// Enum for Sorting order  
        ///// Asc = Ascending  
        ///// Desc = Descending  
        ///// </summary>  
        //public enum SortOrders
        //{
        //    Asc = 1,
        //    Desc = 2
        //}

        //public enum FilterOptions
        //{
        //    StartsWith = 1,
        //    EndsWith,
        //    Contains,
        //    DoesNotContain,
        //    IsEmpty,
        //    IsNotEmpty,
        //    IsGreaterThan,
        //    IsGreaterThanOrEqualTo,
        //    IsLessThan,
        //    IsLessThanOrEqualTo,
        //    IsEqualTo,
        //    IsNotEqualTo
        //}

        ///// <summary>  
        ///// Filter parameters Model Class  
        ///// </summary>  
        //public class FilterParams
        //{
        //    public string ColumnName { get; set; } = string.Empty;
        //    public string FilterValue { get; set; } = string.Empty;
        //    public FilterOptions FilterOption { get; set; } = FilterOptions.Contains;
        //}
    }
}
