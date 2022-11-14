using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QA_site.Data;
using System.IO;

namespace QASite.Data
{
    public class QAContextFactory : IDesignTimeDbContextFactory<QADataContext>
    {
        public QADataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}QA-Site.Web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new QADataContext(config.GetConnectionString("ConStr"));
        }
    }
}