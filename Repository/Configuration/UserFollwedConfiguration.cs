using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration;

public class UserFollowedConfiguration : IEntityTypeConfiguration<UserFollowed>
{
    public void Configure(EntityTypeBuilder<UserFollowed> builder)
    {

        builder.ToTable("Following");
        builder.HasKey(u => u.FollowId);
        builder.HasOne(u => u.User).WithMany(u => u.UsersFollowed).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
        //builder.HasOne(u => u.UsersFollowed).WithMany(u => u.UsersFollowed).HasForeignKey(u => u.UsersFollowedId).OnDelete(DeleteBehavior.Restrict);


    builder.HasData
    (
    new UserFollowed
    {
        FollowId = Guid.Parse("ef0cbbae-e0b9-480c-9aeb-b99565e79c1a"),       
        UserId = Guid.Parse("672b5d69-c4e1-4467-95b6-5fdfa025b220"),
        UsersFollowedId = Guid.Parse("6a94ce84-5fc7-4b1d-9887-48f84986d405")
    },
    new UserFollowed
    {
        FollowId = Guid.Parse("b9b7d106-b1d6-4418-bc4e-ad07818c6067"),        
        UserId = Guid.Parse("672b5d69-c4e1-4467-95b6-5fdfa025b220"),
        UsersFollowedId = Guid.Parse("ea8b26f5-f721-4809-8053-93a0d67dbf10")
    }
    );
    }
}
