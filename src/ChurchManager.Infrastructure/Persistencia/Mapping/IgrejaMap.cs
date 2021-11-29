using ChurchManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManager.Infrastructure.Persistencia.Mapping
{
    public class IgrejaMap : IEntityTypeConfiguration<Igreja> 
    {
        public void Configure(EntityTypeBuilder<Igreja> entity)
        {
            entity.Property<int>("DirigenteId");
            entity.HasKey("DirigenteId");
        }
    }
}
