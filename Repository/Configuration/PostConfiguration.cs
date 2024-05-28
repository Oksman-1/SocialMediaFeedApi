using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {

        builder.ToTable("Post");
        builder.HasKey(p => p.PostId);
        builder.Property(p => p.Content).HasColumnName(nameof(Post.Content)).IsRequired().HasMaxLength(140);
        builder.Property(p => p.CreatedAt).HasColumnName(nameof(Post.CreatedAt)).IsRequired();
        builder.HasOne(p => p.User).WithMany(p => p.Posts).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);


        builder.HasData
        (
        new Post
        {
            PostId = Guid.Parse("6f7b9c0e-d769-4d6b-b170-cd80cbaa0162"),
            Content = "Please bro!, let's keep finding the answers to these questions even if they are hard....",
            CreatedAt = DateTime.Now,
            IsLiked = false, 
            UserId = Guid.Parse("672b5d69-c4e1-4467-95b6-5fdfa025b220")
        },
        new Post
        {
            PostId = Guid.Parse("4c84a49a-e2cf-4548-af83-206b6e51a645"),
            Content = "That’s why we put together this list of 66!....they will surely graduate soon.",
            CreatedAt = DateTime.Now,
            IsLiked = false,
            UserId = Guid.Parse("6a94ce84-5fc7-4b1d-9887-48f84986d405")
        },
        new Post
        {
            PostId = Guid.Parse("b7f5c9e2-f2dd-4a63-8031-ebada7cd3696"),
            Content = "You can use these text messages to inquire about your status.....",
            CreatedAt = DateTime.Now,
            IsLiked = false,
            UserId = Guid.Parse("672b5d69-c4e1-4467-95b6-5fdfa025b220")
        },
        new Post
        {
            PostId = Guid.Parse("f8fcf536-6ca7-45e1-b73c-5e8668ce785c"),
            Content = "Yooooooooo hoooooooooooo!!......How are you doing!! .",
            CreatedAt = DateTime.Now,
            IsLiked = false,
            UserId = Guid.Parse("672b5d69-c4e1-4467-95b6-5fdfa025b220")
        }                        
        );
    }

}
