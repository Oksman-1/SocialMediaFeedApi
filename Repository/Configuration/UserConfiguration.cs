using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{

        builder.ToTable("User");
		builder.HasKey(u => u.UserId);
        builder.Property(u => u.Username).HasColumnName(nameof(User.Username)).IsRequired();
        builder.Property(u => u.Email).HasColumnName(nameof(User.Email)).IsRequired();
        builder.Property(u => u.Website).HasColumnName(nameof(User.Website)).IsRequired();


		builder.HasData
		(
		new User
		{
			UserId = Guid.Parse("672b5d69-c4e1-4467-95b6-5fdfa025b220"),
			Username = "Oksman_Ibiza",
			Email = "Oksman123@gmail.com",
			Website = "https://www.oksman123.com/"
        },
		new User
		{
            UserId = Guid.Parse("6a94ce84-5fc7-4b1d-9887-48f84986d405"),
            Username = "Manny_Sharpest_Guy",
            Email = "Manny_Bobo@gmail.com",
            Website = "https://www.Mani_Sholey.com/"
        },
		new User
		{
            UserId = Guid.Parse("ea8b26f5-f721-4809-8053-93a0d67dbf10"),
            Username = "Chukszee_518",
            Email = "ChuksOkon@gmail.com",
            Website = "https://www.chukzee.com/"
        }
		);
	}

}
