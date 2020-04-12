using Microsoft.EntityFrameworkCore;
using Models;

namespace Server
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<AuthorsPublishinghouses> AuthorsPublishinghouses { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Librarian> Librarian { get; set; }
        public virtual DbSet<Librarycard> Librarycard { get; set; }
        public virtual DbSet<LibrarycardsBooks> LibrarycardsBooks { get; set; }
        public virtual DbSet<LibrarycardsStudents> LibrarycardsStudents { get; set; }
        public virtual DbSet<LibrarycardsTeachers> LibrarycardsTeachers { get; set; }
        public virtual DbSet<Publishinghouse> Publishinghouse { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studentgroup> Studentgroup { get; set; }
        public virtual DbSet<Studentgroupteachers> Studentgroupteachers { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=library;Username=postgres;Password=1111");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AuthorsPublishinghouses>(entity =>
            {
                entity.ToTable("authors_publishinghouses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.PublishinghouseId).HasColumnName("publishinghouse_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorsPublishinghouses)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("authors_publishinghouses_author_id_fkey");

                entity.HasOne(d => d.Publishinghouse)
                    .WithMany(p => p.AuthorsPublishinghouses)
                    .HasForeignKey(d => d.PublishinghouseId)
                    .HasConstraintName("authors_publishinghouses_publishinghouse_id_fkey");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pagesamount).HasColumnName("pagesamount");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("book_author_id_fkey");
            });

            modelBuilder.Entity<Librarian>(entity =>
            {
                entity.ToTable("librarian");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Librarycard>(entity =>
            {
                entity.ToTable("librarycard");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Registrationdate).HasColumnName("registrationdate");

                entity.Property(e => e.ResponsiblelibrarianId).HasColumnName("responsiblelibrarian_id");

                entity.HasOne(d => d.Responsiblelibrarian)
                    .WithMany(p => p.Librarycard)
                    .HasForeignKey(d => d.ResponsiblelibrarianId)
                    .HasConstraintName("librarycard_responsiblelibrarian_id_fkey");
            });

            modelBuilder.Entity<LibrarycardsBooks>(entity =>
            {
                entity.ToTable("librarycards_books");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.LibrarycardId).HasColumnName("librarycard_id");

                entity.Property(e => e.Returned)
                    .IsRequired()
                    .HasColumnName("returned")
                    .HasMaxLength(1);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.LibrarycardsBooks)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("librarycards_books_book_id_fkey");

                entity.HasOne(d => d.Librarycard)
                    .WithMany(p => p.LibrarycardsBooks)
                    .HasForeignKey(d => d.LibrarycardId)
                    .HasConstraintName("librarycards_books_librarycard_id_fkey");
            });

            modelBuilder.Entity<LibrarycardsStudents>(entity =>
            {
                entity.ToTable("librarycards_students");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LibrarycardId).HasColumnName("librarycard_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Librarycard)
                    .WithMany(p => p.LibrarycardsStudents)
                    .HasForeignKey(d => d.LibrarycardId)
                    .HasConstraintName("librarycards_students_librarycard_id_fkey");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.LibrarycardsStudents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("librarycards_students_student_id_fkey");
            });

            modelBuilder.Entity<LibrarycardsTeachers>(entity =>
            {
                entity.ToTable("librarycards_teachers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LibrarycardId).HasColumnName("librarycard_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Librarycard)
                    .WithMany(p => p.LibrarycardsTeachers)
                    .HasForeignKey(d => d.LibrarycardId)
                    .HasConstraintName("librarycards_teachers_librarycard_id_fkey");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.LibrarycardsTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("librarycards_teachers_teacher_id_fkey");
            });

            modelBuilder.Entity<Publishinghouse>(entity =>
            {
                entity.ToTable("publishinghouse");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.LibrarycardId).HasColumnName("librarycard_id");

                entity.Property(e => e.StudentgroupId).HasColumnName("studentgroup_id");

                entity.HasOne(d => d.Librarycard)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.LibrarycardId)
                    .HasConstraintName("student_librarycard_id_fkey");

                entity.HasOne(d => d.Studentgroup)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.StudentgroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student_studentgroup_id_fkey");
            });

            modelBuilder.Entity<Studentgroup>(entity =>
            {
                entity.ToTable("studentgroup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CuratorId).HasColumnName("curator_id");

                entity.Property(e => e.Groupname)
                    .IsRequired()
                    .HasColumnName("groupname")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Curator)
                    .WithMany(p => p.Studentgroup)
                    .HasForeignKey(d => d.CuratorId)
                    .HasConstraintName("studentgroup_curator_id_fkey");
            });

            modelBuilder.Entity<Studentgroupteachers>(entity =>
            {
                entity.ToTable("studentgroupteachers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StudentgroupId).HasColumnName("studentgroup_id");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasMaxLength(100);

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Studentgroup)
                    .WithMany(p => p.Studentgroupteachers)
                    .HasForeignKey(d => d.StudentgroupId)
                    .HasConstraintName("studentgroupteachers_studentgroup_id_fkey");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Studentgroupteachers)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("studentgroupteachers_teacher_id_fkey");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.LibrarycardId).HasColumnName("librarycard_id");

                entity.HasOne(d => d.Librarycard)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.LibrarycardId)
                    .HasConstraintName("teacher_librarycard_id_fkey");
            });
        }
    }
}
