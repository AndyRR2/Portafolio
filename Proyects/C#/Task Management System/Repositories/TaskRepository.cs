using System.Data.SQLite;

using Proyect.Models;

namespace Proyect.Repositories{
    public class TaskRepository: ITaskRepository{
        private readonly string ruteBD;
        public TaskRepository(string conectionString)
        {
            ruteBD = conectionString;
        }
        public List<TasK> GetAll(){
            List<TasK> Tasks = new List<TasK>();
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = @"SELECT TasK.id AS TaskId, TasK.id_board, TasK.name, TasK.status, TasK.description, TasK.color, TasK.id_assigned_user, TasK.id_propietary_user, 
                            Board.board_name AS board_name, 
                            AssignedUser.user_name AS assigned_name, 
                            PropietaryUser.user_name AS propietary_name
                            FROM TasK
                            LEFT JOIN Board ON Board.id = TasK.id_board
                            LEFT JOIN UseR AS AssignedUser ON AssignedUser.id = TasK.id_assigned_user
                            LEFT JOIN UseR AS PropietaryUser ON PropietaryUser.id = TasK.id_propietary_user;";

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC, connectionC);
                
                SQLiteDataReader readerC = commandC.ExecuteReader();
                using(readerC)
                {
                    while (readerC.Read())
                    {
                        var newTask = new TasK();
                        newTask.Id = Convert.ToInt32(readerC["TaskId"]);
                        newTask.Name = Convert.ToString(readerC["name"]);
                        newTask.TaskStat = (TaskStat)Convert.ToInt32(readerC["status"]);
                        newTask.Description = Convert.ToString(readerC["description"]);
                        newTask.Color = (Color)Convert.ToInt32(readerC["color"]);
                        newTask.OwnBoard = new Board();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_board"))){
                            newTask.OwnBoard.Id = Convert.ToInt32(readerC["id_board"]);
                            newTask.OwnBoard.Name = Convert.ToString(readerC["board_name"]);
                        }
                        newTask.Assigned = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_assigned_user"))){
                            newTask.Assigned.Id = Convert.ToInt32(readerC["id_assigned_user"]);
                            newTask.Assigned.Name = Convert.ToString(readerC["assigned_name"]);
                        }
                        newTask.Propietary = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_propietary_user"))){
                            newTask.Propietary.Id = Convert.ToInt32(readerC["id_propietary_user"]);
                            newTask.Propietary.Name = Convert.ToString(readerC["propietary_name"]);
                        }
                        Tasks.Add(newTask);
                    }
                }
                connectionC.Close();
            }
            if (Tasks == null){
                throw new Exception("Were not found Tasks in the data base.");
            }
            return Tasks;
        }
        public List<TasK> GetAllByOwnerBoard(int? idBoard){
            List<TasK> Tasks = new List<TasK>();
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            
            string queryC = @"SELECT TasK.id AS TaskId, TasK.id_board, TasK.name, TasK.status, TasK.description, TasK.color, TasK.id_assigned_user, TasK.id_propietary_user, 
                            Board.board_name AS board_name, 
                            AssignedUser.user_name AS assigned_name, 
                            PropietaryUser.user_name AS propietary_name
                            FROM TasK
                            INNER JOIN Board ON Board.id = TasK.id_board
                            LEFT JOIN UseR AS AssignedUser ON AssignedUser.id = TasK.id_assigned_user
                            LEFT JOIN UseR AS PropietaryUser ON PropietaryUser.id = TasK.id_propietary_user
                            WHERE TasK.id_board = @IDBOARD;"; 
            SQLiteParameter parameterIdBoard = new SQLiteParameter("@IDBOARD",idBoard);

            using(connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterIdBoard);

                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        var newTask = new TasK();
                        newTask.Id = Convert.ToInt32(readerC["TaskId"]);
                        newTask.Name = Convert.ToString(readerC["name"]);
                        newTask.TaskStat = (TaskStat)Convert.ToInt32(readerC["status"]);
                        newTask.Description = Convert.ToString(readerC["description"]);
                        newTask.Color = (Color)Convert.ToInt32(readerC["color"]);
                        newTask.OwnBoard = new Board();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_board"))){
                            newTask.OwnBoard.Id = Convert.ToInt32(readerC["id_board"]);
                            newTask.OwnBoard.Name = Convert.ToString(readerC["board_name"]);
                        }
                        newTask.Assigned = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_assigned_user"))){
                            newTask.Assigned.Id = Convert.ToInt32(readerC["id_assigned_user"]);
                            newTask.Assigned.Name = Convert.ToString(readerC["assigned_name"]);
                        }
                        newTask.Propietary = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_propietary_user"))){
                            newTask.Propietary.Id = Convert.ToInt32(readerC["id_propietary_user"]);
                            newTask.Propietary.Name = Convert.ToString(readerC["propietary_name"]);
                        }
                        Tasks.Add(newTask);
                    }
                }
                connectionC.Close();           
            }
            if (Tasks == null){
                throw new Exception("The Board provided has no Tasks.");
            }
            return(Tasks);
        }
        public TasK GetById(int? idTask){
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            TasK newTask = new TasK();
            string queryC = @"SELECT TasK.id AS TaskId, TasK.id_board, TasK.name, TasK.status, TasK.description, TasK.color, TasK.id_assigned_user, TasK.id_propietary_user, 
                            Board.board_name AS board_name, 
                            AssignedUser.user_name AS assigned_name, 
                            PropietaryUser.user_name AS propietary_name
                            FROM TasK
                            LEFT JOIN Board ON Board.id = TasK.id_board
                            LEFT JOIN UseR AS AssignedUser ON AssignedUser.id = TasK.id_assigned_user
                            LEFT JOIN UseR AS PropietaryUser ON PropietaryUser.id = TasK.id_propietary_user
                            WHERE TasK.id = @ID;"; 
            SQLiteParameter parameterId = new SQLiteParameter("@ID", idTask);
            
            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);

                SQLiteDataReader readerC = commandC.ExecuteReader();
                using(readerC)
                {
                    while (readerC.Read())
                    {
                        newTask.Id = Convert.ToInt32(readerC["TaskId"]);
                        newTask.Name = Convert.ToString(readerC["name"]);
                        newTask.TaskStat = (TaskStat)Convert.ToInt32(readerC["status"]);
                        newTask.Description = Convert.ToString(readerC["description"]);
                        newTask.Color = (Proyect.Models.Color)Convert.ToInt32(readerC["color"]);
                        newTask.OwnBoard = new Board();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_board"))){
                            newTask.OwnBoard.Id = Convert.ToInt32(readerC["id_board"]);
                            newTask.OwnBoard.Name = Convert.ToString(readerC["board_name"]);
                        }
                        newTask.Assigned = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_assigned_user"))){
                            newTask.Assigned.Id = Convert.ToInt32(readerC["id_assigned_user"]);
                            newTask.Assigned.Name = Convert.ToString(readerC["assigned_name"]);
                        }
                        newTask.Propietary = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_propietary_user"))){
                            newTask.Propietary.Id = Convert.ToInt32(readerC["id_propietary_user"]);
                            newTask.Propietary.Name = Convert.ToString(readerC["propietary_name"]);
                        }
                    }
                }
                connectionC.Close();
            }
            if (newTask == null){
                throw new Exception("No TasK with the ID provided was found.");
            }
            return(newTask);
        }
        public void Create(TasK newTask){
            if (TaskExists(newTask.Name))
            {
                throw new Exception("The TasK already exists.");
            }
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = $"INSERT INTO TasK (id_board,name,status,description,color,id_assigned_user,id_propietary_user) VALUES (@IDBOARD,@NAME,@STATUS,@DESCRIPTION,@COLOR,@IDUSER,@IDUSERP)";
            SQLiteParameter parameterName = new SQLiteParameter("@NAME",newTask.Name);
            SQLiteParameter parameterStatus = new SQLiteParameter("@STATUS",newTask.TaskStat);
            SQLiteParameter parameterDescription = new SQLiteParameter("@DESCRIPTION",newTask.Description);
            SQLiteParameter parameterColor = new SQLiteParameter("@COLOR",newTask.Color);
            SQLiteParameter parameterIdUserA = new SQLiteParameter("@IDUSER",newTask.Assigned.Id);
            SQLiteParameter parameterIdBoard = new SQLiteParameter("@IDBOARD",newTask.OwnBoard.Id);
            SQLiteParameter parameterIdUserP = new SQLiteParameter("@IDUSERP",newTask.Propietary.Id);
            
            using (connectionC)
            {
                connectionC.Open();
                var commandC = new SQLiteCommand(queryC, connectionC);
                commandC.Parameters.Add(parameterName);
                commandC.Parameters.Add(parameterStatus);
                commandC.Parameters.Add(parameterDescription);
                commandC.Parameters.Add(parameterColor);
                commandC.Parameters.Add(parameterIdBoard);
                commandC.Parameters.Add(parameterIdUserA);
                commandC.Parameters.Add(parameterIdUserP);
                
                commandC.ExecuteNonQuery();
                connectionC.Close();   
            }
            if (newTask == null){
                throw new Exception("The TasK was not created correctly.");
            }
        }
        public void Update(TasK TaskToEdit){
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "UPDATE TasK SET name = @NAME, description = @DESCRIPTION, id_board = @IDBOARD, status = @STATUS, color = @COLOR, id_propietary_user = @IDUSERP WHERE id = @ID;";
            SQLiteParameter parameterId = new SQLiteParameter("@ID",TaskToEdit.Id);
            SQLiteParameter parameterIdBoard = new SQLiteParameter("@IDBOARD",TaskToEdit.OwnBoard.Id);
            SQLiteParameter parameterName = new SQLiteParameter("@NAME",TaskToEdit.Name);
            SQLiteParameter parameterStatus = new SQLiteParameter("@STATUS",TaskToEdit.TaskStat);
            SQLiteParameter parameterDescription = new SQLiteParameter("@DESCRIPTION",TaskToEdit.Description);
            SQLiteParameter parameterColor = new SQLiteParameter("@COLOR",TaskToEdit.Color);
            SQLiteParameter parameterIdUserP = new SQLiteParameter("@IDUSERP",TaskToEdit.Propietary.Id);
            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);
                commandC.Parameters.Add(parameterIdBoard);
                commandC.Parameters.Add(parameterName);
                commandC.Parameters.Add(parameterStatus);
                commandC.Parameters.Add(parameterDescription);
                commandC.Parameters.Add(parameterColor);
                commandC.Parameters.Add(parameterIdUserP);

                int rowsAffected = commandC.ExecuteNonQuery();
                connectionC.Close();
                if (rowsAffected == 0){
                    throw new Exception("No TasK with the ID provided was found.");
                }   
            }
        }
        public void Remove(int? idTask){
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "DELETE FROM TasK WHERE id = @ID";
            SQLiteParameter parameterId = new SQLiteParameter("@ID", idTask);
            
            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);

                int rowsAffected = commandC.ExecuteNonQuery();
                connectionC.Close();
                if (rowsAffected == 0){
                    throw new Exception("No TasK with the ID provided was found.");
                }
            }
        }
        public void Assign(int? idTask, int? idUser){
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "UPDATE TasK SET id_assigned_user = @IDUSER WHERE id = @ID;";
            SQLiteParameter parameterId = new SQLiteParameter("@ID",idTask);
            SQLiteParameter parameterIdUser = new SQLiteParameter("@IDUSER",idUser);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);
                commandC.Parameters.Add(parameterIdUser);

                int rowsAffected = commandC.ExecuteNonQuery();
                connectionC.Close();
                if (rowsAffected == 0){
                    throw new Exception("No TasK with the ID provided was found.");
                }   
            }
        }
        public void ChangeStatus(TasK TasK){
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "UPDATE TasK SET status = @STATUS WHERE id = @ID;";
            SQLiteParameter parameterId = new SQLiteParameter("@ID",TasK.Id);
            SQLiteParameter parameterStatus = new SQLiteParameter("@STATUS",TasK.TaskStat);
            
            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);
                commandC.Parameters.Add(parameterStatus);

                int rowsAffected = commandC.ExecuteNonQuery();
                connectionC.Close();
                if (rowsAffected == 0){
                    throw new Exception("No TasK with the ID provided was found.");
                }   
            }
        }
        public void DisableByDeletedBoard(int? idTask){
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            
            string queryC = "UPDATE TasK SET status = @STATUS, id_board = NULL WHERE id = @ID;";
            SQLiteParameter parameterId = new SQLiteParameter("@ID",idTask);
            SQLiteParameter parameterStatus = new SQLiteParameter("@STATUS",6);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);
                commandC.Parameters.Add(parameterStatus);

                int rowAffected =  commandC.ExecuteNonQuery();
                connectionC.Close();
                if (rowAffected == 0){
                    throw new Exception("No TasK with the ID provided was found.");
                }
            }
        }
        public void DisableByDeletedUser(int? idUser){
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            
            string queryAssigned = @"UPDATE TasK SET id_assigned_user = NULL, status = @STATUS
                                   WHERE id_assigned_user = @ID;";

            string queryPropietary = @"UPDATE TasK SET id_propietary_user = NULL, status = @STATUS
                                      WHERE id_propietary_user = @ID;";
            
            SQLiteParameter parameterId = new SQLiteParameter("@ID",idUser);
            SQLiteParameter parameterStatus = new SQLiteParameter("@STATUS",6);

            using (connectionC)
            {
                connectionC.Open();
                
                SQLiteCommand commandA = new SQLiteCommand(queryAssigned,connectionC);
                commandA.Parameters.Add(parameterId);
                commandA.Parameters.Add(parameterStatus);
                
                SQLiteCommand commandP = new SQLiteCommand(queryPropietary,connectionC);
                commandP.Parameters.Add(parameterId);
                commandP.Parameters.Add(parameterStatus);

                int rowAffectedA =  commandA.ExecuteNonQuery();
                int rowAffectedP =  commandP.ExecuteNonQuery();
                connectionC.Close();
                if (rowAffectedA == 0 && rowAffectedP == 0){
                    throw new Exception("No TasK was found for the provided user.");
                }
            }
        }
        
        public List<TasK> GetAllByOwnerUser(int? idUser){
            List<TasK> Tasks = new List<TasK>();

            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            
            string queryC = @"SELECT TasK.id AS TaskId, TasK.id_board, TasK.name, TasK.status, TasK.description, TasK.color, TasK.id_assigned_user, TasK.id_propietary_user, 
                            Board.board_name AS board_name, 
                            AssignedUser.user_name AS assigned_name, 
                            PropietaryUser.user_name AS propietary_name
                            FROM TasK
                            INNER JOIN Board ON Board.id = TasK.id_board
                            LEFT JOIN UseR AS AssignedUser ON AssignedUser.id = TasK.id_assigned_user
                            LEFT JOIN UseR AS PropietaryUser ON PropietaryUser.id = TasK.id_propietary_user
                            WHERE TasK.id_propietary_user = @IDUSER;"; 
                            
            SQLiteParameter parameterIdBoard = new SQLiteParameter("@IDUSER",idUser);

            using(connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterIdBoard);

                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        var newTask = new TasK();
                        newTask.Id = Convert.ToInt32(readerC["TaskId"]);
                        newTask.Name = Convert.ToString(readerC["name"]);
                        newTask.TaskStat = (TaskStat)Convert.ToInt32(readerC["status"]);
                        newTask.Description = Convert.ToString(readerC["description"]);
                        newTask.Color = (Color)Convert.ToInt32(readerC["color"]);
                        newTask.OwnBoard = new Board();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_board"))){
                            newTask.OwnBoard.Id = Convert.ToInt32(readerC["id_board"]);
                            newTask.OwnBoard.Name = Convert.ToString(readerC["board_name"]);
                        }
                        newTask.Assigned = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_assigned_user"))){
                            newTask.Assigned.Id = Convert.ToInt32(readerC["id_assigned_user"]);
                            newTask.Assigned.Name = Convert.ToString(readerC["assigned_name"]);
                        }
                        newTask.Propietary = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_propietary_user"))){
                            newTask.Propietary.Id = Convert.ToInt32(readerC["id_propietary_user"]);
                            newTask.Propietary.Name = Convert.ToString(readerC["propietary_name"]);
                        }
                        Tasks.Add(newTask);
                    }
                }
                connectionC.Close();           
            }
            if (Tasks == null){
                throw new Exception("The UseR provided does not have Tasks.");
            }
            return(Tasks);
        }
        public bool TaskExists(string? TaskName){
            bool validation=false;
            string? Name=null;
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "SELECT * FROM TasK WHERE name = @NAME";
            SQLiteParameter parameterName = new SQLiteParameter("@NAME",TaskName);

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
                        Name = Convert.ToString(readerC["name"]);
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