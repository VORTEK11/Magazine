using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.VMs.Product;

namespace Проект.BLL.Interfaces
{
    interface IProductService
    {
        bool CreateProduct(CreateUpdateProductVM newProduct);
        OpenProductVM GetProduct(Guid productId);
        List<OpenProductListVM> GetAllProducts();
        bool UpdateProduct(Guid productId, OpenProductVM editedProduct);
        bool DeleteProduct(Guid productId);


    } 
}
