using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    /// <summary>
    /// The player object
    /// </summary>
    private Player player;

    /// <summary>
    /// Find the player object
    /// </summary>
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    /// <summary>
    /// This Collider is set as a Trigger
    /// When the player is on this box, find the color and send it to the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            player.UpdateCurrentBoxLocation(tag);
        }
    }

    /// <summary>
    /// When the player leaves the box, resest their box location back to None
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            player.UpdateCurrentBoxLocation("None");
        }
    }

}
