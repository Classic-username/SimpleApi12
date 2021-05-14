using Npgsql;
using SimpleApi12.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi12.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        //We want to return everything from the database from as their type (ex phone numbers are longs). Objects would be a second to last resort.
        public async Task<string> GetDatabaseVersion()
        {
            //generally want to hide these in app settings, but this is a beginner thing so for ease we're doign it here
            var conn = new NpgsqlConnection("Host=ec2-107-20-153-39.compute-1.amazonaws.com;Username=dlueamvgkvpzyi;Password=a47390a6870f95d0500245d128311ea13a4f1c9fb330867a5b0650f1efea8ad4;Database=dcque2eluhdio6;Port=5432;SSL Mode=Prefer;Trust Server Certificate=true");
            var command = new NpgsqlCommand();
            command.Connection = conn;
            //look up reader npgsql to see how you (me) can write in command text
            command.CommandText = "SELECT version();";
            await conn.OpenAsync();
            var result = await command.ExecuteScalarAsync();
            await conn.CloseAsync();
            return result.ToString();
        }
    }
}
