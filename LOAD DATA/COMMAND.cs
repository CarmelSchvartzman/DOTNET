 public static void SaveFileURLToDB(int id, string sLocalFile)
        {

            using (var conn = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("spSaveURL", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {

                command.Parameters.Add(new SqlParameter("@ID", id));
                command.Parameters.Add(new SqlParameter("@URL", sLocalFile));
                conn.Open();
                command.ExecuteNonQuery();
            }

        }
