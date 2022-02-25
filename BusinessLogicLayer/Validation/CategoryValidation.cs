using DataAccessLayer.Abstract;
using Entity.POCO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Validation
{
    public class CategoryValidation : AbstractValidator<Category> //Fluent Validation
    {
        private readonly ICategoryDAL categoryDAL;

        public CategoryValidation(ICategoryDAL categoryDAL)
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name alanı boş geçilemez.");
            RuleFor(x => x.Name).Must(CategoryNameValidation).WithMessage("Bu isimde bir kategori bulunmaktadır"); //özel metodumuz
            this.categoryDAL = categoryDAL;
        }
        //FluentValitaion ile kendi özel metodumuz
        public bool CategoryNameValidation(string Cname)
        {
            Category entity = categoryDAL.Get().AsQueryable().FirstOrDefault(x => x.Name == Cname); //asQueryable kabul etmesinin sebebi alt taraftan IQueryable geldigi için.
            return entity == null ? true : false;
        }
    }
}
