using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Text;


public class PlayerData
{
    public string PlayerName { get; set; }
    public int Score { get; set; }

    public override string ToString()
    {
        return PlayerName + "              " + Score + "\n";
    }
}

public class ScoreManager : MonoBehaviour
{
    //variable to create points
    public int points;
    public string playerName;
    public Text scoreText;
    public bool gameActive = true;
    
    
    List<PlayerData> players = new List<PlayerData>();

    public InputField inputField;

    public Text highScoreText;

    private void Start()
    {
        loadPlayer();
        DisplayScore(players);
    }
    private void Update()
    {
        if (gameActive == true)
        {
            IncreaseScore(1);
            scoreText.text = "Score: " + points;
        }
            savePlayer();
       

    }
    //L: function to increase score
    public void IncreaseScore(int amount)
    {
        points += amount;
    }


    public void savePlayer()
    {
        playerName = inputField.text;

        Debug.Log(playerName);

        try
        {
            string path = Application.dataPath + "/scores.txt";

            string player = playerName + "," + points;
            //sw.Close();
            File.AppendAllText(path, player + System.Environment.NewLine);
 
                
                Debug.Log(name);
                Debug.Log(points);
                Debug.Log("successfully saved.");

            Debug.Log("successfully saved.");
            
        }
        catch(IOException e)
        {
            Debug.Log(e.Message);
        }

    }

    public void loadPlayer()
    {

        //REFERENCE: https://www.youtube.com/watch?v=lJ9nArexsfA&ab_channel=CodeMonkey
        //at 1:52
        /* if(PlayerPrefs.HasKey("PlayerPositionX"))
         {
             float PlayerPosX = PlayerPrefs.GetFloat("PlayerPositionX");
             float PlayerPosY = PlayerPrefs.GetFloat("PlayerPositionY");
             Vector3 playerPos = new Vextor3(PlayerPosX, PlayerPosY);
             int score = PlayerPrefs.GetInt()
             Debug.Log("Loaded");

         }*/
        
        try
        {

            string path = Application.dataPath + "/scores.txt";
           // string data = File.ReadAllText(path);

            //Debug.Log(data);

            //testing purposes only
            foreach(string line in System.IO.File.ReadLines(@"C:\Users\cupca\Downloads\proj 2 sol v2.4.3\proj 2 sol v2.4.3\Assets\scores.txt"))
            {
                Debug.Log(line);
                string[] values = line.Split(',');
                players.Add(new PlayerData() { PlayerName = values[0], Score = int.Parse(values[1]) });
            }
            System.Console.ReadLine();


            //string name;
            // int score;
            Debug.Log(players);
               
                players.Sort(delegate(PlayerData x, PlayerData y) { return y.Score.CompareTo(x.Score); });

            Debug.Log("successfully loaded.");
        }
        catch (IOException e)
        {
            Debug.Log(e.Message);
        }

        
    }
    void DisplayScore(List<PlayerData> players)
        {
        highScoreText.text= string.Join(System.Environment.NewLine, players);
        Debug.Log("displayed");
        }

    
}
