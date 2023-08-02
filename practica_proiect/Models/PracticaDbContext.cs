using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace practica_proiect.Models;

public partial class PracticaDbContext : DbContext
{
    public PracticaDbContext()
    {
    }

    public PracticaDbContext(DbContextOptions<PracticaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<TicketCategory> TicketCategories { get; set; }

    public virtual DbSet<TotalNumberOfTicketsPerCategory> TotalNumberOfTicketsPerCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ANDREEA\\SQLEXPRESS01;Initial Catalog=practica_DB;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__7944C870DC683F5F");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasPrecision(6);
            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasPrecision(6);
            entity.Property(e => e.VenueId).HasColumnName("VenueID");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Event__EventType__6E01572D");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Event__VenueID__6D0D32F4");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeId).HasName("PK__EventTyp__A9216B1FFBBBBB51");

            entity.ToTable("EventType");

            entity.HasIndex(e => e.Name, "UQ__EventTyp__737584F6802DD447").IsUnique();

            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFFCA85020");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderedAt).HasPrecision(6);
            entity.Property(e => e.TicketCategoryId).HasColumnName("TicketCategoryID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.TicketCategory).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TicketCategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Orders__TicketCa__75A278F5");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Orders__UserID__74AE54BC");
        });

        modelBuilder.Entity<TicketCategory>(entity =>
        {
            entity.HasKey(e => e.TicketCategoryId).HasName("PK__TicketCa__C84589C6AEA218BD");

            entity.ToTable("TicketCategory");

            entity.Property(e => e.TicketCategoryId).HasColumnName("TicketCategoryID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EventId).HasColumnName("EventID");

            entity.HasOne(d => d.Event).WithMany(p => p.TicketCategories)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__TicketCat__Event__71D1E811");
        });

        modelBuilder.Entity<TotalNumberOfTicketsPerCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("total_number_of_tickets_per_category");

            entity.Property(e => e.SumOfSoldTickets).HasColumnName("sum_of_sold_tickets");
            entity.Property(e => e.TicketCategoryId).HasColumnName("TicketCategoryID");
            entity.Property(e => e.TotalValue)
                .HasColumnType("numeric(38, 2)")
                .HasColumnName("total_value");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC6568A0E9");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.VenueId).HasName("PK__Venue__3C57E5D25270182E");

            entity.ToTable("Venue");

            entity.Property(e => e.VenueId).HasColumnName("VenueID");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
        });
        modelBuilder.HasSequence("Event_SEQ").IncrementsBy(50);
        modelBuilder.HasSequence("EventType_SEQ").IncrementsBy(50);
        modelBuilder.HasSequence("Order_SEQ").IncrementsBy(50);
        modelBuilder.HasSequence("Orders_SEQ").IncrementsBy(50);
        modelBuilder.HasSequence("TicketCategory_SEQ").IncrementsBy(50);
        modelBuilder.HasSequence("User_SEQ").IncrementsBy(50);
        modelBuilder.HasSequence("Users_SEQ").IncrementsBy(50);
        modelBuilder.HasSequence("Venue_SEQ").IncrementsBy(50);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
