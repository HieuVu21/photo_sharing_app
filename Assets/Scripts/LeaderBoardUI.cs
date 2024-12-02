// // using System.Collections.Generic;
// // using UnityEngine;
// // using UnityEngine.UI;
// // using TMPro; // Use if you are using TextMeshPro for text elements

// // public class LeaderBoardUI : MonoBehaviour
// // {
// //     private DatabaseManager databaseManager;
// //     public GameObject leaderboardPanel; // Assign the LeaderboardPanel GameObject
// //     public GameObject scoreTemplate; // Assign the ScoreTemplate GameObject in Inspector
// //     public Transform scoreListContainer; // Assign the ScoreListContainer in Inspector

// //     private GameData gameData;

// //     private void Start()
// //     {
// //         LoadGameData();
// //          databaseManager = DatabaseManager.Instance;
// //     }
// //     public void ShowRanking(){
// //         leaderboardPanel.SetActive(true); 
// //         // DisplayScore();

// //     }
// //     public void ShowLeaderboard(int val)
// //     {
// //         if (val == 0)
// //         {
// //             Debug.Log(val);
// //             DisplayScores("EASY");
// //         }
// //         else if (val == 1)
// //         {
// //             Debug.Log(val);
// //             DisplayScores("MEDIUM");
// //         }
// //         else if (val == 2)
// //         {
// //             Debug.Log(val);
// //             DisplayScores("HARD");
// //         }
// //     }

// //     public void HideLeaderboard()
// //     {
// //         leaderboardPanel.SetActive(false); 
// //         // ClearScores();
// //     }

// //     private void LoadGameData()
// //     {

// //         string saveLocation = Application.persistentDataPath + "/gameData.json";
// //         if (System.IO.File.Exists(saveLocation))
// //         {
// //             string dataString = System.IO.File.ReadAllText(saveLocation);
// //             gameData = JsonUtility.FromJson<GameData>(dataString);
// //         }
// //         else
// //         {
// //             gameData = new GameData();
// //         }
// //     }

// // private void DisplayScores(string difficulty)
// // {
// //     var topScoresWithTimes = databaseManager.GetTopScoresByDifficulty(difficulty,5); // Lấy cả điểm số và thời gian

// //     for (int i = 0; i < Mathf.Min(5, topScoresWithTimes.Count); i++)
// //     {
// //         GameObject scoreEntry = Instantiate(scoreTemplate, scoreListContainer);
// //         scoreEntry.SetActive(true); 

// //         // Thiết lập văn bản điểm số và thời gian
// //         TextMeshPro scoreText = scoreEntry.GetComponent<TextMeshPro>();
// //         if (scoreText != null)
// //         {
// //             // Định dạng hiển thị như "1. điểm + thời gian"
// //             scoreText.text = $"{i + 1}. {topScoresWithTimes[i].score}  {topScoresWithTimes[i].time}";
// //         }
// //         else
// //         {
// //             // Sử dụng TextMeshPro nếu bạn đang sử dụng TextMeshPro
// //             TextMeshProUGUI scoreTMP = scoreEntry.GetComponent<TextMeshProUGUI>();
// //             if (scoreTMP != null)
// //             {
// //                 scoreTMP.text = $"{i + 1}. {topScoresWithTimes[i].score} + {topScoresWithTimes[i].time}";
// //             }
// //         }
// //     }
// // }
// // // private void DisplayScore()
// // // {
// // //     var topScoresWithTimes = databaseManager.GetTopScoresWithTimes(5); // Lấy cả điểm số và thời gian

// // //     for (int i = 0; i < Mathf.Min(5, topScoresWithTimes.Count); i++)
// // //     {
// // //         GameObject scoreEntry = Instantiate(scoreTemplate, scoreListContainer);
// // //         scoreEntry.SetActive(true); 

// // //         // Thiết lập văn bản điểm số và thời gian
// // //         Text scoreText = scoreEntry.GetComponent<Text>();
// // //         if (scoreText != null)
// // //         {
// // //             // Định dạng hiển thị như "1. điểm + thời gian"
// // //             scoreText.text = $"{i + 1}. {topScoresWithTimes[i].score}  {topScoresWithTimes[i].time}";
// // //         }
// // //         else
// // //         {
// // //             // Sử dụng TextMeshPro nếu bạn đang sử dụng TextMeshPro
// // //             TextMeshProUGUI scoreTMP = scoreEntry.GetComponent<TextMeshProUGUI>();
// // //             if (scoreTMP != null)
// // //             {
// // //                 scoreTMP.text = $"{i + 1}. {topScoresWithTimes[i].score} + {topScoresWithTimes[i].time}";
// // //             }
// // //         }
// // //     }
// // // }
// // private void DisplayScore()
// // {
// //     // ClearScores();

// //     List<int> topScores = databaseManager.GetTopScores(5);
// //     if (topScores == null || topScores.Count == 0)
// //     {
// //         Debug.LogWarning("No scores retrieved from the database.");
// //         return;
// //     }

// //     for (int i = 0; i < topScores.Count; i++)
// //     {
// //         GameObject scoreEntry = Instantiate(scoreTemplate, scoreListContainer);
// //         scoreEntry.SetActive(true);

// //         Text textComponent = scoreEntry.GetComponent<Text>();
// //         TextMeshProUGUI tmpComponent = scoreEntry.GetComponent<TextMeshProUGUI>();

// //         string scoreDisplayText = $"{i + 1}. {topScores[i]}";

// //         if (textComponent != null)
// //         {
// //             textComponent.text = scoreDisplayText;
// //         }
// //         else if (tmpComponent != null)
// //         {
// //             tmpComponent.text = scoreDisplayText;
// //         }
// //         else
// //         {
// //             Debug.LogError("Score entry template does not have a Text or TextMeshProUGUI component.");
// //         }
// //     }
// // }



// // }
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class LeaderBoardUI : MonoBehaviour
// {
//     private DatabaseManager databaseManager;
//     public GameObject leaderboardPanel; // Assign the LeaderboardPanel GameObject
//     public GameObject scoreTemplate; // Assign the ScoreTemplate GameObject in Inspector
//     public Transform scoreListContainer; // Assign the ScoreListContainer in Inspector

//     private GameData gameData;

//     private void Start()
//     {
//         databaseManager = DatabaseManager.Instance;
//     }
//     public void Temp()
//     {
//         leaderboardPanel.SetActive(true);
//         DisplayScores("EASY");

//     }
//     public void ShowLeaderboard(int val)
//     {
//         if (val == 0)
//         {
//             Debug.Log(val);
//             DisplayScores("EASY");
//         }
//         else if (val == 1)
//         {
//             Debug.Log(val);
//             DisplayScores("MEDIUM");
//         }
//         else if (val == 2)
//         {
//             Debug.Log(val);
//             DisplayScores("HARD");
//         }
//     }

//     public void HideLeaderboard()
//     {
//         leaderboardPanel.SetActive(false);
//         ClearScores();
//     }

//     private void ClearScores()
//     {
//         foreach (Transform child in scoreListContainer)
//         {
//             Destroy(child.gameObject);
//             // child.gameObject.SetActive(false);
//             // child.SetParent(null);
//         }
//     }

//     // public void DisplayScores(string difficulty)
//     // {
//     //     // ClearScores();

//     //     var topScoresWithTimes = databaseManager.GetTopScoresByDifficulty(difficulty, 5);

//     //       for (int i = 0; i < Mathf.Min(5, topScoresWithTimes.Count); i++)
//     // {
//     //     GameObject scoreEntry = Instantiate(scoreTemplate, scoreListContainer);
//     //     scoreEntry.SetActive(true); 

//     //     // Thiết lập văn bản điểm số và thời gian
//     //     TextMeshPro scoreText = scoreEntry.GetComponent<TextMeshPro>();
//     //     if (scoreText != null)
//     //     {
//     //         // Định dạng hiển thị như "1. điểm + thời gian"
//     //         scoreText.text = $"{i + 1}. {topScoresWithTimes[i].score}  {topScoresWithTimes[i].time}";
//     //     }
//     //     else
//     //     {
//     //         // Sử dụng TextMeshPro nếu bạn đang sử dụng TextMeshPro
//     //         TextMeshProUGUI scoreTMP = scoreEntry.GetComponent<TextMeshProUGUI>();
//     //         if (scoreTMP != null)
//     //         {
//     //             scoreTMP.text = $"{i + 1}. {topScoresWithTimes[i].score} + {topScoresWithTimes[i].time}";
//     //         }
//     //     }
//     // }
//     // }
//     private void DisplayScores(string difficulty)
// {
   

//      List<(int score, string time)> topScores = databaseManager.GetTopScoresByDifficulty(difficulty,5);
//     if (topScores == null || topScores.Count == 0)
//     {
//         Debug.LogWarning("No scores retrieved from the database.");
//         return;
//     }

//     for (int i = 0; i < topScores.Count; i++)
//     {
//         GameObject scoreEntry = Instantiate(scoreTemplate, scoreListContainer);
//         scoreEntry.SetActive(true);

//         Text textComponent = scoreEntry.GetComponent<Text>();
//         TextMeshProUGUI tmpComponent = scoreEntry.GetComponent<TextMeshProUGUI>();

//         string scoreDisplayText = $"{i + 1}. {topScores[i]}";

//         if (textComponent != null)
//         {
//             textComponent.text = scoreDisplayText;
//         }
//         else if (tmpComponent != null)
//         {
//             tmpComponent.text = scoreDisplayText;
//         }
//         else
//         {
//             Debug.LogError("Score entry template does not have a Text or TextMeshProUGUI component.");
//         }
//     }
//      ClearScores();
// }

// }
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderBoardUI : MonoBehaviour
{
    private DatabaseManager databaseManager;
    public GameObject leaderboardPanel; // Assign the LeaderboardPanel GameObject
    public GameObject scoreTemplate; // Assign the ScoreTemplate GameObject in Inspector
    public Transform scoreListContainer; // Assign the ScoreListContainer in Inspector

    private Dictionary<string, List<GameObject>> scoreEntriesCache = new Dictionary<string, List<GameObject>>();
    private string currentDifficulty = null;

    private void Start()
    {
        databaseManager = DatabaseManager.Instance;
    }
    public void ShowRanking(){
        leaderboardPanel.SetActive(true);
        // DisplayScores("EASY");
    }

    public void ShowLeaderboard(int val)
    {
        string difficulty = val switch
        {
            0 => null,
            1 => "EASY",
            2 => "MEDIUM",
            3 => "HARD",
            _ => null
        };

        if (difficulty != null)
        {
            if (currentDifficulty != null)
            {
                HideScores(currentDifficulty);
            }

            DisplayScores(difficulty);
            currentDifficulty = difficulty;
        }
    }

    public void HideLeaderboard()
    {
        leaderboardPanel.SetActive(false);
        if (currentDifficulty != null)
        {
            HideScores(currentDifficulty);
            currentDifficulty = null;
        }
    }

    private void HideScores(string difficulty)
    {
        if (scoreEntriesCache.ContainsKey(difficulty))
        {
            foreach (var entry in scoreEntriesCache[difficulty])
            {
                entry.SetActive(false);
            }
        }
    }

    private void DisplayScores(string difficulty)
    {
        // leaderboardPanel.SetActive(true);

        // If scores are already cached, simply activate them
        if (scoreEntriesCache.ContainsKey(difficulty))
        {
            foreach (var entry in scoreEntriesCache[difficulty])
            {
                entry.SetActive(true);
            }
            return;
        }

        // Fetch scores from the database and create new entries
        List<(int score, string time)> topScores = databaseManager.GetTopScoresByDifficulty(difficulty, 5);
        if (topScores == null || topScores.Count == 0)
        {
            Debug.LogWarning("No scores retrieved from the database.");
            return;
        }

        List<GameObject> newEntries = new List<GameObject>();
        for (int i = 0; i < topScores.Count; i++)
        {
            GameObject scoreEntry = Instantiate(scoreTemplate, scoreListContainer);
            scoreEntry.SetActive(true);

            Text textComponent = scoreEntry.GetComponent<Text>();
            TextMeshProUGUI tmpComponent = scoreEntry.GetComponent<TextMeshProUGUI>();

            string scoreDisplayText = $"{i + 1}. {topScores[i].score} ({topScores[i].time})";

            if (textComponent != null)
            {
                textComponent.text = scoreDisplayText;
            }
            else if (tmpComponent != null)
            {
                tmpComponent.text = scoreDisplayText;
            }
            else
            {
                Debug.LogError("Score entry template does not have a Text or TextMeshProUGUI component.");
            }

            newEntries.Add(scoreEntry);
        }

        // Cache the new entries
        scoreEntriesCache[difficulty] = newEntries;
    }
}

