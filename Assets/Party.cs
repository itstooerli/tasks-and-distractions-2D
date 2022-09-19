using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    /// <summary>
    /// How much force the Party should apply to the Player
    /// </summary>
    public float attractionFactor = 0.5f;

    /// <summary>
    /// The player
    /// </summary>
    private Player player;

    /// <summary>
    /// The RigidBody of the player
    /// </summary>
    private Rigidbody2D playerRigidBody;

    /// <summary>
    /// The vector direction of the player with respect to the party
    /// </summary>
    private Vector3 playerVector;

    /// <summary>
    /// Initialize objects
    /// </summary>
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerRigidBody = player.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Find the player and pull the player toward this object
    /// </summary>
    private void FixedUpdate()
    {
        playerVector = ((Vector2)transform.position - playerRigidBody.position).normalized;

        /*
        // Inverse Square Logic
        Vector3 force = playerVector * attractionFactor * (1 / Vector2.Distance(transform.position, playerRigidBody.position));
        
        if (force.magnitude < attractionFactor)
        {
            playerRigidBody.AddForce(force);
        }
        */

        Vector3 force = playerVector * attractionFactor;
        playerRigidBody.AddForce(force);

    }
}
