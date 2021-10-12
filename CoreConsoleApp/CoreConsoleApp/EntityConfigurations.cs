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
            builder.HasOne(x => x.MatrimonialStatusEntry)
                .WithMany().HasForeignKey(x => x.MatrimonialStatusId)
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
                new MatrimonialStatusEntry{ Id = 1, Name = "Single!"},
                new MatrimonialStatusEntry{ Id = 2, Name = "Married!"}
            });
        }
    }
}
