namespace DbLibrary;

public class SqlDbContext : DbContext
{
	public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
	{
	}

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//{
	//	//optionsBuilder.UseSqlServer("Data Source = WIN10PC; Initial Catalog = Universitet; Integrated Security = True; Encrypt=False;");
	//}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//base.OnModelCreating(modelBuilder);
		//modelBuilder.Entity<Subject>().Navigation(e => e.UniversitetGroups).AutoInclude();
		modelBuilder.Entity<UniversitetGroup>().Navigation(e => e.Subjects).AutoInclude();
		modelBuilder.Entity<Student>().Navigation(e => e.UniversitetGroup).AutoInclude();
		modelBuilder.Entity<Attendance>().Navigation(e => e.Student).AutoInclude();
		modelBuilder.Entity<Attendance>().Navigation(e => e.LearningDate).AutoInclude();

		modelBuilder.Entity<SubjectScore>().Navigation(e => e.Student).AutoInclude();
		modelBuilder.Entity<SubjectScore>().Navigation(e => e.Subject).AutoInclude();
		modelBuilder.Entity<SubjectScore>().Navigation(e => e.LearningDate).AutoInclude();
		modelBuilder.Entity<SubjectScore>().Navigation(e => e.TaskType).AutoInclude();
	}

	public async Task CreateClearDbAsync()
	{
		await Database.EnsureDeletedAsync();
		await Database.EnsureCreatedAsync();
	}

	public DbSet<Student> Students { get; set; } = null!;
	public DbSet<Subject>Subjects  { get; set; } = null!;
	public DbSet<SubjectScore> SubjectScores{ get; set; } = null!;

	//public DbSet<Role> Roles  { get; set; } = null!;

	public DbSet<RegisteredUser> RegisteredUsers  { get; set; } = null!;

	public DbSet<TaskType> TaskTypes  { get; set; } = null!;

	public DbSet<UniversitetGroup> UniversitetGroups  { get; set; } = null!;


	public DbSet<LearningDate>LearningDates  { get; set; } = null!;
	public DbSet<Attendance> Attendances { get; set; } = null!;

}
