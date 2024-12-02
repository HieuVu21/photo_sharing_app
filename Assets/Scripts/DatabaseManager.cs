using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager instance;
    public static DatabaseManager Instance => instance ?? (instance = new GameObject("DatabaseManager").AddComponent<DatabaseManager>());

    private string connectionString;
    private IDbConnection dbConnection;

    void Start()
    {
        string dbPath = Application.persistentDataPath + "/GameScores.sqlite";
        connectionString = "URI=file:" + dbPath;

        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();

            Debug.Log("Database connected: " + dbPath);

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                dbCmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Scores (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Score INTEGER,
                        Time TEXT,
                        Date TEXT
                    )";
                dbCmd.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Database connection error: " + e.Message);
        }
    }


    public void SaveScore(int score)
    {
        try
        {
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                dbCmd.CommandText = @"
                    INSERT INTO Scores (Score, Time, Date) 
                    VALUES (@score, @time, @date)";

                IDbDataParameter paramScore = dbCmd.CreateParameter();
                paramScore.ParameterName = "@score";
                paramScore.Value = score;
                dbCmd.Parameters.Add(paramScore);

                IDbDataParameter paramTime = dbCmd.CreateParameter();
                paramTime.ParameterName = "@time";
                paramTime.Value = DateTime.Now.ToString("HH:mm");
                dbCmd.Parameters.Add(paramTime);

                IDbDataParameter paramDate = dbCmd.CreateParameter();
                paramDate.ParameterName = "@date";
                paramDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                dbCmd.Parameters.Add(paramDate);

                dbCmd.ExecuteNonQuery();
                Debug.Log("Score saved: " + score);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Save score error: " + e.Message);
        }
    }

    // Lấy điểm số cao nhất từ cơ sở dữ liệu
    public List<int> GetTopScores(int count)
    {
        List<int> topScores = new List<int>();

        if (dbConnection == null)
        {
            Debug.LogError("Database connection is null.");
            return topScores;
        }

        try
        {
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                dbCmd.CommandText = "SELECT Score FROM Scores ORDER BY Score DESC LIMIT @count";

                IDbDataParameter paramCount = dbCmd.CreateParameter();
                paramCount.ParameterName = "@count";
                paramCount.Value = count;
                dbCmd.Parameters.Add(paramCount);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        topScores.Add(reader.GetInt32(0));
                    }
                }
            }

            Debug.Log($"Retrieved {topScores.Count} top scores.");
        }
        catch (Exception e)
        {
            Debug.LogError("Get top scores error: " + e.Message);
        }

        return topScores;
    }
    public List<(int score, string time)> GetTopScoresWithTimes( int count)
    {
        List<(int score, string time)> topScoresWithTimes = new List<(int, string)>();

        if (dbConnection == null)
        {
            Debug.LogError("Database connection is null.");
            return topScoresWithTimes;
        }

        try
        {
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                // dbCmd.CommandText = "SELECT Score, Time FROM Score WHERE Difficulty = @difficulty ORDER BY Score desc, Time ASC LIMIT @count";
dbCmd.CommandText = "SELECT Score, Time FROM Scores  ORDER BY Score desc, Time ASC LIMIT @count";
                // IDbDataParameter paramDifficulty = dbCmd.CreateParameter();
                // paramDifficulty.ParameterName = "@difficulty";
                // paramDifficulty.Value = difficulty;
                // // paramDifficulty.Value = "EASY";

                // dbCmd.Parameters.Add(paramDifficulty);



                IDbDataParameter paramCount = dbCmd.CreateParameter();
                paramCount.ParameterName = "@count";
                paramCount.Value = count;
                dbCmd.Parameters.Add(paramCount);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int score = reader.GetInt32(0);
                        string time = reader.GetString(1); // Lấy thời gian
                        topScoresWithTimes.Add((score, time));
                    }
                }
            }

            Debug.Log($"Retrieved {topScoresWithTimes.Count} top scores with times.");
        }
        catch (Exception e)
        {
            Debug.LogError("Get top scores with times error: " + e.Message);
        }

        return topScoresWithTimes;
    }
    public List<(int score, string time)> GetTopScoresByDifficulty(string difficulty, int count)
    {
        List<(int score, string time)> scores = new List<(int, string)>();

        try
        {
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                dbCmd.CommandText = @"
                    SELECT Score, Time FROM Score 
                    WHERE Difficulty = @difficulty 
                    ORDER BY Score DESC LIMIT @count";

                IDbDataParameter paramDifficulty = dbCmd.CreateParameter();
                paramDifficulty.ParameterName = "@difficulty";
                paramDifficulty.Value = difficulty;
                dbCmd.Parameters.Add(paramDifficulty);

                IDbDataParameter paramCount = dbCmd.CreateParameter();
                paramCount.ParameterName = "@count";
                paramCount.Value = count;
                dbCmd.Parameters.Add(paramCount);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        scores.Add((reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Get top scores by difficulty error: " + e.Message);
        }

        return scores;
    }


    // Đóng kết nối cơ sở dữ liệu khi ứng dụng thoát
    void OnApplicationQuit()
    {
        if (dbConnection != null)
        {
            dbConnection.Close();
        }
    }
}