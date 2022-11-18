﻿using EventOrganizer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventOrganizer.EF.EntityConfigurations
{
    internal class EventTagConfiguration : IEntityTypeConfiguration<EventTag>
    {
        public void Configure(EntityTypeBuilder<EventTag> builder)
        {
            builder.HasKey(et => et.Keyword);
            builder.Property(et => et.Keyword).HasMaxLength(30);

            builder.HasMany(et => et.EventModels)
                .WithMany(em => em.EventTags)
                .UsingEntity<TagToEvent>();
        }
    }
}
