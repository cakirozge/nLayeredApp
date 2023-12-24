using Business.Abstracts;
//using Core.DataAccess.Paging;
//using DataAccess.Abstracts;
//using Entities.Concretes;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using Core.DataAccess.Paging;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        //injeksiyon yaptık.
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
       

        public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
        {
            Product product = new Product();
            product.CategoryId = createProductRequest.CategoryId;
            //product.Id = int.NewGuid();
            product.ProductName = createProductRequest.ProductName;
            product.UnitPrice = createProductRequest.UnitPrice;
            product.UnitsInStock = createProductRequest.UnitsInStock;
            product.QuantityPerUnit = createProductRequest.QuantityPerUnit;


            Product createdProduct = await _productDal.AddAsync(product);

            CreatedProductResponse createdProductResponse = new CreatedProductResponse();

            createdProductResponse.Id = createdProduct.Id;
            createdProductResponse.ProductName = createProductRequest.ProductName;
            createdProductResponse.UnitPrice = createProductRequest.UnitPrice;
            createdProductResponse.UnitsInStock = createProductRequest.UnitsInStock;
            createdProductResponse.QuantityPerUnit = createProductRequest.QuantityPerUnit;

            return createdProductResponse;
        }
        public async Task<IPaginate<Product>> GetListAsync()
        {
            var result = await _productDal.GetListAsync();
            return result;

        }

        //GetListProductResponse
        //public async Task<IPaginate<Product>> GetListAsync()
        //{
        //var result = await _productDal.GetListAsync();
        //return result;
        //}

    }
}


//1-GetList operasyonunu response ekle.
//Tobetodaki tüm nesneleri response request patternine göre ekle
//Sistemi automappera çek


