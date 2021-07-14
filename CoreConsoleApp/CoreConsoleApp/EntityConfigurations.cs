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

            SetUpZodiacForeignKey(builder.OwnsOne(x => x.UnforgivableZamorochkaOfOtherPerson));

            SetUpZodiacForeignKey(builder.OwnsMany(x => x.OwnZamorochkas));
                

        }

        static void SetUpZodiacForeignKey(OwnedNavigationBuilder<Person, Zamorochka> builder)
        {
            builder.HasOne(z => z.Zodiac)
                .WithMany()
                .HasForeignKey(z => z.ZodiacId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }

    

    public class ZamorochkaConfiguration : IEntityTypeConfiguration<Zamorochka>
    {
        public void Configure(EntityTypeBuilder<Zamorochka> builder)
        {
            builder.HasOne(x => x.Zodiac)
                .WithMany()
                .HasForeignKey(x => x.ZodiacId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
