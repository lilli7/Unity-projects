using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*[SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private float timeElapsed;

    private void Start()
    {
        SceneManager.LoadScene(4);
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(0);
        }
    }*/
    public void EndGame()
    {
        Debug.Log("GAME OVER");
    }
}
