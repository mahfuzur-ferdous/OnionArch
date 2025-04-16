using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace RepositoryLayer.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Apply migrations if needed
            await context.Database.MigrateAsync();

            if (!await context.todoitems.AnyAsync())
            {
                Console.WriteLine("Seeding TodoItems...");

                const int batchSize = 1000;
                const int totalBatches = 100;
               
                var random = new Random();

                for (int i = 0; i < totalBatches; i++)
                {
                    var batch = new List<TodoItems>();

                    for (int j = 0; j < batchSize; j++)
                    {
                        var itemNumber = i * batchSize + j + 1;
                        batch.Add(new TodoItems
                        {
                            Title = $"Task {itemNumber}",
                            Description = $"Description for task {itemNumber}",
                            IsCompleted = random.Next(0, 2) == 1,
                            CreatedAt = DateTime.UtcNow
                        });
                    }

                    await context.todoitems.AddRangeAsync(batch);
                    await context.SaveChangesAsync();

                    Console.WriteLine($"Batch {i + 1}/{totalBatches} seeded.");
                }

                Console.WriteLine("Seeding complete!");
            }
            else
            {
                Console.WriteLine("TodoItems already exist. Skipping seeding.");
            }
        }
    }
}
