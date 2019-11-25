private static DataSet GetData()
        {
            try
            {
                SqlConnection oConn = new SqlConnection("Data Source=XXXXXX;Initial Catalog=XXXX;Integrated Security=SSPI ; User Id=XXXXX;Password=XXXXX; MultipleActiveResultSets=true");

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand();
                    da.SelectCommand.Connection = oConn;
                    da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    da.SelectCommand.CommandText = "SP_TENDER_ASPOSE";
                    da.SelectCommand.Parameters.Add(new SqlParameter("@TENDER", "199"));  // 2475

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Clauses");

                    return ds;

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }



...............

DataTable dt = ds.Tables["Clauses"];
foreach (DataRow record in dt.Rows)
            {
                DoSomething(..........., record);
            }


