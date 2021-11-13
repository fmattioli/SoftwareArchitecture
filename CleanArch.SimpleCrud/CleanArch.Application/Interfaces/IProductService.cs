using CleanArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetById(int? Id);
        void Add(ProductViewModel product);
        void Update(int? Id);
        void Remove(int? Id );
    }
}
