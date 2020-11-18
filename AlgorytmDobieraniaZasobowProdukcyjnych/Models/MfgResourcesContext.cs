using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public partial class MfgResourcesContext : DbContext
    {

        public MfgResourcesContext(DbContextOptions<MfgResourcesContext> options)
            : base(options)
        {
        }

        public DbSet<Lathe> Lathes { get; set; }
        public virtual DbSet<Opskl> Opskls { get; set; }
        public virtual DbSet<Opsklo> Opsklos { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<TreeOfCuttingTool> TreeOfCuttingTools { get; set; }
        public virtual DbSet<TreeOfEquipment> TreeOfEquipments { get; set; }
        public virtual DbSet<TreeOfMachineTool> TreeOfMachineTools { get; set; }
        public virtual DbSet<WiertlaDat> WiertlaDats { get; set; }
        public virtual DbSet<WiertlaTab> WiertlaTabs { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-PKL6JSJ\\SQLEXPRESS;Database=MfgResources;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lathe>(entity =>
            {
                entity.HasKey(e => e.Oznaczenie);

                entity.Property(e => e.Oznaczenie).HasMaxLength(20);

                entity.Property(e => e.Gniazdo).HasMaxLength(30);

                entity.Property(e => e.Kod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.M).HasColumnName("m");

                entity.Property(e => e.Mod3D).HasMaxLength(50);

                entity.Property(e => e.NMax).HasColumnName("n_max");

                entity.Property(e => e.NMin).HasColumnName("n_min");

                entity.Property(e => e.Obraz).HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(100);

                entity.Property(e => e.Producent).HasMaxLength(50);

                entity.Property(e => e.Rodzaj).HasMaxLength(50);

                entity.Property(e => e.Rys2D).HasMaxLength(50);

                entity.Property(e => e.Typ).HasMaxLength(50);

                entity.Property(e => e.Wrzeciono).HasMaxLength(30);
            });

            modelBuilder.Entity<Opskl>(entity =>
            {
                entity.HasKey(e => e.Idp);

                entity.ToTable("OPSKLS");

                entity.Property(e => e.Idp).HasColumnName("IDP");

                entity.Property(e => e.Iso).HasColumnName("ISO");

                entity.Property(e => e.Kod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ksm).HasColumnName("KSM");

                entity.Property(e => e.Mod3D).HasMaxLength(255);

                entity.Property(e => e.Nakretka).HasMaxLength(50);

                entity.Property(e => e.Norma)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Obraz).HasMaxLength(255);

                entity.Property(e => e.Opis).HasMaxLength(255);

                entity.Property(e => e.Rys2D).HasMaxLength(255);
            });

            modelBuilder.Entity<Opsklo>(entity =>
            {
                entity.HasKey(e => e.Idp);

                entity.ToTable("OPSKLO");

                entity.Property(e => e.Idp).HasColumnName("IDP");

                entity.Property(e => e.Iso)
                    .HasMaxLength(12)
                    .HasColumnName("ISO");

                entity.Property(e => e.Kod).HasMaxLength(50);

                entity.Property(e => e.Ksm).HasColumnName("KSM");

                entity.Property(e => e.Mod3D).HasMaxLength(255);

                entity.Property(e => e.Mwpo).HasColumnName("MWPO");

                entity.Property(e => e.Norma).HasMaxLength(25);

                entity.Property(e => e.Obraz).HasMaxLength(255);

                entity.Property(e => e.Opis).HasMaxLength(255);

                entity.Property(e => e.Rys2D).HasMaxLength(255);

                entity.Property(e => e.Typ).HasMaxLength(25);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.KeyId);

                entity.Property(e => e.KeyId)
                    .HasMaxLength(10)
                    .HasColumnName("KeyID")
                    .IsFixedLength(true);

                entity.Property(e => e.ImageDirectory).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwa).HasMaxLength(50);

                entity.Property(e => e.Tree)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TreeOfCuttingTool>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.Property(e => e.NodeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NodeID");

                entity.Property(e => e.IconId).HasColumnName("IconID");

                entity.Property(e => e.KeyId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("KeyID");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.ParentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ParentID");

                entity.Property(e => e.PictureId)
                    .HasMaxLength(150)
                    .HasColumnName("PictureID");

                entity.Property(e => e.Stepncname)
                    .HasMaxLength(50)
                    .HasColumnName("STEPNCName");

                entity.Property(e => e.TableId)
                    .HasMaxLength(50)
                    .HasColumnName("TableID");
            });

            modelBuilder.Entity<TreeOfEquipment>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.ToTable("TreeOfEquipment");

                entity.Property(e => e.NodeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NodeID");

                entity.Property(e => e.IconId).HasColumnName("IconID");

                entity.Property(e => e.KeyId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("KeyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ParentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ParentID");

                entity.Property(e => e.PictureId)
                    .HasMaxLength(150)
                    .HasColumnName("PictureID");

                entity.Property(e => e.TableId)
                    .HasMaxLength(50)
                    .HasColumnName("TableID");
            });

            modelBuilder.Entity<TreeOfMachineTool>(entity =>
            {
                entity.HasKey(e => e.NodeId)
                    .HasName("PK_MachineToolsTree");

                entity.Property(e => e.NodeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NodeID");

                entity.Property(e => e.IconId).HasColumnName("IconID");

                entity.Property(e => e.KeyId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("KeyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ParentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ParentID");

                entity.Property(e => e.PictureId)
                    .HasMaxLength(150)
                    .HasColumnName("PictureID");

                entity.Property(e => e.TableId)
                    .HasMaxLength(50)
                    .HasColumnName("TableID");
            });

            modelBuilder.Entity<WiertlaDat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("WiertlaDAT");

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.Chwyt)
                    .HasMaxLength(255)
                    .HasColumnName("CHWYT");

                entity.Property(e => e.Fk)
                    .HasMaxLength(255)
                    .HasColumnName("FK");

                entity.Property(e => e.Idc)
                    .HasMaxLength(255)
                    .HasColumnName("IDC");

                entity.Property(e => e.Kod).HasMaxLength(255);

                entity.Property(e => e.Mod3D).HasMaxLength(255);

                entity.Property(e => e.Obraz).HasMaxLength(255);

                entity.Property(e => e.Oznaczenie).HasMaxLength(255);

                entity.Property(e => e.Rys2D).HasMaxLength(255);
            });

            modelBuilder.Entity<WiertlaTab>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("WiertlaTAB");

                entity.Property(e => e.Kod).HasMaxLength(255);

                entity.Property(e => e.Material).HasMaxLength(255);

                entity.Property(e => e.Mod3D).HasMaxLength(255);

                entity.Property(e => e.NormaEn)
                    .HasMaxLength(255)
                    .HasColumnName("NormaEN");

                entity.Property(e => e.NormaPn)
                    .HasMaxLength(255)
                    .HasColumnName("NormaPN");

                entity.Property(e => e.Obraz).HasMaxLength(255);

                entity.Property(e => e.Opis).HasMaxLength(255);

                entity.Property(e => e.OznPn)
                    .HasMaxLength(255)
                    .HasColumnName("OZN_PN");

                entity.Property(e => e.Oznaczenie).HasMaxLength(255);

                entity.Property(e => e.Producent).HasMaxLength(255);

                entity.Property(e => e.Rys2D).HasMaxLength(255);

                entity.Property(e => e.Technologia).HasMaxLength(255);

                entity.Property(e => e.Typ).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
