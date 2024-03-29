﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FrameworkGamificacaoClasses
{
    public abstract class DAO<F, T>
    {
        public virtual SqlConnection Connection { get; set; }

        public DAO(SqlConnection connection)
        {
            Connection = connection;
        }

        public virtual void Validate(F filtro)
        {
            if (filtro == null) throw new ArgumentNullException(nameof(filtro));
        }

        public abstract string GetSqlSelect(F filtro);

        public virtual List<T> FindAll(F filtro)
        {
            var itens = new List<T>();
            IDbCommand dbCommand = Connection.CreateCommand();
            dbCommand.CommandText = GetSqlSelect(filtro);

            using (IDataReader dr = dbCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    itens.Add(LoadObject(dr));
                }
            }
            return itens;
        }

        public virtual T FindOne(F filtro)
        {
            return FindAll(filtro).FirstOrDefault();
        }

        internal abstract T LoadObject(IDataReader dr);

        public abstract void Save(T obj);
        public abstract void SaveTransaction(T obj, SqlTransaction tr);

        internal virtual void Save(List<T> objs)
        {
            IDbTransaction tr = Connection.BeginTransaction();
            try
            {

                foreach (T obj in objs)
                {
                    Save(obj);
                }

                tr.Commit();
            }
            catch (Exception)
            {
                tr.Rollback();
                throw;
            }
        }

        public abstract void Delete(T obj);
        public abstract void DeleteTransaction(T obj, SqlTransaction tr);

        internal virtual void Delete(List<T> objs)
        {
            IDbTransaction tr = Connection.BeginTransaction();
            try
            {
                foreach (T obj in objs)
                {
                    Delete(obj);
                }

                tr.Commit();
            }
            catch (Exception)
            {
                tr.Rollback();
                throw;
            }
        }

    }
}