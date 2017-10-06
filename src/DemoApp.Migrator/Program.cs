using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Net.Sockets;

namespace DemoApp.Migrator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting the migrator");

            Policy.Handle<SocketException>()
                .WaitAndRetry(10, (i) => TimeSpan.FromSeconds(i * 10))
                .Execute(MigrateDb);
        }

        private static void MigrateDb()
        {
            using (var context = ContextProvider.GetDbContext())
            {
                context.Database.Migrate();
            }
        }
    }
}