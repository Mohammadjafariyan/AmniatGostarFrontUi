namespace AmniatGostarFrontUi.Commands;

using AmniatGostarCoreModel.Database.Tables;
using Microsoft.AspNetCore.Mvc;
using Models;
using Threenine.Data;
using Threenine.Data.Paging;
using static AmniatGostarFrontUi.Models.ProductViewModels;

public class GetProductOptionsCommand
{
    private readonly IRepositoryReadOnly<Product> productRepository;

    public GetProductOptionsCommand(IUnitOfWork uow) =>
        this.productRepository = uow.GetReadOnlyRepository<Product>();

    public IActionResult Execute(ProductSearch productSearch)
    {
        var term = productSearch.Term;
        IPaginate<Product> list;

        if (string.IsNullOrEmpty(productSearch.Term))
        {
            list = this.productRepository.GetList(s => s.Name.Contains(term),
                null!, include: null!, productSearch.Page);
        }
        else
        {
            list = this.productRepository.GetList(null!,
                null!, include: null!, productSearch.Page);
        }


        return new OkObjectResult(new Select2Result
        {
            Pagination = new Select2Result.PaginationCls { More = list.HasNext },
            Results = list.Items.Select(s => new Select2Result.S2DropdownResult { Id = s.Name, Text = s.Name })
                .ToList()
        });
    }
}
