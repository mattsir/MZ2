using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace DBUtility
{
    public class OleHelper
    {
        private OleDbConnection myCon;
        private OleDbCommand myCom;
        private string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=|DataDirectory|MZ.mdb";
        public OleHelper()
        {

        }

        //public OleDbCommand GetCommand()
        //{
        //    String strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=|DataDirectory|MZ.mdb";
        //    myCon = new OleDbConnection(strCon);
        //    myCon.Open();
        //    myCom = new OleDbCommand();
        //    myCom.Connection = myCon;
        //    return myCom;
        //}

        public int Execute(string sql)
        {
           // String strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=|DataDirectory|MZ.mdb";
            myCon = new OleDbConnection(connString);
            myCon.Open();
            myCom = new OleDbCommand();
            myCom.Connection = myCon;
            myCom.CommandText = sql;
            return myCom.ExecuteNonQuery();
        }

        public DataTable Query(string sql)
        {
            //String strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=|DataDirectory|MZ.mdb";
            myCon = new OleDbConnection(connString);
            myCon.Open();
            myCom = new OleDbCommand();
            myCom.Connection = myCon;
            myCom.CommandText = sql;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCom;
            DataTable Dt = new DataTable();
            adapter.Fill(Dt);
            return Dt;
        }

        public DataSet QueryDs(string sql)
        {
            //String strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=|DataDirectory|MZ.mdb";
            myCon = new OleDbConnection(connString);
            myCon.Open();
            myCom = new OleDbCommand();
            myCom.Connection = myCon;
            myCom.CommandText = sql;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCom;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Blog");
            Close();
            return ds;
        }

        public DataTable Query(string sql, int CurrentPage, int PageItem, string tablename)
        {
            myCon = new OleDbConnection(connString);
            myCon.Open();
            //myCom = new OleDbCommand();
            //myCom.Connection = myCon;
            //myCom.CommandText = sql;
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql,myCon);

            DataSet ds = new DataSet();
            int startRecord = (CurrentPage - 1) * PageItem;
            adapter.Fill(ds, startRecord, PageItem, tablename);
            Close();
            return ds.Tables[0];
        }

        public string Scalar(string sql)
        {
            //String strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=|DataDirectory|MZ.mdb";
            myCon = new OleDbConnection(connString);
            myCon.Open();
            myCom = new OleDbCommand();
            myCom.Connection = myCon;
            myCom.CommandText = sql;
            return myCom.ExecuteScalar().ToString();
        }


        public void Close()
        {
            myCon.Close();
        }
    }
}
