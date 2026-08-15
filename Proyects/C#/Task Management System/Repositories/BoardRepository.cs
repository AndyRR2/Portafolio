using System.Data.SQLite;

using Proyect.Models;

namespace Proyect.Repositories{
    public class BoardRepository: IBoardRepository{
        private readonly string ruteBD;
        private readonly ITaskRepository repoTask;
        public BoardRepository(string conectionString, ITaskRepository TaskRepo)
        {
            ruteBD = conectionString;
            repoTask = TaskRepo;
        }
        public List<Board> GetAll(){
            List<Board> boards = new List<Board>();
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = @"SELECT Board.id AS BoardId, id_propietary_user, board_name, UseR.user_name AS propietary_name, description, status 
    	                    FROM Board
                            LEFT JOIN UseR ON Board.id_propietary_user = UseR.id;";
            using(connectionC){
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                
                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        Board boardToAdd = new Board();
                        boardToAdd.Id = Convert.ToInt32(readerC["BoardId"]);
                        boardToAdd.Propietary = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_propietary_user"))){
                            boardToAdd.Propietary.Id = Convert.ToInt32(readerC["id_propietary_user"]);
                            boardToAdd.Propietary.Name = Convert.ToString(readerC["propietary_name"]);
                        }
                        boardToAdd.Name = Convert.ToString(readerC["board_name"]);
                        boardToAdd.Description = Convert.ToString(readerC["description"]);
                        boardToAdd.BoardStatus = (BoardStatus)Convert.ToInt32(readerC["status"]);
                        boards.Add(boardToAdd);
                    }   
                }
                connectionC.Close();
            }
            if (boards==null){
                throw new Exception("Were not found boards in the data base.");
            }
            return(boards);
        }
        public List<Board> GetAllByOwnerUser(int? idUser){
            List<Board> boards = new List<Board>();
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = @"SELECT Board.id AS BoardId, id_propietary_user, board_name, UseR.user_name AS propietary_name, description, status 
                            FROM Board
    	                    INNER JOIN UseR ON Board.id_propietary_user = UseR.id
                            WHERE Board.id_propietary_user = @ID;";

            SQLiteParameter parameterId = new SQLiteParameter("@ID",idUser);
            
            using(connectionC){
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);
                
                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        Board boardToAdd = new Board();
                        boardToAdd.Id = Convert.ToInt32(readerC["BoardId"]);
                        boardToAdd.Propietary = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_propietary_user"))){
                            boardToAdd.Propietary.Id = Convert.ToInt32(readerC["id_propietary_user"]);
                            boardToAdd.Propietary.Name = Convert.ToString(readerC["propietary_name"]);
                        }
                        boardToAdd.Name = Convert.ToString(readerC["board_name"]);
                        boardToAdd.Description = Convert.ToString(readerC["description"]);
                        boardToAdd.BoardStatus = (BoardStatus)Convert.ToInt32(readerC["status"]);
                        boards.Add(boardToAdd);
                    }   
                }
                connectionC.Close();
            }
            if (boards==null){
                throw new Exception("Were not found boards in the data base.");
            }
            return(boards);
        }
        public List<Board> GetAllByAsignedTask(int? idUser){
            List<Board> boards = new List<Board>();
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = @"SELECT Board.id AS BoardId, Board.id_propietary_user, Board.board_name, UseR.user_name AS propietary_name, Board.description, Board.status 
                            FROM Board
                            LEFT JOIN TasK ON Board.id = TasK.id_board  
                            LEFT JOIN UseR ON Board.id_propietary_user = UseR.id
                            WHERE TasK.id_assigned_user = @ID
                            GROUP BY Board.id";
            SQLiteParameter parameterId = new SQLiteParameter("@ID",idUser);

            using(connectionC){
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);

                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        Board boardToAdd = new Board();
                        boardToAdd.Id = Convert.ToInt32(readerC["BoardId"]);
                        boardToAdd.Propietary = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_propietary_user"))){
                            boardToAdd.Propietary.Id = Convert.ToInt32(readerC["id_propietary_user"]);
                            boardToAdd.Propietary.Name = Convert.ToString(readerC["propietary_name"]);
                        }
                        boardToAdd.Name = Convert.ToString(readerC["board_name"]);
                        boardToAdd.Description = Convert.ToString(readerC["description"]);
                        boardToAdd.BoardStatus = (BoardStatus)Convert.ToInt32(readerC["status"]);
                        boards.Add(boardToAdd);
                    }   
                }
                connectionC.Close();
            }
            if (boards==null){
                throw new Exception("Were not found boards in the data base.");
            }
            return(boards);
        }
        public Board GetById(int? Id){
            Board boardSelected = new Board();
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            
            string queryC = @"SELECT Board.id AS BoardId, id_propietary_user, board_name, UseR.user_name AS propietary_name, description, status 
                            FROM Board
    	                    LEFT JOIN UseR ON Board.id_propietary_user = UseR.id
                            WHERE BoardId = @ID;";
            
            SQLiteParameter parameterId = new SQLiteParameter("@ID",Id);
            
            using(connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);

                SQLiteDataReader readerC = commandC.ExecuteReader();
                using (readerC)
                {
                    while (readerC.Read())
                    {
                        boardSelected.Id = Convert.ToInt32(readerC["BoardId"]);
                        boardSelected.Propietary = new UseR();
                        if (!readerC.IsDBNull(readerC.GetOrdinal("id_propietary_user"))){
                            boardSelected.Propietary.Id = Convert.ToInt32(readerC["id_propietary_user"]);
                            boardSelected.Propietary.Name = Convert.ToString(readerC["propietary_name"]);
                        }
                        boardSelected.Name = Convert.ToString(readerC["board_name"]);
                        boardSelected.Description = Convert.ToString(readerC["description"]);
                        boardSelected.BoardStatus = (BoardStatus)Convert.ToInt32(readerC["status"]);
                    }
                }
                connectionC.Close();
            }
            if (boardSelected==null){
                throw new Exception("Is not found board with the id provided in the database.");
            }
            return(boardSelected);
        }

        public void Create(Board newBoard){
            if (BoardExists(newBoard.Name))
            {
                throw new Exception("The Board already exists.");
            }
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = $"INSERT INTO Board (id_propietary_user,board_name,description,status) VALUES(@IDUSER,@NAME,@DESCRIPTION,@STATUS)";
            SQLiteParameter parameterIdUser = new SQLiteParameter("@IDUSER",newBoard.Propietary.Id);
            SQLiteParameter parameterName = new SQLiteParameter("@NAME",newBoard.Name);
            SQLiteParameter parameterDescription = new SQLiteParameter("@DESCRIPTION",newBoard.Description);
            SQLiteParameter parameterStatus = new SQLiteParameter("@STATUS",newBoard.BoardStatus);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterIdUser);
                commandC.Parameters.Add(parameterName);
                commandC.Parameters.Add(parameterDescription);
                commandC.Parameters.Add(parameterStatus);
                commandC.ExecuteNonQuery();
                connectionC.Close();
            }
            if (newBoard==null){
                throw new Exception("The Board was not created correctly.");
            }
        }
        public void Update(Board newBoard){
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            
            string queryC = "UPDATE Board SET id_propietary_user = @IDUSER, board_name = @NAME, description = @DESCRIPTION, status = @STATUS WHERE id = @ID;";
            SQLiteParameter parameterId = new SQLiteParameter("@ID",newBoard.Id);
            SQLiteParameter parameterIdUser = new SQLiteParameter("@IDUSER",newBoard.Propietary.Id);
            SQLiteParameter parameterName = new SQLiteParameter("@NAME",newBoard.Name);
            SQLiteParameter parameterDescription = new SQLiteParameter("@DESCRIPTION",newBoard.Description);
            SQLiteParameter parameterStatus = new SQLiteParameter("@STATUS",newBoard.BoardStatus);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);
                commandC.Parameters.Add(parameterIdUser);
                commandC.Parameters.Add(parameterName);
                commandC.Parameters.Add(parameterDescription);
                commandC.Parameters.Add(parameterStatus);

                int rowAffected =  commandC.ExecuteNonQuery();
                connectionC.Close();
                if (rowAffected == 0){
                    throw new Exception("Not Found board with the ID provided.");
                }
            }
        }
        public void Remove(int? idBoard){
            foreach (var TasK in repoTask.GetAllByOwnerBoard(idBoard))//disable all user boards to delete
            {
                repoTask.DisableByDeletedBoard(TasK.Id);
            }

            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "DELETE FROM Board WHERE id = @ID";
            SQLiteParameter parameterId = new SQLiteParameter("@ID",idBoard);

            using(connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);

                int rowAffected =  commandC.ExecuteNonQuery();
                connectionC.Close();
                if (rowAffected == 0){
                    throw new Exception("Not Found board with the ID provided.");
                }
            }
        }
        public void Disable(int? idBoard){

            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);
            
            string queryC = @"UPDATE Board SET status = @STATUS, id_propietary_user = NULL WHERE id = @ID;
                            UPDATE TasK SET status = @STATUST WHERE id_board = @ID;";

            SQLiteParameter parameterId = new SQLiteParameter("@ID",idBoard);
            SQLiteParameter parameterStatus = new SQLiteParameter("@STATUS",2);
            SQLiteParameter parameterStatusT = new SQLiteParameter("@STATUST",6);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterId);
                commandC.Parameters.Add(parameterStatus);
                commandC.Parameters.Add(parameterStatusT);

                int rowAffected =  commandC.ExecuteNonQuery();
                connectionC.Close();
                if (rowAffected == 0){
                    throw new Exception("Not Found board with the ID provided.");
                }
            }
        }
        
        public bool ChechAsignedTask(int? idBoard, int? idUser){
            bool validation = false;
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "SELECT * FROM TasK WHERE id_assigned_user = @IDASIGN OR id_board = @IDBOARD";
            SQLiteParameter parameterIdAsign = new SQLiteParameter("@IDASIGN", idUser);
            SQLiteParameter parameterIdBoard = new SQLiteParameter("@IDBOARD", idBoard);

            using (connectionC)
            {
                connectionC.Open();
                SQLiteCommand commandC = new SQLiteCommand(queryC,connectionC);
                commandC.Parameters.Add(parameterIdAsign);
                commandC.Parameters.Add(parameterIdBoard);

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
        
        public bool BoardExists(string? boardName){
            bool validation=false;
            string? Name=null;
            SQLiteConnection connectionC = new SQLiteConnection(ruteBD);

            string queryC = "SELECT * FROM Board WHERE board_name = @NAME";
            SQLiteParameter parameterName = new SQLiteParameter("@NAME",boardName);

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
                        Name = Convert.ToString(readerC["board_name"]);
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