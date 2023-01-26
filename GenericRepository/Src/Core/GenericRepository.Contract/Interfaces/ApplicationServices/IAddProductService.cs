using GenericRepository.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Contract.Interfaces.ApplicationServices
{
    public interface IAddProductService
    {
        Task<int> Execute(AddProductRequest request);
    }
}
