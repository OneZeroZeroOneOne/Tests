using Microsoft.EntityFrameworkCore;
using Tests.Dal.Models;
using Tests.Dal.Models.Views;

#nullable disable

namespace Tests.Dal.Contexts
{
    public partial class MainContext : DbContext
    {
        private readonly string _connectionString;
        public MainContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<AnswerTamplate> AnswerTamplate { get; set; }
        public virtual DbSet<Avatar> Avatar { get; set; }
        public virtual DbSet<DiscountType> DiscountType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<JwtOptions> JwtOptions { get; set; }
        public virtual DbSet<LongevityType> LongevityType { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionTemplate> QuestionTemplate { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<Resume> Resume { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<SubscriptionDiscount> SubscriptionDiscount { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAnswer> UserAnswer { get; set; }
        public virtual DbSet<UserEmployee> UserEmployee { get; set; }
        public virtual DbSet<UserQuiz> UserQuiz { get; set; }
        public virtual DbSet<UserSecurity> UserSecurity { get; set; }
        public virtual DbSet<Vacancy> Vacancy { get; set; }
        public virtual DbSet<PositionsWithCount> PositionsWithCounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C.UTF-8");

            modelBuilder.AddPositionWithCountView();

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("Answer_QuestionId_fkey");
            });

            modelBuilder.Entity<AnswerTamplate>(entity =>
            {
                entity.ToTable("AnswerTamplate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.QuestionTamplate)
                    .WithMany(p => p.AnswerTamplates)
                    .HasForeignKey(d => d.QuestionTamplateId)
                    .HasConstraintName("AnswerTamplate_QuestionTamplateId_fkey");
            });

            modelBuilder.Entity<Avatar>(entity =>
            {
                entity.ToTable("Avatar");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Avatar_id_seq\"'::regclass)");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Path).IsRequired();
            });

            modelBuilder.Entity<DiscountType>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.BreakpointSubscriptionTypeId })
                    .HasName("DiscountType_pkey");

                entity.ToTable("DiscountType");

                entity.HasIndex(e => e.Id, "DiscountType_Id_BreakpointSubscriptionTypeId_key")
                    .IsUnique();

                entity.Property(e => e.DiscountValue).HasPrecision(255);

                entity.HasOne(d => d.BreakpointSubscriptionType)
                    .WithMany(p => p.DiscountTypes)
                    .HasForeignKey(d => d.BreakpointSubscriptionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DiscountType_BreakpointSubscriptionTypeId_fkey");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.MiddleName).IsRequired();

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(x => x.DateOfBirth);

                entity.HasOne(d => d.Avatar)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AvatarId)
                    .HasConstraintName("Employee_AvatarId_fkey");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("Employee_PositionId_fkey");

                entity.HasOne(d => d.Resume)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ResumeId)
                    .HasConstraintName("Employee_ResumeId_fkey");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.VacancyId)
                    .HasConstraintName("Employee_VacancyId_fkey");
            });

            modelBuilder.Entity<JwtOptions>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<LongevityType>(entity =>
            {
                entity.ToTable("LongevityType");

                entity.Property(e => e.LongevityMeasureName).IsRequired();
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('positionid_seq'::regclass)");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Position_UserId_fkey");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("Question_QuestionTypeId_fkey");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("Question_QuizId_fkey");
            });

            modelBuilder.Entity<QuestionTemplate>(entity =>
            {
                entity.ToTable("QuestionTemplate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.QuestionTemplates)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("QuestionTemplate_QuestionTypeId_fkey");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.ToTable("QuestionType");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Quiz_StatusId_fkey");
            });

            modelBuilder.Entity<Resume>(entity =>
            {
                entity.ToTable("Resume");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Resume_id_seq\"'::regclass)");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Path).IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Id })
                    .HasName("Subscription_pkey");

                entity.ToTable("Subscription");

                entity.HasIndex(e => e.Id, "Subscription_Id_key")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDateTime).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Subscription_TypeId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Subscription_UserId_fkey");
            });

            modelBuilder.Entity<SubscriptionDiscount>(entity =>
            {
                entity.HasKey(e => new { e.SubscriptionId, e.DiscountTypeId })
                    .HasName("SubscriptionDiscount_pkey");

                entity.ToTable("SubscriptionDiscount");

                entity.Property(e => e.CreatedDateTime).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TotalDiscount).HasPrecision(255);

                entity.HasOne(d => d.DiscountType)
                    .WithMany(p => p.SubscriptionDiscounts)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.DiscountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SubscriptionDiscount_DiscountTypeId_fkey");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscriptionDiscounts)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SubscriptionDiscount_SubscriptionId_fkey");
            });

            modelBuilder.Entity<SubscriptionType>(entity =>
            {
                entity.ToTable("SubscriptionType");

                entity.Property(e => e.AvailableTestAmount).HasDefaultValueSql("1");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasPrecision(10, 2);

                entity.HasOne(d => d.LongevityType)
                    .WithMany(p => p.SubscriptionTypes)
                    .HasForeignKey(d => d.LongevityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SubscriptionType_LongevityTypeId_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_RoleId_fkey");
            });

            modelBuilder.Entity<UserAnswer>(entity =>
            {
                entity.ToTable("UserAnswer");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("UserAnswer_AnswerId_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("UserAnswer_EmployeeId_fkey");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("UserAnswer_QuestionId_fkey");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("UserAnswer_QuizId_fkey");
            });

            modelBuilder.Entity<UserEmployee>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EmployeeId })
                    .HasName("UserEmployee_pkey");

                entity.ToTable("UserEmployee");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.UserEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserEmployee_EmployeeId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEmployees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserEmployee_UserId_fkey");
            });

            modelBuilder.Entity<UserQuiz>(entity =>
            {
                entity.ToTable("UserQuiz");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("UserQuiz_EmployeeId_fkey");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("UserQuiz_QuizId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserQuiz_UserId_fkey");
            });

            modelBuilder.Entity<UserSecurity>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("UserSecurity_pkey");

                entity.ToTable("UserSecurity");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserSecurity)
                    .HasForeignKey<UserSecurity>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserSecurity_UserId_fkey");
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.ToTable("Vacancy");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vacancy_UserId_fkey");
            });

            modelBuilder.HasSequence("positionid_seq");

            modelBuilder.HasSequence("PositionId_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
