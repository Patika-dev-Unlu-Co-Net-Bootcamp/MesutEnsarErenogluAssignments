
using System.Collections.Generic;

namespace UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Common
{
    public class FilterResponseModel<T> where T: class
    {
        public List<T> DataList { get; set; }

        public FilterPaggingInfo PaggingInfo { get; set; }
    }
}
