using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreConsoleApp
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<MatrimonialStatusEntry>()
                .WithMany().HasForeignKey(x => x.MatrimonialStatus)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    public class MatrimonialStatusEntryConfiguration : IEntityTypeConfiguration<MatrimonialStatusEntry>
    {
        public void Configure(EntityTypeBuilder<MatrimonialStatusEntry> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(new[]
            {
                new MatrimonialStatusEntry{ Id = MatrimonialStatus.Single, Name = "Single!"},
                new MatrimonialStatusEntry{ Id = MatrimonialStatus.Married, Name = "Married!"}
            });
        }
    }
}
