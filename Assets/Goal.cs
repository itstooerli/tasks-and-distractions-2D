using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    /// <summary>
    /// At what point should a Distraction be destroyed
    /// </summary>
    public int TallyGoal = 2;

    /// <summary>
    /// The audio for scoring a point
    /// </summary>
    public AudioClip positiveAudio;

    /// <summary>
    /// The audio for losing a point
    /// </summary>
    public AudioClip negativeAudio;

    /// <summary>
    /// The AudioSource for this object
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// The player's current score
    /// </summary>
    private int CurrentTally = 0;

    /// <summary>
    /// How often the goal color should change
    /// </summary>
    private float GoalChangeInterval = 10;

    /// <summary>
    /// When the goal color should change
    /// </summary>
    private float TimeToChangeGoal;

    /// <summary>
    /// A string array of the possible colors
    /// </summary>
    private string[] goalColors = new string[] { "Red", "Blue", "Green", "Yellow" };

    /// <summary>
    /// The index in goalColors that should be displayed
    /// </summary>
    private int colorChoice;

    /// <summary>
    /// The current color choice as a string
    /// </summary>
    private string currentColorString = "None";

    /// <summary>
    /// The text field of this object
    /// </summary>
    private static TMP_Text goalText;

    /// <summary>
    /// The player
    /// </summary>
    private Player player;

    /// <summary>
    /// The GameManager
    /// </summary>
    private GameManager gm;

    /// <summary>
    /// The player's current box location
    /// </summary>
    private string currentPlayerString;

    /// <summary>
    /// All of the existing directions
    /// </summary>
    private Distractions[] allDistractions;

    /// <summary>
    /// Initialize objects
    /// </summary>
    void Start()
    {
        player = FindObjectOfType<Player>();
        gm = FindObjectOfType<GameManager>();
        goalText = GetComponent<TMP_Text>();
        audioSource = GetComponent<AudioSource>();
        TimeToChangeGoal = Time.time + 5;
    }

    /// <summary>
    /// Keep the goalText up to date
    /// When time is ready, update the tally and goal
    /// </summary>
    void Update()
    {
        if (Time.time > TimeToChangeGoal)
        {
            UpdateTally();
            UpdateGoal();

        }

        goalText.text = "Current Goal " + "(" + CurrentTally.ToString() + "/" + TallyGoal.ToString() + "): " 
            + currentColorString + " in " + Mathf.Floor(TimeToChangeGoal - Time.time);
    }

    /// <summary>
    /// Update the player's score as appropriate or end the game when no more distractions
    /// Destroy all existing Parties if one (1) away from Tally Goal
    /// </summary>
    private void UpdateTally()
    {
        currentPlayerString = player.GetCurrentBoxLocation();
        if (currentPlayerString != "None")
        {
            if (currentPlayerString == currentColorString)
            {
                audioSource.PlayOneShot(positiveAudio);
                CurrentTally += 1;

                if (CurrentTally == TallyGoal)
                {
                    allDistractions = FindObjectsOfType<Distractions>();

                    if (allDistractions.Length != 0)
                    {
                        allDistractions[0].Boom();
                    }
                    else
                    {
                        SceneManager.LoadScene("Game Over");
                    }

                    CurrentTally = 0;
                }
                else if (CurrentTally == TallyGoal - 1)
                {
                    foreach (var partay in FindObjectsOfType<Party>())
                    {
                        Destroy(partay.gameObject);
                        gm.ResetPartyCount();
                    }
                }
            }
            else
            {
                audioSource.PlayOneShot(negativeAudio);
                CurrentTally -= 1;
            }
        }
    }

    /// <summary>
    /// Update the next goal color
    /// </summary>
    private void UpdateGoal()
    {
        colorChoice = Random.Range(0, 4);
        currentColorString = goalColors[colorChoice];
        TimeToChangeGoal += GoalChangeInterval;
    }
}
