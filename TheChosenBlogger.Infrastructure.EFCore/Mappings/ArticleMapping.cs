using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheChosenBlogger.Domain.ArticleAggregate;

namespace TheChosenBlogger.Infrastructure.EFCore.Mappings;

public class ArticleMapping : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title);
        builder.Property(x => x.ShortDescription);
        builder.Property(x => x.Content);
        builder.Property(x => x.Image);
        builder.Property(x => x.IsDeleted);
        builder.Property(x => x.CreationDate);
        builder.HasOne(x => x.ArticleCategory).WithMany(x => x.Articles).HasForeignKey(x => x.ArticleCategoryId);
        builder.HasMany(x => x.Comments).WithOne(x => x.Article).HasForeignKey(x => x.ArticleId);
    }
}
