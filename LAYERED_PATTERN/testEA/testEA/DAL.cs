using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace testEA
{
    public class DAL
    {
        #region VARIABLES

        string _cn = "server=localhost; database=testea; user id=root; pwd=Shoja@123&*^";

        //string _cn = "server=10.10.48.82; database=cc_master_db; user id=cri_archive; pwd=aaAA11!!";
        #endregion

        #region Public Functions

        public DAL()
        {
            
        }

        public DataTable LOAD_DT(string query)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = new MySqlConnection(_cn);
            cmd.Connection.Open();
            cmd.CommandText = query;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd); 
            try
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally 
            {
                da.Dispose();
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }




        /*
        public DataTable LOAD_DT(String _query)
        {
            OleDbCommand olecmd = new OleDbCommand(_query);
            olecmd.Connection = new OleDbConnection(_cn);
            olecmd.Connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(olecmd);
            
            try
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally
            {
                da.Dispose();
                olecmd.Connection.Close();
                olecmd.Dispose();
            }                   
        }
        */
        public MySqlDataAdapter GET_DA(MySqlCommand cmd)
        {
            cmd.Connection = new MySqlConnection(_cn);
            cmd.Connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            try
            {
                return da;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public void EXECUTE_Command(MySqlCommand cmd)
        {
            cmd.Connection = new MySqlConnection(_cn);
            cmd.Connection.Open();
            try
            {
                cmd.ExecuteNonQuery();

            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public int EXECUTE_Command(string _query)
        {
            int _rowsaffected = 0;
            MySqlCommand cmd = new MySqlCommand(_query);
            cmd.Connection = new MySqlConnection(_cn);
            cmd.Connection.Open();
            try
            {
                _rowsaffected=cmd.ExecuteNonQuery();

            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return _rowsaffected;
        }

        public int GET_ROLE(string _user)
        {
            MySqlCommand cmd = new MySqlCommand(string.Format("Select Fk_RoleID from tblUser where Status=0 and Username='{0}'",_user));
            cmd.Connection = new MySqlConnection(_cn);
            cmd.Connection.Open();

            int _role=0;

            try
            {
                MySqlDataReader sdr=cmd.ExecuteReader();
                while(sdr.Read())
                {
                    _role=Convert.ToInt16(sdr[0].ToString());
                }
                sdr.Close();
                return _role;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public int GET_CODE(string _query)
        {
            MySqlCommand cmd = new MySqlCommand(_query);
            cmd.Connection = new MySqlConnection(_cn);
            cmd.Connection.Open();

            int code = 0;

            try
            {
                MySqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    code = Convert.ToInt16(sdr[0].ToString());
                }
                sdr.Close();
                return code;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            
        }

        public string GET_STR_VAL(string _query)
        { 
            MySqlCommand cmd = new MySqlCommand(_query);
            cmd.Connection = new MySqlConnection(_cn);
            cmd.Connection.Open();

            string _val = "";

            try
            {
                MySqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    _val = sdr[0].ToString();
                }
                sdr.Close();
                return _val;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public bool GET_BOOL_VAL(string _query)
        {
            MySqlCommand cmd = new MySqlCommand(_query);
            cmd.Connection = new MySqlConnection(_cn);
            cmd.Connection.Open();

            bool _val = false;

            try
            {
                MySqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    _val = true;
                }
                sdr.Close();
                return _val;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        #endregion
    }
}
