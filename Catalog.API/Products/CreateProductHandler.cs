

using FluentValidation;

namespace Catalog.API.Products
{
    // in this class use ICommandHandler,ICommand of buildingblocks
    // Request type implementing  :IRequest<Response Type> but i use Custom request is ICommand<CreateProductResult> which inherit from IRequest
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;// if not use buildingblocks =>IRequest<CreateProductResult> ;
    //response type
    public record CreateProductResult(Guid Id);
    //Implementing :IRequestHandler < Request Type, Response Type>
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
    internal class CreateProductCommandHandler(IDocumentSession session,IValidator<CreateProductCommand> validator) : ICommandHandler<CreateProductCommand, CreateProductResult>//IRequestHandler<CreateProductRequest, CreateProductResult>
    {
        // i am using customRequestHandler is ICommandHandler it inherit customRequestHandler
      
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            /*
             it catch thi errors in pineline
            var results = await validator.ValidateAsync(command, cancellationToken);
            var errors = results.Errors.Select(x=>x.ErrorMessage).ToList(); 
            if (errors.Any())
            {
                throw new ValidationException(errors.FirstOrDefault());
            }*/
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };
            //session.Store(product);
            //await session.SaveChangesAsync(cancellationToken);
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
