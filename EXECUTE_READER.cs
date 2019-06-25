private void LoadEmployee()
{
    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    using (SqlConnection con = new SqlConnection(CS))
    {
        string sqlQuery = "Select Id, Name, Gender, DeptName from tblEmployees where Id=202";
        SqlCommand cmd = new SqlCommand(sqlQuery, con);
        con.Open();
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                txtName.Text = rdr["Name"].ToString();
                txtGender.Text = rdr["Gender"].ToString();
                txtDept.Text = rdr["DeptName"].ToString();
                HiddenField1.Value = rdr["Id"].ToString();
            }
        }
    }
}
