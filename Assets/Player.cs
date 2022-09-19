using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// How quickly the player can move when pressing key
    /// </summary>
    public float PlayerVelocity = 5;

    /// <summary>
    /// The RigidBody for this player
    /// </summary>
    private Rigidbody2D rigidBody;

    /// <summary>
    /// Keep track of whether this player is in a Task area
    /// </summary>
    private string CurrentBoxLocation = "None";

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Move the player
    /// </summary>
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 force = new Vector2(x, y) * PlayerVelocity;
        rigidBody.AddForce(force);

    }

    /// <summary>
    /// Update the current box location, whether in a color or None
    /// </summary>
    /// <param name="BoxColor"></param>
    public void UpdateCurrentBoxLocation(string BoxColor)
    {
        CurrentBoxLocation = BoxColor;
    }

    /// <summary>
    /// Give the current box location
    /// </summary>
    /// <returns></returns>
    public string GetCurrentBoxLocation()
    {
        return CurrentBoxLocation;
    }

}
