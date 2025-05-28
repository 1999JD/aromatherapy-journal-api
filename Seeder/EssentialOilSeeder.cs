using System.Text.Json;
using api.Models;
using Microsoft.EntityFrameworkCore;

public class EssentialOilSeeder
{
    public class RawEssentialOil
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public List<RawTag> Tags { get; set; } = new();
    }

    public class RawTag
    {
        public string Name { get; set; }
        public string Color { get; set; } // <== 改為 nullable
        // public string Color { get; set; }
    }

    public static async Task SeedFromJsonAsync(ApplicationDbContext dbContext, string jsonPath)
    {
        Console.WriteLine("🟢 Seeder 開始執行...");
        if (await dbContext.EssentialOils.AnyAsync())
        {
            Console.WriteLine("⚠️ 已有資料，跳過 Seeder。");
            return;
        }

        var json = await File.ReadAllTextAsync(jsonPath);
        var rawOils = JsonSerializer.Deserialize<List<RawEssentialOil>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (rawOils == null)
        {
            Console.WriteLine("❌ JSON 轉換失敗");
            return;
        }

        // Step 1: 收集所有 tag 名稱
        var tagDict = new Dictionary<string, Tag>();

        foreach (var oil in rawOils)
        {
            foreach (var tag in oil.Tags)
            {
                if (!tagDict.ContainsKey(tag.Name))
                {
                    tagDict[tag.Name] = new Tag
                    {
                        Name = tag.Name,
                        Color = tag.Color
                        // Color 可加在這裡，如果你之後打算存進 Tag 表
                    };
                }
            }
        }

        // Step 2: 寫入所有唯一的 Tag
        dbContext.Tags.AddRange(tagDict.Values);
        await dbContext.SaveChangesAsync();

        // Step 3: 建立 EssentialOil 並連結 Tag
        var essentialOils = new List<EssentialOil>();
        foreach (var rawOil in rawOils)
        {
            var existingOil = await dbContext.EssentialOils
                .Include(e => e.Tags)
                .FirstOrDefaultAsync(e => e.Name == rawOil.Name);

            if (existingOil != null)
            {
                existingOil.Note = rawOil.Note;
                existingOil.EnglishName = rawOil.Name;
                existingOil.ScientificName = rawOil.Name;

                dbContext.EssentialOilTags.RemoveRange(existingOil.Tags);

                existingOil.Tags = rawOil.Tags.Select(t => new EssentialOilTag
                {
                    EssentialOilId = existingOil.Id,
                    TagId = tagDict[t.Name].Id
                }).ToList();
            }
            else
            {
                var newOil = new EssentialOil
                {
                    Name = rawOil.Name,
                    EnglishName = rawOil.Name,
                    ScientificName = rawOil.Name,
                    Note = rawOil.Note,
                    Tags = rawOil.Tags.Select(t => new EssentialOilTag
                    {
                        TagId = tagDict[t.Name].Id
                    }).ToList()
                };

                dbContext.EssentialOils.Add(newOil);
            }
        }

        dbContext.EssentialOils.AddRange(essentialOils);
        await dbContext.SaveChangesAsync();

        Console.WriteLine($"✅ 寫入 {essentialOils.Count} 筆資料成功！");
    }

}
