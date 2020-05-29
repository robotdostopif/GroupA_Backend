using System.Diagnostics;
using System;
using System.IO;
using HorrorMovieAPI.Models;
using Microsoft.Extensions.Logging;

namespace HorrorMovieAPI.DB_Context.DataSeed
{
    public class TestDataSeeder
    {
        private readonly HorrorContext _context;
        public TestDataSeeder(HorrorContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            using (var reader = new StreamReader(@"DB_Context\DataSeed\IMDBHorrormovies.csv"))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        var isNumeric = int.TryParse(values[2].Trim(',').Substring(values[2].Length - 2), out int y);
                        int year = isNumeric ? int.Parse("20" + values[2].Trim(',').Substring(values[2].Length - 2)) : 0;
                        isNumeric = int.TryParse(values[6].Substring(0, 2), out int l);
                        int length = isNumeric ? int.Parse(values[6].Substring(0, 2)) : 0;
                        if (year != 0 && length != 0)
                        {
                            Movie movie = new Movie()
                            {
                                Title = values[0],
                                Length = length,
                                Year = year
                            };
                            _context.Movies.AddAsync(movie);
                        }

                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine($"Something went wrong when loading data from csv. {e.Message}");
                    }
                }
                _context.SaveChanges();

            }
        }
    }
}