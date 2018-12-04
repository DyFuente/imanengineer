﻿using Logic.Database;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class ChannelRepository : IRepository<Channel>
    {
        private readonly string connectionString = "Server=tcp:whatsontv-db.database.windows.net,1433;Initial Catalog=whatsontv-db;Persist Security Info=False;User ID=TvApplication;Password=Tv@pplicati0n;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        private IDbConnection Connection {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        private readonly SQLBuilder<Channel> sqlBuilder = new SQLBuilder<Channel>();

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Channel> Get(Func<Channel, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Channel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Channel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Channel> Insert(Channel value)
        {
            Connection.Execute(sqlBuilder.BuildInsert(new List<Channel>() { value }));
            return Connection.Query<Channel>(sqlBuilder.BuildSelect());
        }

        public IEnumerable<Channel> InsertAll(IEnumerable<Channel> values)
        {
            Connection.Execute(sqlBuilder.BuildInsert(values));
            return Connection.Query<Channel>(sqlBuilder.BuildSelect());
        }

        public void Replace(int id, Channel value)
        {
            throw new NotImplementedException();
        }
    }
}
