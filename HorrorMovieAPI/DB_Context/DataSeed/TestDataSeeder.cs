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
        private readonly ILogger<TestDataSeeder> _logger;
        public TestDataSeeder(HorrorContext context, ILogger<TestDataSeeder> logger)
        {
            _context = context;
            _logger = logger;
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
                        int year = int.TryParse("20" + values[2].Trim(',').Substring(values[2].Length - 2), out int y) ? y : 0;
                        int length = int.TryParse(values[6].Replace(" min", ""), out int l) ? l : 0;
                        double rating = double.TryParse(values[5], out double d) ? d : 0;
                        string country = values[3];
                        string language = values[7].Replace(" ", "");
                        int budget = int.TryParse((values[8] + values[9]).Replace("$", "").Replace(",", "").Replace(" ", "").Replace("\"", "").Replace("\\", ""), out int b) ? b : 0;
                       
                        if (year != 0 && length != 0 && budget > 0)
                        {
                            Movie movie = new Movie()
                            {
                                Title = values[0],
                                Length = length,
                                Year = year,
                                Rating = rating,
                                Country = country,
                                Language = language,
                                BudgetInUsd = budget
                            };
                            _context.Movies.AddAsync(movie);
                        }

                    }
                    catch (Exception e)
                    {
                        _logger.LogInformation($"Something went wrong when loading data from csv. {e.Message}");
                    }
                }
                _context.SaveChanges();

            }
        }
    }
}