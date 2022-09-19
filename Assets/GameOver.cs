using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    /// <summary>
    /// Text component for the Game Over text
    /// </summary>
    private static TMP_Text GameOverText;

    /// <summary>
    /// Set the game text and puase the time scale for the game
    /// </summary>
    void Start()
    {
        GameOverText = GetComponent<TMP_Text>();
        GameOverText.text = "Congratulations!" + "\nYou were able to dodge all of those distractions and focus on the task at hand." + 
            "\n\nI hope you stay happy and healthy no matter what life throws at you. Whatever you got from the game, you deserve those breaks sometimes.\n\n"+ "Press Space Bar to Play Again";
        Time.timeScale = 0.0f;
    }

    /// <summary>
    /// Allow player to reload the game and restart the time scale
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Main Level");
            Time.timeScale = 1.0f;
        }
    }
}
