using GenericRepository.Contract.Dtos;
using GenericRepository.Contract.Interfaces.ApplicationServices;
using GenericRepository.Contract.Interfaces.Repositories;
using GenericRepository.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.ApplicationService.Services
{
    public class AddProductService : IAddProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductService(IRepository<Product> productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<int> Execute(AddProductRequest request)
        {
            var product = new Product
            {
                Name= request.Name,
                Price= request.Price,
            };
            await _productRepository.InsertAsync(product);
            await _unitOfWork.CommitChangesAsync();
            return product.Id;
        }
    }
}
