using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sale.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Data.Builders
{
    public class BaseBuilder
    {
        public BaseBuilder(EntityTypeBuilder<BaseEntity> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.AddedBy).IsRequired(false);
            entityBuilder.Property(p => p.ModifiedBy).IsRequired(false);
        }
    }
}
