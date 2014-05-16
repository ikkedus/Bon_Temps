using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for surfboard
/// </summary>
public class dbconnect
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString;
    public dbconnect()
    {

    }
    public DataTable gettable(string tablename,string strorder)
    {

        DataTable dt = new DataTable();
        string query = "";
        if (strorder == "")
        {
             query = "select * from" + tablename;
        }
        else
        {
             query = "select * from" + tablename + "order by" + strorder;
        }
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cnd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(cnd);
        da.Fill(dt);
        da.Dispose();
        return dt;
    }
    public DataTable openQuery(string query)
    {

        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cnd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(cnd);
        da.Fill(dt);
        da.Dispose();
        return dt;
    }
    public void RemoveRow(string tablename , int id)
    {
        string query = "remove from "+tablename +"where id = "+id;
       
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cnd = new SqlCommand(query, conn);
        conn.Open();
    }
    public DataTable GetOneRow(string tablename , int id)
    {
        string query = "Select * from "+tablename +"where id = "+id;
        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cnd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(cnd);
        da.Fill(dt);
        da.Dispose();
        return dt;
    }
    public bool check(string tablename , string Checkable, string Columname) {
        bool toggle = false;
        DataTable dt = new DataTable();
        string query = "Select * From " + tablename + " where " + Columname + "=" + Checkable;
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cnd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(cnd);
        da.Fill(dt);
        da.Dispose();

      
        return toggle;
    }
}