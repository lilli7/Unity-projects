using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public playerControl pc;
  

    public void Start()
    {
       pc = GameObject.FindObjectOfType<playerControl>();
    }
    public void Update()
    {
        //if player dies load save name game scene
        if (pc.hasDied == true)
        {
            EndGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void HowPlay()
    {
        SceneManager.LoadScene(2);
    }

    public void Scores()
    {
        SceneManager.LoadScene(3);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(5);
    }
}
