
namespace Catalog.API.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        // how it work, first ProductNotFoundException received guid id and pass into base
        // this ProductNotFoundException inherit from NotFoundException of building blocks
        // NotFoundException received key and value from base("Product", Id) 

        // this is call constructor wwith message and id , if i just pass message it will call other constructor 
        public ProductNotFoundException(Guid Id) : base("Product", Id)
        {
            // param of ProductNotFoundException(Guid Id) its received value and handling with this value internal funtion
        }
    }
}
