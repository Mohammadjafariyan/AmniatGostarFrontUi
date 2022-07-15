namespace AmniatGostarFrontUi.Controllers;

using AmniatGostarFrontUi.Commands;
using AmniatGostarFrontUi.Constants;
using Boxed.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

[Route("[controller]")]
[ApiController]
[ApiVersion(ApiVersionName.V1)]
[SwaggerResponse(
    StatusCodes.Status500InternalServerError,
    "The MIME type in the Accept HTTP header is not acceptable.",
    typeof(ProblemDetails),
    ContentType.ProblemJson)]
public class ProductsController : ControllerBase
{
    /// <summary>
    /// Gets the Product with the specified unique identifier.
    /// </summary>
    /// <param name="command">The action command.</param>
    /// <param name="page"></param>
    /// <param name="term"></param>
    /// <returns>A 200 OK response containing the Product or a 404 Not Found if a Product with the specified unique
    /// identifier was not found.</returns>
    [HttpGet]
    [SwaggerResponse(
        StatusCodes.Status200OK,
        "The Product with the specified unique identifier.",
        typeof(Select2Result),
        ContentType.RestfulJson,
        ContentType.Json)]
    [SwaggerResponse(
        StatusCodes.Status304NotModified,
        "The Product has not changed since the date given in the If-Modified-Since HTTP header.")]
    [SwaggerResponse(
        StatusCodes.Status404NotFound,
        "A Product with the specified unique identifier could not be found.",
        typeof(ProblemDetails),
        ContentType.ProblemJson)]
    [SwaggerResponse(
        StatusCodes.Status406NotAcceptable,
        "The MIME type in the Accept HTTP header is not acceptable.",
        typeof(ProblemDetails),
        ContentType.ProblemJson)]
    [ResponseCache]
    public IActionResult GetProductOptions(
        [FromServices] GetProductOptionsCommand command,
        [FromQuery] string term,
        [FromQuery] int page) =>
        command.Execute(new ProductViewModels.ProductSearch(term, page));
}
