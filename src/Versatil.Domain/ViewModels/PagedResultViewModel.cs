using System;
using System.Collections.Generic;
using System.Text;

namespace Versatil.Domain.ViewModels
{
    public class PagedResultViewModel<T>
    {
        public int TotalItens { get; init; }
        public IEnumerable<T> Itens { get; set; }
    }
}
