namespace AmniatGostarFrontUi.Models;

public class ProductViewModels
{
    public class ProductSearch
    {
        public int Page { get; set; }

        public string Term { get; set; }

        public ProductSearch(string term, int? page)
        {
            page ??= 1;
            this.Term = term;
            this.Page = page.Value;
        }
    }
}

public class Select2Result
{
    public class PaginationCls
    {
        public bool More { get; set; }
    }

    public class S2DropdownResult
    {
        public string? Id { get; set; }
        public string? Text { get; set; }
        public bool Disabled { get; set; }
        public bool Selected { get; set; }
    }

    public List<S2DropdownResult>? Results { get; set; }
    public PaginationCls? Pagination { get; set; }
}
