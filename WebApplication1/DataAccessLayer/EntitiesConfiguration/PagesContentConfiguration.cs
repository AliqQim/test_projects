using aliksoft.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aliksoft.DataAccessLayer.EntitiesConfiguration;

public class PagesContentConfiguration : IEntityTypeConfiguration<PagesContent>
{
    public void Configure(EntityTypeBuilder<PagesContent> builder)
    {
        builder.HasKey(pc => pc.PageId);
        builder.Property(pc => pc.Content).IsRequired();

        builder.HasData(new PagesContent
        {
            PageId = PageId.Main,
            Content = ""
        });
    }
}
