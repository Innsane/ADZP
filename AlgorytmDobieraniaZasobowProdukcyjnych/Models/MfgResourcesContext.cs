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

        public virtual DbSet<Lathe> Lathes { get; set; }
        public virtual DbSet<NozeJednolite> NozeJednolites { get; set; }
        public virtual DbSet<NozeLutowane> NozeLutowanes { get; set; }
        public virtual DbSet<Opskl> Opskls { get; set; }
        public virtual DbSet<Opsklo> Opsklos { get; set; }
        public virtual DbSet<QTurningTool> QTurningTools { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<TreeOfCuttingTool> TreeOfCuttingTools { get; set; }
        public virtual DbSet<TreeOfEquipment> TreeOfEquipments { get; set; }
        public virtual DbSet<TreeOfMachineTool> TreeOfMachineTools { get; set; }
        public virtual DbSet<TurctCarbid> TurctCarbids { get; set; }
        public virtual DbSet<TurctHolder> TurctHolders { get; set; }
        public virtual DbSet<TurctInsert> TurctInserts { get; set; }
        public virtual DbSet<TurctParVcVal> TurctParVcVals { get; set; }
        public virtual DbSet<TurnToolTab> TurnToolTabs { get; set; }
        public virtual DbSet<WiertlaDat> WiertlaDats { get; set; }
        public virtual DbSet<WiertlaTab> WiertlaTabs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MfgResources;Trusted_Connection=True;");
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

            modelBuilder.Entity<NozeJednolite>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NozeJednolites");

                entity.Property(e => e.B).HasColumnName("b");

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.Din).HasColumnName("DIN");

                entity.Property(e => e.H).HasColumnName("h");

                entity.Property(e => e.Hand).HasMaxLength(2);

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.Iso)
                    .HasMaxLength(10)
                    .HasColumnName("ISO");

                entity.Property(e => e.Kod).HasMaxLength(40);

                entity.Property(e => e.Material).HasMaxLength(10);

                entity.Property(e => e.Mod3D)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Nazwa).HasMaxLength(50);

                entity.Property(e => e.Obraz).HasMaxLength(150);

                entity.Property(e => e.Oznaczanie).HasMaxLength(50);

                entity.Property(e => e.Pn)
                    .HasMaxLength(10)
                    .HasColumnName("PN");

                entity.Property(e => e.Rys2D)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Typ).HasMaxLength(20);
            });

            modelBuilder.Entity<NozeLutowane>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NozeLutowanes");

                entity.Property(e => e.B).HasColumnName("b");

                entity.Property(e => e.Cena).HasColumnType("money");

                entity.Property(e => e.Din).HasColumnName("DIN");

                entity.Property(e => e.H).HasColumnName("h");

                entity.Property(e => e.Hand).HasMaxLength(2);

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.Iso)
                    .HasMaxLength(10)
                    .HasColumnName("ISO");

                entity.Property(e => e.Kod).HasMaxLength(40);

                entity.Property(e => e.Material).HasMaxLength(10);

                entity.Property(e => e.Mod3D)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Nazwa).HasMaxLength(50);

                entity.Property(e => e.Obraz).HasMaxLength(150);

                entity.Property(e => e.Oznaczenie).HasMaxLength(50);

                entity.Property(e => e.Pn)
                    .HasMaxLength(10)
                    .HasColumnName("PN");

                entity.Property(e => e.Rys2D)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Typ).HasMaxLength(20);
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

            modelBuilder.Entity<QTurningTool>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("qTurningTools");

                entity.Property(e => e.ApMax)
                    .HasColumnType("decimal(4, 1)")
                    .HasColumnName("ap_max");

                entity.Property(e => e.ApMin)
                    .HasColumnType("decimal(4, 1)")
                    .HasColumnName("ap_min");

                entity.Property(e => e.ApZ)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("ap_z");

                entity.Property(e => e.B).HasColumnName("b");

                entity.Property(e => e.FnMax)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("fn_max");

                entity.Property(e => e.FnMin)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("fn_min");

                entity.Property(e => e.FnZ)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("fn_z");

                entity.Property(e => e.Geometry)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.H).HasColumnName("h");

                entity.Property(e => e.His).HasColumnName("HIS");

                entity.Property(e => e.Holder).HasMaxLength(255);

                entity.Property(e => e.Ht)
                    .HasMaxLength(255)
                    .HasColumnName("HT");

                entity.Property(e => e.InIs).HasColumnName("InIS");

                entity.Property(e => e.Kod).HasMaxLength(255);

                entity.Property(e => e.Kr).HasColumnName("kr");

                entity.Property(e => e.La).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Mod3D).HasMaxLength(255);

                entity.Property(e => e.Obraz).HasMaxLength(255);

                entity.Property(e => e.OpA)
                    .HasMaxLength(255)
                    .HasColumnName("OP_A");

                entity.Property(e => e.OpB)
                    .HasMaxLength(255)
                    .HasColumnName("OP_B");

                entity.Property(e => e.Re).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Rys2D).HasMaxLength(255);

                entity.Property(e => e.S)
                    .HasColumnType("decimal(7, 4)")
                    .HasColumnName("s");

                entity.Property(e => e.VcMax).HasColumnName("Vc_max");

                entity.Property(e => e.VcMin).HasColumnName("Vc_min");

                entity.Property(e => e.VcZ).HasColumnName("Vc_z");
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

            modelBuilder.Entity<TurctCarbid>(entity =>
            {
                entity.ToTable("turctCarbids");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .HasColumnName("ID");

                entity.Property(e => e.ApMax)
                    .HasColumnType("decimal(4, 1)")
                    .HasColumnName("ap_max");

                entity.Property(e => e.ApMin)
                    .HasColumnType("decimal(4, 1)")
                    .HasColumnName("ap_min");

                entity.Property(e => e.ApZ)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("ap_z");

                entity.Property(e => e.FnMax)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("fn_max");

                entity.Property(e => e.FnMin)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("fn_min");

                entity.Property(e => e.FnZ)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("fn_z");

                entity.Property(e => e.Geometry)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.VcMax).HasColumnName("Vc_max");

                entity.Property(e => e.VcMin).HasColumnName("Vc_min");

                entity.Property(e => e.VcZ).HasColumnName("Vc_z");
            });

            modelBuilder.Entity<TurctHolder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("turctHolders");

                entity.Property(e => e.B).HasColumnName("b");

                entity.Property(e => e.F1).HasColumnName("f1");

                entity.Property(e => e.H).HasColumnName("h");

                entity.Property(e => e.H1).HasColumnName("h1");

                entity.Property(e => e.Holder).HasMaxLength(255);

                entity.Property(e => e.Ht)
                    .HasMaxLength(255)
                    .HasColumnName("HT");

                entity.Property(e => e.Idct)
                    .HasMaxLength(255)
                    .HasColumnName("IDCT");

                entity.Property(e => e.Is).HasColumnName("IS");

                entity.Property(e => e.Kod).HasMaxLength(255);

                entity.Property(e => e.Kr).HasColumnName("kr");

                entity.Property(e => e.L1).HasColumnName("l1");

                entity.Property(e => e.L3).HasColumnName("l3");

                entity.Property(e => e.Mod3D).HasMaxLength(255);

                entity.Property(e => e.Obraz).HasMaxLength(255);

                entity.Property(e => e.OpA)
                    .HasMaxLength(255)
                    .HasColumnName("OP_A");

                entity.Property(e => e.OpB)
                    .HasMaxLength(255)
                    .HasColumnName("OP_B");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Rys2D).HasMaxLength(255);

                entity.Property(e => e.Shape).HasMaxLength(255);

                entity.Property(e => e.System).HasMaxLength(255);
            });

            modelBuilder.Entity<TurctInsert>(entity =>
            {
                entity.ToTable("turctInserts");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .HasColumnName("ID");

                entity.Property(e => e.Geometry)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.IC)
                    .HasColumnType("decimal(7, 3)")
                    .HasColumnName("iC");

                entity.Property(e => e.Is).HasColumnName("IS");

                entity.Property(e => e.Kw)
                    .HasColumnType("decimal(6, 3)")
                    .HasColumnName("kw");

                entity.Property(e => e.La).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Re).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.S)
                    .HasColumnType("decimal(7, 4)")
                    .HasColumnName("s");

                entity.Property(e => e.Shape)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<TurctParVcVal>(entity =>
            {
                entity.ToTable("turctPar_vc_Val");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .HasColumnName("ID");

                entity.Property(e => e.Cmc)
                    .HasMaxLength(5)
                    .HasColumnName("CMC");

                entity.Property(e => e.F1)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("f1");

                entity.Property(e => e.F2)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("f2");

                entity.Property(e => e.Mc)
                    .HasMaxLength(12)
                    .HasColumnName("MC");
            });

            modelBuilder.Entity<TurnToolTab>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TurnToolTAB");

                entity.Property(e => e.Accuracy).HasMaxLength(255);

                entity.Property(e => e.CatPage).HasMaxLength(255);

                entity.Property(e => e.Idtt)
                    .HasMaxLength(255)
                    .HasColumnName("IDTT");

                entity.Property(e => e.Kod).HasMaxLength(255);

                entity.Property(e => e.Method).HasMaxLength(255);

                entity.Property(e => e.Mod3D).HasMaxLength(255);

                entity.Property(e => e.Obraz).HasMaxLength(255);

                entity.Property(e => e.Rys2D).HasMaxLength(255);

                entity.Property(e => e.ShankCode).HasMaxLength(255);

                entity.Property(e => e.Tooling).HasMaxLength(255);
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
