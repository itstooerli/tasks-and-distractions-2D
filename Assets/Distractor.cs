using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractor : MonoBehaviour
{
    /// <summary>
    /// When the distractor should destroy itself
    /// </summary>
    public float TimeToMeltAway = 8;

    /// <summary>
    /// The audio that should play when colliding with the player
    /// </summary>
    public AudioClip collisionAudio;

    /// <summary>
    /// AudioSource for this object
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// When this distractor was created
    /// </summary>
    private float DistractorBirthTime;
    
    /// <summary>
    /// Save when this distractor was created
    /// </summary>
    void Start()
    {
        DistractorBirthTime = Time.time;
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// If this distractor has lived for TimeToMeltAway time from birth, destroy it
    /// </summary>
    void Update()
    {
        if (Time.time > DistractorBirthTime + TimeToMeltAway)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// When this distractor collides with the player, play audio.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Player>())
        {
            audioSource.PlayOneShot(collisionAudio);
        }
    }

}
