using System;
using System.Data;
using System.Data.SqlClient;

namespace CleanArchitecture.ApplicationCore.Common
{
    public class DBAccess : IDisposable
    {

        private IDbCommand cmd = new SqlCommand();
        private string strConnectionString = "";
        private bool handleErrors = false;
        private string strLastError = "";
        // private readonly IConfiguration configration;

        public DBAccess()
        {
            ///this.configration = config;
            strConnectionString = "Server=database-2.chqz0ssqu3ql.us-east-2.rds.amazonaws.com;Database=EasyHealth;User Id=admin;Password=Year123456;MultipleActiveResultSets=true;";
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = "Server=database-2.chqz0ssqu3ql.us-east-2.rds.amazonaws.com;Database=EasyHealth;User Id=admin;Password=Year123456;MultipleActiveResultSets=true;"; //strConnectionString;
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
        }


        public IDataReader ExecuteReader()
        {
            IDataReader reader = null;
            try
            {

                this.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            finally { this.Close(); }
            return reader;
        }

        //public IDataReader ExecuteReader(string commandtext)
        //{
        //    IDataReader reader=null;
        //    try
        //    {
        //        cmd.CommandText=commandtext;
        //        reader=this.ExecuteReader();
        //    }
        //    catch(Exception ex)
        //    {
        //        if(handleErrors)
        //            strLastError=ex.Message;
        //        else
        //            throw;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    //finally { this.Close(); }
        //    return reader;
        //}


        public IDataReader ExecuteReader(string commandtext)
        {
            IDataReader reader = null;
            try
            {
                cmd.CommandText = commandtext;
                //  reader = this.ExecuteReader();
                this.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            return reader;
        }

        public object ExecuteScalar()
        {
            object obj = null;
            try
            {
                this.Open();
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            finally { this.Close(); }
            return obj;
        }

        public object ExecuteScalar(string commandtext)
        {
            object obj = null;
            try
            {
                cmd.CommandText = commandtext;
                obj = this.ExecuteScalar();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            finally { this.Close(); }
            return obj;
        }

        public int ExecuteNonQuery()
        {
            int i = -1;
            try
            {
                this.Open();
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            finally { this.Close(); }
            return i;
        }


        /// <summary>
        /// ExecuteNonQuery returns no of rows effected
        /// </summary>
        /// <param name="commandtext"> Stored procedure name</param>
        /// <returns>returns no of rows effected</returns>
        public int ExecuteNonQuery(string commandtext)
        {
            int i = -1;
            try
            {
                cmd.CommandText = commandtext;
                i = this.ExecuteNonQuery();
                this.Close();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            finally { this.Close(); }
            return i;
        }


        public DataSet ExecuteDataSet()
        {
            SqlDataAdapter da = null;
            DataSet ds = null;
            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = (SqlCommand)cmd;
                ds = new DataSet();
                da.Fill(ds);
                this.Close();

            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            finally { this.Close(); }
            return ds;
        }


        public DataSet ExecuteDataSet(string commandtext)
        {
            DataSet ds = null;
            try
            {
                cmd.CommandText = commandtext;
                ds = this.ExecuteDataSet();
                this.Close();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            finally { this.Close(); }
            return ds;
        }

        public string CommandText
        {
            get
            {
                return cmd.CommandText;
            }
            set
            {
                cmd.CommandText = value;
                cmd.Parameters.Clear();
            }
        }

        public IDataParameterCollection Parameters
        {
            get
            {
                return cmd.Parameters;
            }
        }

        public void AddParameter(string paramname, object paramvalue)
        {
            SqlParameter param = new SqlParameter(paramname, paramvalue);
            cmd.Parameters.Add(param);
        }

        public void AddParameter(IDataParameter param)
        {
            cmd.Parameters.Add(param);
        }

        public DataTable GetDataTable(string commandtext)
        {
            DataTable dt = null;
            try
            {
                cmd.CommandText = commandtext;
                dt = this.GetDataTable();
                this.Close();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            return dt;
        }
        public DataTable GetDataTable()
        {
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = (SqlCommand)cmd;
                dt = new DataTable();
                da.Fill(dt);
                this.Close();
            }
            catch (Exception ex)
            {
                if (handleErrors)
                    strLastError = ex.Message;
                else
                    throw;
            }

            return dt;
        }
        public void ClearParameter()
        {
            cmd.Parameters.Clear();

        }


        public void ConnectionClose()
        {
            this.Close();
        }

        public string ConnectionString
        {
            get
            {
                return strConnectionString;
            }
            set
            {
                strConnectionString = value;
            }
        }

        private void Open()
        {
            cmd.Connection.Open();
        }

        private void Close()
        {
            cmd.Connection.Close();
            cmd.Parameters.Clear();
        }

        public bool HandleExceptions
        {
            get
            {
                return handleErrors;
            }
            set
            {
                handleErrors = value;
            }
        }

        public string LastError
        {
            get
            {
                return strLastError;
            }
        }

        public void Dispose()
        {
            cmd.Dispose();
        }
    }
}
