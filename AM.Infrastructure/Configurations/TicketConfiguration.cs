using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
   public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    { 
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasOne(e => e.Flight).WithMany(e => e.Tickets).HasForeignKey(e => e.Flightkey);
            builder.HasOne(e => e.Passenger).WithMany(e => e.Tickets).HasForeignKey(e => e.PassengerKey);
            builder.HasKey(e => new { e.Seat, e.Flightkey, e.PassengerKey });
        }
    }
}
