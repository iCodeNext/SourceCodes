using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LivenessReadiness;

public class DatabaseHealthCheck : IHealthCheck
{
    private readonly YourDbContext _dbContext;
    public DatabaseHealthCheck()
    {
        _dbContext = new YourDbContext();
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbContext.Database.CanConnectAsync(cancellationToken);
            return HealthCheckResult.Healthy("Database is ready :)");
        }
        catch (Exception)
        {
            return HealthCheckResult.Unhealthy("Database is not ready! :(");
        }
    }
}

public class YourDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-TVCSFN3\\MHA;Database=EFCoreExamples;Trusted_Connection=True;Encrypt=false");
    }
}