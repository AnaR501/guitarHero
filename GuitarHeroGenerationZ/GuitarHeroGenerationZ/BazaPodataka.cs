using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace GuitarHeroGenerationZ
{
    public class BazaPodataka
    {
        public SQLiteConnection myConn; //napravi bazu ako ne postoji

        public BazaPodataka()
        {
            try
            {
                myConn = new SQLiteConnection("Data Source=GuitarHeroDB.db");
                myConn.Open();

                //string sql2 = "drop table SinglePlayer";
                //SQLiteCommand comm111 = new SQLiteCommand(sql2, myConn);

                //comm111.ExecuteNonQuery();

                string sql = "create table if not exists Song (id integer primary key, Name varchar(50), Duration int, Interval int," +
                    " MaxBrAkorda int, Difficulty varchar(10), BrPreskakanja int)";
                SQLiteCommand comm1 = new SQLiteCommand(sql, myConn);

                comm1.ExecuteNonQuery();

                //ako je tabela prazna, ubacim joj elemente
                sql = "SELECT Name FROM Song";
                SQLiteCommand comm2 = new SQLiteCommand(sql, myConn);

                var tmp = comm2.ExecuteScalar();
                if(tmp == null) //ako ne postoje elementi
                {
                    sql = "INSERT INTO Song (Name, Duration, Interval, MaxBrAkorda, Difficulty, BrPreskakanja) VALUES ('Slow Ride - Foghat', 9000, 16, 287, 'Easy', 0)";
                    SQLiteCommand commInsert1 = new SQLiteCommand(sql, myConn);
                    commInsert1.ExecuteNonQuery();
                    sql = "INSERT INTO Song (Name, Duration, Interval, MaxBrAkorda, Difficulty, BrPreskakanja) VALUES ('Slow Ride - Foghat', 9000, 16, 477, 'Hard', 0)";
                    SQLiteCommand commInsert2 = new SQLiteCommand(sql, myConn);
                    commInsert2.ExecuteNonQuery();
                    sql = "INSERT INTO Song (Name, Duration, Interval, MaxBrAkorda, Difficulty, BrPreskakanja) VALUES ('Radio Song - Superbus', 7500, 15, 319, 'Easy', 6)";
                    SQLiteCommand commInsert3 = new SQLiteCommand(sql, myConn);
                    commInsert3.ExecuteNonQuery();
                    sql = "INSERT INTO Song (Name, Duration, Interval, MaxBrAkorda, Difficulty, BrPreskakanja) VALUES ('Radio Song - Superbus', 7500, 15, 365, 'Hard', 6)";
                    SQLiteCommand commInsert4 = new SQLiteCommand(sql, myConn);
                    commInsert4.ExecuteNonQuery();
                }
                //za brisanje Playera posle debug-ovanja
                //sql = "drop table Players";
                //SQLiteCommand comm123 = new SQLiteCommand(sql, myConn);

                //comm123.ExecuteNonQuery();

                sql = "create table if not exists Player (id integer primary key, Name varchar(50))";
                SQLiteCommand comm3 = new SQLiteCommand(sql, myConn);

                comm3.ExecuteNonQuery();

                sql = "create table if not exists SingleGame (id integer primary key, idP int, idSong int, BrPoena int, ProcenatPogodaka double, Difficulty varchar(10))";
                SQLiteCommand comm4 = new SQLiteCommand(sql, myConn);

                comm4.ExecuteNonQuery();

                sql = "create table if not exists MultiGame (id integer primary key, idP1 int, idP2 int, idSong int, BrPoena1 int, " +
                    "BrPoena2 int, ProcenatPogodaka1 double, ProcenatPogodaka2 double, Difficulty varchar(10))";
                SQLiteCommand comm5 = new SQLiteCommand(sql, myConn);

                comm5.ExecuteNonQuery();

                //ako nije postojala, dodaj joj pocetne vrednosti
                sql = "create table if not exists Keyboard (id integer primary key, Name varchar(50), Key1 int, Key2 int, Key3 int, Key4 int, Key5 int, Strum int, Power int)";
                SQLiteCommand comm6 = new SQLiteCommand(sql, myConn);

                comm6.ExecuteNonQuery();

                sql = "SELECT Name FROM Keyboard";
                SQLiteCommand comm7 = new SQLiteCommand(sql, myConn);

                tmp = comm7.ExecuteScalar();
                if (tmp == null) //ako ne postoje elementi
                {
                    sql = "INSERT INTO Keyboard (Name, Key1, Key2, Key3, Key4, Key5, Strum, Power) VALUES " +
                        $"('Tastatura',  {(int)Keys.A}, {(int)Keys.S}, {(int)Keys.D}, {(int)Keys.F}, {(int)Keys.G}, {(int)Keys.Space}, {(int)Keys.Enter})";
                    SQLiteCommand commInsert1 = new SQLiteCommand(sql, myConn);
                    commInsert1.ExecuteNonQuery();
                    sql = "INSERT INTO Keyboard (Name, Key1, Key2, Key3, Key4, Key5, Strum, Power) VALUES " +
                    $" ('TastaturaPlayer1', {(int)Keys.Q}, {(int)Keys.W}, {(int)Keys.E}, {(int)Keys.R}, {(int)Keys.T}, {(int)Keys.Space}, {(int)Keys.V})";
                    SQLiteCommand commInsert2 = new SQLiteCommand(sql, myConn);
                    commInsert2.ExecuteNonQuery();
                    sql = "INSERT INTO Keyboard (Name, Key1, Key2, Key3, Key4, Key5, Strum, Power) VALUES " +
                    $"('TastaturaPlayer2', {(int)Keys.Y}, {(int)Keys.U}, {(int)Keys.I}, {(int)Keys.O}, {(int)Keys.P}, {(int)Keys.Enter}, {(int)Keys.Back})";
                    SQLiteCommand commInsert3 = new SQLiteCommand(sql, myConn);
                    commInsert3.ExecuteNonQuery();
                }

                sql = "create table if not exists AppData (id integer primary key, DirectionPlayer1 varchar(5), DirectionPlayer2 varchar(5), Volume int)";
                SQLiteCommand comm8 = new SQLiteCommand(sql, myConn);

                comm8.ExecuteNonQuery();

                sql = "SELECT id FROM AppData";
                SQLiteCommand comm9 = new SQLiteCommand(sql, myConn);

                tmp = comm9.ExecuteScalar();
                if (tmp == null) //ako ne postoje elementi
                {
                    sql = $"INSERT INTO AppData (DirectionPlayer1, DirectionPlayer2, Volume) VALUES ('True', 'True', 80)";
                    SQLiteCommand commInsert = new SQLiteCommand(sql, myConn);
                    commInsert.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public List<string> GetSongNames()
        {
            List<string> res = new List<string>();
            try
            {
                myConn.Open();

                string selcom = "SELECT Name FROM Song " +
                    "where Difficulty = 'Easy'";
                SQLiteCommand comm = new SQLiteCommand(selcom, myConn);

                SQLiteDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    res.Add(reader["Name"].ToString());
                }
                    

                reader.Close();
            }
            catch (Exception e)
            {
                //sw.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
            return res;
        }

        public List<string> GetPlayerNames()
        {
            List<string> res = new List<string>();
            try
            {
                myConn.Open();

                string selcom = "SELECT Name FROM Player";
                SQLiteCommand comm = new SQLiteCommand(selcom, myConn);

                SQLiteDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                    res.Add(reader["Name"].ToString());


                reader.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
            return res;
        }

        public List<Player> GetAllPlayers(string difficulty, string song, bool all) //ako je all=true onda vracamo sve, ako nije onda vracamo
                                                                            //samo one sa pesmom song
        {
            List<Player> res = new List<Player>();
            try
            {
                myConn.Open();
                if (all)
                {
                    string selcom = "SELECT p1.Name as name, SUM(game.BrPoena) as ukupnoPoena" +
                        " FROM SingleGame as game" +
                        " inner join Player as p1 on p1.id = game.idP" +
                        " where game.Difficulty = '" + difficulty +
                        "' group by p1.Name" +
                        " order by SUM(game.BrPoena) DESC";

                    SQLiteCommand comm = new SQLiteCommand(selcom, myConn);

                    SQLiteDataReader reader = comm.ExecuteReader();

                    while (reader.Read())
                        res.Add(new Player(reader["name"].ToString(), Convert.ToInt32(reader["ukupnoPoena"]), -1));

                    reader.Close();

                }
                else //izabrana je pesma song
                {
                    string selcom = "SELECT p1.Name as name, game.BrPoena as bp, game.ProcenatPogodaka as pp" +
                        " FROM SingleGame as game " +
                        " inner join Player as p1 on p1.id = game.idP " +
                        " inner join Song as s on s.id = game.idSong " +
                        " where game.Difficulty = '" + difficulty +
                        "' and s.Name = '" + song +
                        "' order by game.BrPoena DESC";
                    SQLiteCommand comm = new SQLiteCommand(selcom, myConn);

                    SQLiteDataReader reader = comm.ExecuteReader();

                    while (reader.Read())
                        res.Add(new Player(reader["name"].ToString(), (int)reader["bp"], Math.Round((double)reader["pp"], 2)));

                    reader.Close();
                }

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
            return res;
        }

        public List<SingleGame> GetSingleGames(string difficulty, string playerName) //selektovan je player
        {
            List<SingleGame> res = new List<SingleGame>();
            try
            {
                myConn.Open();

                string selcom = "SELECT s.Name as song, game.BrPoena as bp1, game.ProcenatPogodaka as pp1" +
                    " FROM SingleGame as game " +
                    "inner join Player as p1 on p1.id = game.idP " +
                    "inner join Song as s on s.id = game.idSong " +
                    "where game.Difficulty = '" + difficulty +
                    "' and p1.Name = '" + playerName + "'";
                SQLiteCommand comm = new SQLiteCommand(selcom, myConn);

                SQLiteDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                    res.Add(new SingleGame(reader["song"].ToString(), (int)reader["bp1"], Math.Round((double)reader["pp1"], 2)));


                reader.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
            return res;
        }

        public List<MultiGame> GetMultiGames(string difficulty, string player1Name, string player2Name)
        {
            List<MultiGame> res = new List<MultiGame>();
            try
            {
                myConn.Open();

                int idPlayer1, idPlayer2;
                string sql = "SELECT id from Player where Name = '" + player1Name + "'";
                SQLiteCommand comm = new SQLiteCommand(sql, myConn);
                var tmp2 = comm.ExecuteScalar();
                idPlayer1 = Convert.ToInt32(tmp2);

                sql = "SELECT id from Player where Name = '" + player2Name + "'";
                SQLiteCommand comm2 = new SQLiteCommand(sql, myConn);
                tmp2 = comm2.ExecuteScalar();
                idPlayer2 = Convert.ToInt32(tmp2);

                sql = "SELECT s.Name as song, game.BrPoena1 as bp1, game.BrPoena2 as bp2," +
                    " game.ProcenatPogodaka1 as pp1, game.ProcenatPogodaka2 as pp2" +
                    " FROM MultiGame as game " +
                    "inner join Song as s on s.id = game.idSong " +
                    "where game.Difficulty = '" + difficulty +
                    "' and game.idP1 = " + idPlayer1 +
                    " and game.idP2 = " + idPlayer2 +
                    " order by game.id DESC";
                SQLiteCommand comm3 = new SQLiteCommand(sql, myConn);

                SQLiteDataReader reader = comm3.ExecuteReader();

                while (reader.Read())
                {
                    int bp1 = (int)reader["bp1"];
                    string ime = reader["song"].ToString();

                    int bp2 = (int)reader["bp2"];
                    double pp1 = Math.Round((double)reader["pp1"], 2);
                    double pp2 = Math.Round((double)reader["pp2"], 2);
                    res.Add(new MultiGame(reader["song"].ToString(), (int)reader["bp1"], (int)reader["bp2"], Math.Round((double)reader["pp1"], 2), Math.Round((double)reader["pp2"], 2)));
                }


                reader.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
            return res;
        }

        public bool DodajPlayera(string player)
        {
            bool res = false; //false znaci da je sve ok, a true je da taj korisnik vec postoji
            try
            {
                myConn.Open();
                //ako korisnik postoji vrati true, ako ne postoji dodaj ga

                string sql = "SELECT Name FROM Player " +
                    " where Player.Name = '" + player + "'";
                SQLiteCommand comm = new SQLiteCommand(sql, myConn);
                var tmp = comm.ExecuteScalar();
                if (tmp == null) //ako ne postoje elementi
                {
                    sql = "INSERT INTO Player (Name) VALUES ('" + player + "')";
                    SQLiteCommand commInsert = new SQLiteCommand(sql, myConn);
                    commInsert.ExecuteNonQuery();
                }
                else
                    res = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
            return res;
        }

        public void PokreniApp()
        {
            //znamo da smo u bazu upisali Tastere, sad ih samo izvlacimo
            try
            {
                myConn.Open();

                string sql = "SELECT Name, Key1, Key2, Key3, Key4, Key5, Strum, Power from Keyboard";

                SQLiteCommand comm = new SQLiteCommand(sql, myConn);

                SQLiteDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    if ((string)reader["Name"] == "Tastatura")
                        TastaturaIKoordinate.PostaviTastaturu((int)reader["Key1"], (int)reader["Key2"], (int)reader["Key3"], (int)reader["Key4"], (int)reader["Key5"], (int)reader["Strum"], (int)reader["Power"]);
                    else if ((string)reader["Name"] == "TastaturaPlayer1")
                        TastaturaIKoordinate.PostaviTastaturuPlayer1((int)reader["Key1"], (int)reader["Key2"], (int)reader["Key3"], (int)reader["Key4"], (int)reader["Key5"], (int)reader["Strum"], (int)reader["Power"]);
                    else if ((string)reader["Name"] == "TastaturaPlayer2")
                        TastaturaIKoordinate.PostaviTastaturuPlayer2((int)reader["Key1"], (int)reader["Key2"], (int)reader["Key3"], (int)reader["Key4"], (int)reader["Key5"], (int)reader["Strum"], (int)reader["Power"]);
                }


                reader.Close();

                sql = "Select DirectionPlayer1, DirectionPlayer2, Volume from AppData";
                SQLiteCommand comm2 = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader2 = comm2.ExecuteReader();

                while (reader2.Read())
                {
                    if (((string)reader2["DirectionPlayer1"]).Equals("True"))
                        TastaturaIKoordinate.smerTastaturePlayer1 = true;
                    else if (((string)reader2["DirectionPlayer1"]).Equals("False"))
                        TastaturaIKoordinate.smerTastaturePlayer1 = false;
                    if(((string)reader2["DirectionPlayer2"]).Equals("True"))
                        TastaturaIKoordinate.smerTastaturePlayer2 = true;
                    else if (((string)reader2["DirectionPlayer2"]).Equals("False"))
                        TastaturaIKoordinate.smerTastaturePlayer2 = false;
                    TastaturaIKoordinate.Volume = (int)reader2["Volume"];
                }
                reader2.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void DodajSingleGame(string player, string songName, int brPoena, double procenatPogodaka, string diff)
        {
            //kada se dodaje ako ta pesma vec postoji onda se updatuje na bolji rezultat, ako ne postoji onda se doda sve
            try
            {
                myConn.Open();
                int idPlayer = -1, idSong;
                string sql = "SELECT id from Player where Name = '" + player + "'";
                SQLiteCommand comm3 = new SQLiteCommand(sql, myConn);



                var tmp2 = comm3.ExecuteScalar();
                if (tmp2 != null)
                    idPlayer = Convert.ToInt32(tmp2);

                sql = "SELECT id from Song where Name = '" + songName + "'";
                SQLiteCommand comm4 = new SQLiteCommand(sql, myConn);
                tmp2 = comm4.ExecuteScalar();
                idSong = Convert.ToInt32(tmp2);


                sql = $"SELECT BrPoena from SingleGame where idP = {idPlayer} and idSong = {idSong} and Difficulty = '{diff}'";

                SQLiteCommand comm = new SQLiteCommand(sql, myConn);

                var tmp = comm.ExecuteScalar();

                if (tmp == null) //ne postoji, treba da insertujemo
                {
                    //da bih insertovala, treba mi idPlayera i idPesme; dohvatam ih pa onda


                    sql = $"INSERT INTO SingleGame (idP, idSong, BrPoena, ProcenatPogodaka, Difficulty) values " +
                        $"({idPlayer}, {idSong}, {brPoena}, {procenatPogodaka}, '{diff}')";
                    SQLiteCommand comm123 = new SQLiteCommand(sql, myConn);
                    comm123.ExecuteNonQuery();
                }
                else if ((int)tmp < brPoena) //vec postoji, treba da Updatujemo bolji rezultat
                {
                    sql = $"update SingleGame set BrPoena = {brPoena}, ProcenatPogodaka = {procenatPogodaka}" +
                        $" where idP = {idPlayer} and idSong = {idSong} and Difficulty = '{diff}'";
                    SQLiteCommand comm1234 = new SQLiteCommand(sql, myConn);
                    comm1234.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void DodajMultiGame(string player1, string player2, string songName, int brPoena1, int brPoena2, double procenatPogodaka1, double procenatPogodaka2, string diff)
        {
            //kada se dodaje ako ta pesma vec postoji onda se updatuje na bolji rezultat, ako ne postoji onda se doda sve
            try
            {
                myConn.Open();
                int idPlayer1, idPlayer2, idSong;
                string sql = "SELECT id from Player where Name = '" + player1 + "'";
                SQLiteCommand comm = new SQLiteCommand(sql, myConn);
                var tmp2 = comm.ExecuteScalar();
                idPlayer1 = Convert.ToInt32(tmp2);

                sql = "SELECT id from Player where Name = '" + player2 + "'";
                SQLiteCommand comm2 = new SQLiteCommand(sql, myConn);
                tmp2 = comm2.ExecuteScalar();
                idPlayer2 = Convert.ToInt32(tmp2);

                sql = "SELECT id from Song where Name = '" + songName + "'";
                SQLiteCommand comm4 = new SQLiteCommand(sql, myConn);
                tmp2 = comm4.ExecuteScalar();
                idSong = Convert.ToInt32(tmp2);


                sql = $"INSERT INTO MultiGame (idP1, idP2, idSong, BrPoena1, BrPoena2, ProcenatPogodaka1, ProcenatPogodaka2, Difficulty) values " +
                    $"({idPlayer1}, {idPlayer2}, {idSong}, {brPoena1}, {brPoena2}, {procenatPogodaka1}, {procenatPogodaka2}, '{diff}')";
                SQLiteCommand comm123 = new SQLiteCommand(sql, myConn);
                comm123.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void ZatvoriApp()
        {
            try
            {
                myConn.Open();

                string sql = "update Keyboard " +
                    " set Key1 = " + TastaturaIKoordinate.Tastatura[0] + ", Key2 = " + TastaturaIKoordinate.Tastatura[1] +
                    ", Key3 = " + TastaturaIKoordinate.Tastatura[2] + ", Key4 = " + TastaturaIKoordinate.Tastatura[3] +
                    ", Key5 = " + TastaturaIKoordinate.Tastatura[4] + ", Strum = " + TastaturaIKoordinate.OkidaciZica[0] +
                    ", Power = " + TastaturaIKoordinate.PowerMode[0] +
                    " where Name = 'Tastatura'";
                SQLiteCommand comm1 = new SQLiteCommand(sql, myConn);
                comm1.ExecuteNonQuery();

                sql = "update Keyboard " +
                    " set Key1 = " + TastaturaIKoordinate.TastaturaPlayer1[0] + ", Key2 = " + TastaturaIKoordinate.TastaturaPlayer1[1] +
                    ", Key3 = " + TastaturaIKoordinate.TastaturaPlayer1[2] + ", Key4 = " + TastaturaIKoordinate.TastaturaPlayer1[3] +
                    ", Key5 = " + TastaturaIKoordinate.TastaturaPlayer1[4] + ", Strum = " + TastaturaIKoordinate.OkidaciZica[1] +
                    ", Power = " + TastaturaIKoordinate.PowerMode[1] +
                    " where Name = 'TastaturaPlayer1'";
                SQLiteCommand comm2 = new SQLiteCommand(sql, myConn);
                comm2.ExecuteNonQuery();

                sql = "update Keyboard " +
                    " set Key1 = " + TastaturaIKoordinate.TastaturaPlayer2[0] + ", Key2 = " + TastaturaIKoordinate.TastaturaPlayer2[1] +
                    ", Key3 = " + TastaturaIKoordinate.TastaturaPlayer2[2] + ", Key4 = " + TastaturaIKoordinate.TastaturaPlayer2[3] +
                    ", Key5 = " + TastaturaIKoordinate.TastaturaPlayer2[4] + ", Strum = " + TastaturaIKoordinate.OkidaciZica[2] +
                    ", Power = " + TastaturaIKoordinate.PowerMode[2] +
                    " where Name = 'TastaturaPlayer2'";
                SQLiteCommand comm3 = new SQLiteCommand(sql, myConn);
                comm3.ExecuteNonQuery();

                sql = "delete from AppData";
                SQLiteCommand comm4 = new SQLiteCommand(sql, myConn);
                comm4.ExecuteNonQuery();

                sql = "insert into AppData (DirectionPlayer1, DirectionPlayer2, Volume) values " +
                    "('" + TastaturaIKoordinate.smerTastaturePlayer1 + "', '" + TastaturaIKoordinate.smerTastaturePlayer2 +
                    "', " + TastaturaIKoordinate.Volume + ")";
                SQLiteCommand comm5 = new SQLiteCommand(sql, myConn);
                comm5.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public Song getSong(string name, string diff)
        {
            int duration = 0, interval = 0, maxBrAkorda = 0, brPresk = 0;
            try
            {
                myConn.Open();
                string sql = "";
                sql = "select Duration, Interval, MaxBrAkorda, BrPreskakanja from Song"
                    + " where Difficulty = '" + diff + "' and " +
                    " Name = '" + name + "'";
                SQLiteCommand comm = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = comm.ExecuteReader();

                while (reader.Read()) //trebalo bi da vrati samo jednu pesmu
                {
                    duration = (int)reader["Duration"];
                    interval = (int)reader["Interval"];
                    maxBrAkorda = (int)reader["MaxBrAkorda"];
                    brPresk = (int)reader["BrPreskakanja"];
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myConn.Close();
            }
            return new Song(name, duration, interval, maxBrAkorda, brPresk);
        }


    }

    public class Player
    {
        public int BrPoena;
        public double ProcenatPogodaka;
        public string Name;

        public Player(string n, int brP, double pp)
        {
            Name = n;
            BrPoena = brP;
            ProcenatPogodaka = pp;
        }
    }

    public class SingleGame
    {
        public string SongName;
        public int brPoena;
        public double procenatPogodaka;

        public SingleGame(string sn, int brP, double pp)
        {
            SongName = sn;
            brPoena = brP;
            procenatPogodaka = pp;
        }
    }

    public class MultiGame
    {
        public string SongName;
        public int brPoena1;
        public int brPoena2;
        public double procenatPogodaka1;
        public double procenatPogodaka2;

        public MultiGame(string sn, int brP1, int brP2, double pp1, double pp2)
        {
            SongName = sn;
            brPoena1 = brP1;
            brPoena2 = brP2;
            procenatPogodaka1 = pp1;
            procenatPogodaka2 = pp2;
        }
    }





}
