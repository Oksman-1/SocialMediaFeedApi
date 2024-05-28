using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {

        builder.ToTable("Like");
        builder.HasKey(l => l.LikeId);         
        builder.HasOne(l => l.Post).WithMany(l => l.Likes).HasForeignKey(l => l.PostId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(l => l.User).WithMany(l => l.Likes).HasForeignKey(l => l.UserId).OnDelete(DeleteBehavior.NoAction);  
      
    }

}
