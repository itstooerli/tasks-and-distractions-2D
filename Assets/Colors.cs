using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Colors : MonoBehaviour
{
    /// <summary>
    /// How often the boxes should change colors
    /// </summary>
    public float rotationInterval = 10;

    /// <summary>
    /// When the box should change colors
    /// </summary>
    public float TimeToChangeRotation = 0;

    /// <summary>
    /// Which direction the colors should rotate
    /// </summary>
    private int rotationDirection;

    /// <summary>
    /// The text to display the rotation direction
    /// </summary>
    private static TMP_Text rotateText;

    /// <summary>
    /// The direction of the last rotation as a string (clockwise/counter-clockwise)
    /// </summary>
    private string lastRotation;

    /// <summary>
    /// Initialize fields
    /// </summary>
    void Start()
    {
        rotateText = GetComponent<TMP_Text>();
        TimeToChangeRotation += rotationInterval;
        lastRotation = "None";
    }

    /// <summary>
    /// Keep the rotation text up to date and update the rotation if needed
    /// </summary>
    void Update()
    {
        if (Time.time > TimeToChangeRotation)
        {
            UpdateRotation();
        }

        rotateText.text = "Last Rotation: " + lastRotation + "\tNext Rotation: " + Mathf.Floor(TimeToChangeRotation - Time.time);

    }

    /// <summary>
    /// Update the rotation of the squares
    /// This randomization currently favors clockwise to avoid the colors moving back and forth
    /// </summary>
    private void UpdateRotation()
    {
        rotationDirection = Random.Range(0, 3);
        
        if (rotationDirection == 0) // counter-clockwise
        {

            // Counter-Clockwise
            // Red -> Blue -> Green -> Yellow ->

            lastRotation = "Counter-Clockwise <";
            foreach (var box in FindObjectsOfType<Task>())
            {
                if (box.tag == "Red")
                {
                    box.GetComponent<SpriteRenderer>().color = Color.blue;
                    box.tag = "Blue";
                }
                else if (box.tag == "Blue")
                {
                    box.GetComponent<SpriteRenderer>().color = Color.green;
                    box.tag = "Green";
                }
                else if (box.tag == "Green")
                {
                    box.GetComponent<SpriteRenderer>().color = Color.yellow;
                    box.tag = "Yellow";
                }
                else if (box.tag == "Yellow")
                {
                    box.GetComponent<SpriteRenderer>().color = Color.red;
                    box.tag = "Red";
                }
            }
        }
        else // clockwise
        {
            // Clockwise
            // Red <- Blue <- Green <- Yellow <-

            lastRotation = "Clockwise >";
            foreach (var box in FindObjectsOfType<Task>())
            {

                if (box.tag == "Red")
                {
                    box.GetComponent<SpriteRenderer>().color = Color.yellow;
                    box.tag = "Yellow";
                }
                else if (box.tag == "Blue")
                {
                    box.GetComponent<SpriteRenderer>().color = Color.red;
                    box.tag = "Red";
                }
                else if (box.tag == "Green")
                {
                    box.GetComponent<SpriteRenderer>().color = Color.blue;
                    box.tag = "Blue";
                }
                else if (box.tag == "Yellow")
                {
                    box.GetComponent<SpriteRenderer>().color = Color.green;
                    box.tag = "Green";
                }
            }
        }

        TimeToChangeRotation += rotationInterval;
    }
}
