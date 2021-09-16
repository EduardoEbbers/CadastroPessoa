using Microsoft.EntityFrameworkCore;

namespace CadatroPessoaWebApi.Models
{
    public partial class cadastropessoaContext : DbContext
    {
        public cadastropessoaContext()
        {
        }

        public cadastropessoaContext(DbContextOptions<cadastropessoaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<PessoaTelefone> PessoaTelefone { get; set; }
        public virtual DbSet<Telefone> Telefone { get; set; }
        public virtual DbSet<TelefoneTipo> TelefoneTipo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user id=root;password=duda;database=cadastropessoa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>(entity =>
            {
                //Table endereco
                entity
                    .HasKey(e => e.IdEndereco)
                    .HasName("PRIMARY");
                entity
                    .Property(e => e.IdEndereco)
                    .HasColumnName("id_endereco")
                    .ValueGeneratedOnAdd();
                entity
                    .Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("logradouro")
                    .HasMaxLength(256);
                entity
                    .Property(e => e.Numero)
                    .HasColumnName("numero");
                entity
                    .Property(e => e.Cep)
                    .HasColumnName("cep");
                entity
                    .Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(50);
                entity
                    .Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(30);
                entity
                    .Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(20);
                entity
                    .ToTable("endereco");
            });

            //Table pessoa
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity
                    .HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");
                entity
                    .Property(e => e.IdPessoa)
                    .HasColumnName("id_pessoa")
                    .ValueGeneratedOnAdd();
                entity
                    .Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(256);
                entity
                    .Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(11);
                entity
                    .Property(e => e.IdEndereco)
                    .HasColumnName("id_endereco");
                entity
                    .HasOne(d => d.Endereco)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("end_pes_fk");
                entity
                    .HasIndex(e => e.IdEndereco)
                    .HasName("end_pes_fk_idx");
                entity
                    .ToTable("pessoa");
            });

            modelBuilder.Entity<PessoaTelefone>(entity =>
            {
                entity
                    .HasKey(e => new { e.IdPessoa, e.IdTelefone })
                    .HasName("PRIMARY");
                entity
                    .Property(e => e.IdPessoa)
                    .HasColumnName("id_pessoa");
                entity
                    .Property(e => e.IdTelefone)
                    .HasColumnName("id_telefone");
                entity
                    .HasOne(d => d.Pessoa)
                    .WithMany(p => p.PessoaTelefone)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pes_pes_tel_fk");
                entity
                    .HasOne(d => d.Telefone)
                    .WithMany(p => p.PessoaTelefone)
                    .HasForeignKey(d => d.IdTelefone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tel_pes_tel_fk");
                entity
                    .HasIndex(e => e.IdTelefone)
                    .HasName("tel_pes_tel_fk_idx");
                entity
                    .ToTable("pessoa_telefone");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity
                    .HasKey(e => e.IdTelefone)
                    .HasName("PRIMARY");
                entity
                    .Property(e => e.IdTelefone)
                    .HasColumnName("id_telefone")
                    .ValueGeneratedOnAdd();
                entity
                    .Property(e => e.Numero)
                    .HasColumnName("numero");
                entity
                    .Property(e => e.Ddd)
                    .HasColumnName("ddd");
                entity
                    .Property(e => e.IdTelefoneTipo)
                    .HasColumnName("id_telefone_tipo");
                entity
                    .HasOne(d => d.TelefoneTipo)
                    .WithMany(p => p.Telefone)
                    .HasForeignKey(d => d.IdTelefoneTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tel_tip_tel_fk");
                entity
                    .HasIndex(e => e.IdTelefoneTipo)
                    .HasName("tel_tip_tel_fk_idx");
                entity
                    .ToTable("telefone");
            });

            modelBuilder.Entity<TelefoneTipo>(entity =>
            {
                entity
                    .HasKey(e => e.IdTelefoneTipo)
                    .HasName("PRIMARY");
                entity
                    .Property(e => e.IdTelefoneTipo)
                    .HasColumnName("id_telefone_tipo")
                    .ValueGeneratedOnAdd();
                entity
                    .Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(10);
                entity
                    .ToTable("telefone_tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
