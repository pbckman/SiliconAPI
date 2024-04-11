﻿using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CategoryFactory
{
    public static CategoryEntity Create (CategoryRegistrationForm form)
    {
        try
        {
            return new CategoryEntity
            {
                CategoryName = form.CategoryName,
            };
        }
        catch { }
        return null!;
    }

    public static Category Create(CategoryEntity entity)
    {
        try
        {
            return new Category
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,
            };
        }
        catch { }
        return null!;
    }

    public static IEnumerable<Category> Create(List<CategoryEntity> entities)
    {
        var categories = new List<Category>();

        try
        {
            foreach(var entity in entities)
                categories.Add(Create(entity));
        }
        catch { }
        return categories;
    }
}


