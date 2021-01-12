using AutoMapper;
using Dummy.Models;
using Dummy.ViewModel;

namespace Dummy.AutoMapper
{
    public class ToViewModelMappingProfile : Profile
    {
        public ToViewModelMappingProfile()
        {   
            CreateMap<Category, GroupByCategoryViewModel>();
            CreateMap<Product, GroupByCategoryProductViewModel>();                
            
            
        }
    }
}