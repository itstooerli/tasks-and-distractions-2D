using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The prefab for the original colored boxes
    /// </summary>
    public GameObject memoryBoxPrefab;

    /// <summary>
    /// The prefab for the distractions objects
    /// </summary>
    public GameObject distractionPrefab;

    /// <summary>
    ///  The prefab for the party objects
    /// </summary>
    public GameObject PartyPrefab;

    /// <summary>
    /// The total number of Parties that can spawn on screen
    /// </summary>
    public int MaxPartyCount = 4;

    /// <summary>
    /// How often Parties should spawn in game
    /// </summary>
    public float PartyInterval = 15;

    /// <summary>
    /// The time at which a Party should spawn
    /// </summary>
    private float TimeToSpawnParty;

    /// <summary>
    /// The current count of Party objects on screen
    /// </summary>
    private int PartyCount = 0;

    /// <summary>
    ///  Instantiate all colored boxes in the middle of the screen and distractions on the edges of the screen
    /// </summary>
    void Start()
    {

        TimeToSpawnParty = Time.time + PartyInterval;
        // Clockwise Box Number Assignment

        var box1 = Instantiate(memoryBoxPrefab, new Vector2(-2, 2), Quaternion.identity);
        box1.GetComponent<SpriteRenderer>().color = Color.red;
        box1.tag = "Red";

        var box2 = Instantiate(memoryBoxPrefab, new Vector3(2, 2), Quaternion.identity);
        box2.GetComponent<SpriteRenderer>().color = Color.blue;
        box2.tag = "Blue";

        var box3 = Instantiate(memoryBoxPrefab, new Vector3(2, -2), Quaternion.identity);
        box3.GetComponent<SpriteRenderer>().color = Color.green;
        box3.tag = "Green";

        var box4 = Instantiate(memoryBoxPrefab, new Vector3(-2, -2), Quaternion.identity);
        box4.GetComponent<SpriteRenderer>().color = Color.yellow;
        box4.tag = "Yellow";

        var distraction1 = Instantiate(distractionPrefab, new Vector3(-8, 4), Quaternion.identity);
        var distraction2 = Instantiate(distractionPrefab, new Vector3(8, 4), Quaternion.identity);
        var distraction3 = Instantiate(distractionPrefab, new Vector3(8, -4), Quaternion.identity);
        var distraction4 = Instantiate(distractionPrefab, new Vector3(-8, -4), Quaternion.identity);

    }

    /// <summary>
    /// When it's time, create a Party object
    /// </summary>
    void Update()
    {
        if (Time.time > TimeToSpawnParty && PartyCount != MaxPartyCount)
        {
            float x = Random.Range(-4, 4);
            float y = Random.Range(-4, 4);

            Instantiate(PartyPrefab, new Vector3(x, y), Quaternion.identity);

            PartyCount++;
            TimeToSpawnParty += PartyInterval;
        }
    }

    /// <summary>
    /// Allows Goal.cs to reset the party count when destroy Parties
    /// </summary>
    public void ResetPartyCount()
    {
        PartyCount = 0;
    }
}
