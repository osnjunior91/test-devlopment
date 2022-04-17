﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Strider.Infrastructure.Data.Model;

namespace Strider.Infrastructure.Data.Configuration
{
    public class RepostConfiguration : IEntityTypeConfiguration<Repost>
    {
        public void Configure(EntityTypeBuilder<Repost> builder)
        {
            builder.ToTable("posts").HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.RepostedFrom).WithMany().HasForeignKey(x => x.RepostedFromId);
        }
    }
}
