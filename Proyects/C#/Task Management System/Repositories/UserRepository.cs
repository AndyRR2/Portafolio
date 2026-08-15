using System.Data.SQLite;

using Proyect.Models;

namespace Proyect.Repositories{
    public class UserRepository: IUserRepository{
        private readonly string ruteBD;
        private readonly IBoardRepository repoBoard;
        private readonly ITaskRepository repoTask;
        public UserRepository(string conectionString, IBoardRepository boardRepo, ITaskRepository TaskRepo)
        {
            ruteBD = conectionString;
            repoBoard = boardRepo;
            repoTask = TaskRepo;
        }
        public List<UseR> GetAll(){
            List<UseR> users = new List<UseR>();
            
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "SELECT * FROM UseR;";

            using(connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                
                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        UseR userToAdd = new UseR();
                        userToAdd.Id = Convert.ToInt32(readerC["id"]);
                        userToAdd.Name = Convert.ToString(readerC["user_name"]);
                        userToAdd.AccessLevel = (AccessLevel)Convert.ToInt16(readerC["access_level"]);
                        users.Add(userToAdd);
                    }   
                }
                connectionC.Close();
            }
            if (users.Count == 0)
            {
                throw new Exception("Were not found users in the data base.");
            }
            return(users);
        }
        public UseR GetById(int? Id){
            UseR userSelected = new UseR();
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "SELECT * FROM UseR WHERE id = @ID";
            SQLiteParameter parameterId = new SQLiteParameter("@ID", Id);
            
            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);
                
                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        userSelected.Id = Convert.ToInt32(readerC["id"]);
                        userSelected.Name = Convert.ToString(readerC["user_name"]);
                        userSelected.Password = Convert.ToString(readerC["password"]);
                        userSelected.AccessLevel = (AccessLevel)Convert.ToInt16(readerC["access_level"]);
                    }
                }
                connectionC.Close();
            }
            if (userSelected==null){
                throw new Exception("Is not found user with the id provided in the database.");
            }
            return(userSelected);
        }
        public void Create(UseR newUser){
            if (UserExists(newUser.Name))
            {
                throw new Exception("The UseR already exists.");
            }
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            
            string queryC = $"INSERT INTO UseR (user_name, password, access_level) VALUES (@NAME,@PASS,@LEVEL)";
            SQLiteParameter parameterName = new SQLiteParameter("@NAME",newUser.Name);
            SQLiteParameter parameterPass = new SQLiteParameter("@PASS",newUser.Password);
            SQLiteParameter parameterLevel = new SQLiteParameter("@LEVEL",newUser.AccessLevel);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterName);
                commandC.Parameters.Add(parameterPass);
                commandC.Parameters.Add(parameterLevel);

                commandC.ExecuteNonQuery();
                connectionC.Close();
            }
            if (newUser==null){
                throw new Exception("The UseR was not created correctly.");
            }
        }
        public void Update(UseR newUser){
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            
            string queryC = "UPDATE UseR SET user_name = @NAME, password = @PASS, access_level = @LEVEL WHERE id = @ID";
            SQLiteParameter parameterId = new SQLiteParameter("@ID",newUser.Id);
            SQLiteParameter parameterName = new SQLiteParameter("@NAME",newUser.Name);
            SQLiteParameter parameterPass = new SQLiteParameter("@PASS",newUser.Password);
            SQLiteParameter parameterLevel = new SQLiteParameter("@LEVEL",newUser.AccessLevel);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);
                commandC.Parameters.Add(parameterName);
                commandC.Parameters.Add(parameterPass);
                commandC.Parameters.Add(parameterLevel);
                
                int rowsAffected = commandC.ExecuteNonQuery();
                connectionC.Close();
                
                if (rowsAffected == 0){
                    throw new Exception("Not Found user with the ID provided.");
                }
            }
        }
        public void Remove(int? idUser){
            
            foreach (var board in repoBoard.GetAllByOwnerUser(idUser))//disable all user boards to delete
            {
                repoBoard.Disable(board.Id);
            }
            foreach (var TasK in repoTask.GetAllByOwnerUser(idUser))//disable all user Tasks to delete
            {
                repoTask.DisableByDeletedUser(idUser);
            }

            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            
            string queryC = "DELETE FROM UseR WHERE id = @ID";
            SQLiteParameter parameterId = new SQLiteParameter("@ID",idUser);

            using(connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);
                
                int rowsAffected = commandC.ExecuteNonQuery();
                
                if (rowsAffected == 0){
                    throw new Exception("Not Found user with the ID provided.");
                }
                connectionC.Close();
            }
        }

        public bool UserExists(string? userName){
            bool validation=false;
            string? Name=null;
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "SELECT * FROM UseR WHERE user_name = @NAME";
            SQLiteParameter parameterName = new SQLiteParameter("@NAME",userName);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterName);
                
                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        Name = Convert.ToString(readerC["user_name"]);
                    }
                }
                connectionC.Close();
            }
            if (Name!=null){
                validation=true;
            }
            return validation;
        }
    }
}