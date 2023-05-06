using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Channel.Data.Domain;

namespace Sample.Channel.Data.Config
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("Content", "Cms");
            builder.HasKey(o => o.Id);
        }
    }
}
