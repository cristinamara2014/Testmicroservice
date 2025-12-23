using MediatR;
using Catalog.API.Models;

namespace Catalog.API.Product.CreateProduct
{
  public class CreateProductCommand : IRequest<CreateProductResult>
  {
      public string Name { get; set; } = default!;
      public List<string>? Category { get; set; }
      public string Description { get; set; } = default!;
      public string ImageFile { get; set; } = default!;
      public decimal Price { get; set; }
  }

    
public record CreateProductResult(Guid Id);
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Catalog.API.Models.Product
            {
                Name = command.Name,
                Category = command.Category ?? new List<string>(),
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //save to database
            //session.Store(product);
            //await session.SaveChangesAsync(cancellationToken);

            //return result
            return new CreateProductResult(product.Id);
        }
    }
}
