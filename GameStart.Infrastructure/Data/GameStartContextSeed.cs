using GameStart.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Infrastructure.Data
{
    public class GameStartContextSeed
    {
        public static async Task SeedAsync(GameStartContext catalogContext,
        ILoggerFactory loggerFactory, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (catalogContext.Database.IsSqlServer())
                {
                    catalogContext.Database.Migrate();
                }

                if (!await catalogContext.Categories.AnyAsync())
                {
                    await catalogContext.Categories.AddRangeAsync(
                        GetPreconfiguredCategories());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.Products.AnyAsync())
                {
                    await catalogContext.Products.AddRangeAsync(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;
                var log = loggerFactory.CreateLogger<GameStartContextSeed>();
                log.LogError(ex.Message);
                await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                throw;
            }
        }

        

        static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>
            {
                new("Games", "Go into the simulation"),
                new("Consoles", "Powerhouses"),
                new("Controllers", "Take Control")
            };
        }

        static IEnumerable<Product> GetPreconfiguredItems()
        {
            return new List<Product>
            {
                new(1, "Valheim", "A brutal exploration game.", 179, 100),
                new(1, "World of Warcraft", "Seriously... Don't buy this", 189, 100),
                new(1, "Zelda Breath of Wild 2", "Travel and exploration game", 200, 100),
                new(1, "Elden Ring", "The new fantasy action rpg", 599, 100),
                new(1, "New World", "Explore a thrilling world", 399, 100),
                new(2, "Playstation 4", "Heighten you experience", 3499, 100),
                new(2, "Playstation 5", "Experience lightning-fast loading", 7499, 100),
                new(2, "Xbox series X", "Take your gaming to the next level", 6999, 100),
                new(2, "Nintendo Switch", "Nintendo Switch is designed to fit your life.", 2999, 100),
                new(2, "Google Stadia", "Cloud gaming service", 4999, 100),
                new(3, "Playstation 4 Controller", "Firm grip", 150, 100),
                new(3, "Playstation 5 Controller", "Firmer grip", 200, 100),
                new(3, "Xbox series X Controller", "It's all about speed", 200, 100),
                new(3, "Nintendo Switch Joy-con", "Two movable controllers", 149, 100),
                new(3, "Nintento Switch Pro Controller", "Pro Nintendo movement", 179, 100)
            };
        }
    }
}
