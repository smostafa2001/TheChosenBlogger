﻿using MasterBlogger.Application.Contracts.ArticleCategory;
using MasterBlogger.Domain.ArticleCategoryAggregate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MasterBlogger.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void Add(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title);
            _articleCategoryRepository.Add(articleCategory);
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            _articleCategoryRepository.Save();
        }

        public RenameArticleCategory Get(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
            };
        }
        public void Remove(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _articleCategoryRepository.Save();
        }

        public void Activate(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            _articleCategoryRepository.Save();
        }

        public List<ArticleCategoryViewModel> List() => _articleCategoryRepository.GetAll()
            .Select(ac => new ArticleCategoryViewModel
            {
                Id = ac.Id,
                Title = ac.Title,
                IsDeleted = ac.IsDeleted,
                CreationDate = ac.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();

    }
}
