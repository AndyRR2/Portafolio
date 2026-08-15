using System.Data.SQLite;

using Proyect.Models;

namespace Proyect.Repositories{
    public class LoginRepository : ILoginRepository{
        private readonly string ruteBD;
        public LoginRepository(string conectionString)
        {
            ruteBD = conectionString;
        }
        public bool AutenticateUser(string? userName, string? password)
        {
            bool validation = false;
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "SELECT * FROM UseR WHERE password = @PASS AND user_name = @USER";
            SQLiteParameter parameterUser = new SQLiteParameter("@USER", userName);
            SQLiteParameter parameterPass = new SQLiteParameter("@PASS", password);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterUser);
                commandC.Parameters.Add(parameterPass);

                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        validation = true;
                    }
                }
                connectionC.Close();
            }
            return validation;
        }
        public UseR TakeUser(string? userName, string? password)
        {
            UseR userToLogin = new UseR();
            
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "SELECT * FROM UseR WHERE password = @PASS AND user_name = @USER";
            SQLiteParameter parameterUser = new SQLiteParameter("@USER", userName);
            SQLiteParameter parameterPass = new SQLiteParameter("@PASS", password);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterUser);
                commandC.Parameters.Add(parameterPass);

                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        userToLogin.Password = Convert.ToString(readerC["password"]);
                        userToLogin.Name = Convert.ToString(readerC["user_name"]);
                        userToLogin.AccessLevel = (AccessLevel)Convert.ToInt16(readerC["access_level"]); //convert string to enum
                        userToLogin.Id = Convert.ToInt16(readerC["id"]);
                    }
                }
                connectionC.Close();
            }
            if (userToLogin == null)
            {
                throw new Exception("Is not found user in the data base.");
            }
            return(userToLogin);
        }
    }
    
}