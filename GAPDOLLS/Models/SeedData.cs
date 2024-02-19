using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GAPDOLLS.Data;
using System;
using System.Linq;
using System.Drawing;
using GAPDOLLS.Models;

namespace MvcDolls.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new GAPDOLLSContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<GAPDOLLSContext>>()))
        {
            // Look for any Dollss.
            if (context.Dolls.Any())
            {
                return;   // DB has been seeded
            }
            context.Dolls.AddRange(
                new Dolls
                {
                     Material = "Cotton",
                     Color = "Pink",
                     ManufactureDate = DateTime.Parse("2023-3-13"),
                     Articulation = "Movable Joints in the Arms",
                     Price = 25M,
                     Rating = 4,
                    Size = 10*8*9,
                     EyeColor = "Black",
                     SkinTone = "Orange",
                     Outfit = "Dress",
                     Accessories = "Hat",
                     Washability = "Yes"
                },
                new Dolls
                {
                    Material = "Cotton",
                    Color = "Pink",
                    ManufactureDate = DateTime.Parse("2023-3-13"),
                    Articulation = "Movable Joints in the Arms",
                    Price = 25M,
                    Rating = 4,
                    Size = 10*8*9,
                    EyeColor = "Black",
                    SkinTone = "Orange",
                    Outfit = "Dress",
                    Accessories = "Hat",
                    Washability = "Yes"
                },
                new Dolls
                {
                    Material = "Cotton",
                    Color = "Pink",
                    ManufactureDate = DateTime.Parse("2023-3-13"),
                    Articulation = "Movable Joints in the Arms",
                    Price = 25M,
                    Rating = 4,
                    Size = 10*8*9,
                    EyeColor = "Black",
                    SkinTone = "Orange",
                    Outfit = "Dress",
                    Accessories = "Hat",
                    Washability = "Yes"
                },
                new Dolls
                {
                    Material = "Cotton",
                    Color = "Pink",
                    ManufactureDate = DateTime.Parse("2023-3-13"),
                    Articulation = "Movable Joints in the Arms",
                    Price = 25M,
                    Rating = 4,
                    Size = 10*8*9,
                    EyeColor = "Black",
                    SkinTone = "Orange",
                    Outfit = "Dress",
                    Accessories = "Hat",
                    Washability = "Yes"
                }
            );
            context.SaveChanges();
        }
    }
}