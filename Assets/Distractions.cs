using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractions : MonoBehaviour
{
    /// <summary>
    /// Distractor ProjectilePrefabs
    /// </summary>
    public GameObject DistractorPrefab;
    public GameObject FacebookPrefab;
    public GameObject InstagramPrefab;
    public GameObject NetflixPrefab;
    public GameObject SnapchatPrefab;
    public GameObject SteamPrefab;
    public GameObject TiktokPrefab;
    public GameObject WechatPrefab;
    public GameObject YoutubePrefab;

    /// <summary>
    /// Initial velocity of the instantiated distractor
    /// </summary>
    public float DistractorVelocity = 3;

    /// <summary>
    /// The minimum amount of time this object should wait to fire a distractor
    /// </summary>
    public float DistractorCoolDownLowerBound = 7;

    /// <summary>
    ///  The maximum amount of time this object should wait to fire a distractor
    /// </summary>
    public float DistractorCoolDownUpperBound = 13;

    /// <summary>
    /// Explosion prefab for when this object is destroyed
    /// </summary>
    public GameObject ExplosionPrefab;

    /// <summary>
    /// Array to hold the distractor prefabs
    /// </summary>
    private GameObject[] distractorArray;

    /// <summary>
    /// The index for which distractor should be instantiated from distractorArray
    /// </summary>
    private int distractorChoice;

    /// <summary>
    /// The actual cooldown time between LowerBound and UpperBound
    /// </summary>
    private float DistractorCoolDown;

    /// <summary>
    /// When the object should fire a distractor
    /// </summary>
    public float TimeToFire;

    /// <summary>
    /// The player's transform
    /// </summary>
    private Transform player;

    /// <summary>
    /// The player's direction with respect to this object
    /// </summary>
    private Vector2 PlayerDirection;

    /// <summary>
    /// Initialize fields
    /// </summary>
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        distractorArray = new GameObject[] { FacebookPrefab, InstagramPrefab, NetflixPrefab, SnapchatPrefab, SteamPrefab, TiktokPrefab, WechatPrefab, YoutubePrefab };
        DistractorCoolDown = Random.Range(DistractorCoolDownLowerBound, DistractorCoolDownUpperBound);
        TimeToFire = Time.time + DistractorCoolDown;
    }

    /// <summary>
    /// When time to fire, fire distractor
    /// </summary>
    void Update()
    {
        if (Time.time > TimeToFire)
        {
            Fire();
            DistractorCoolDown = Random.Range(5, 11);
            TimeToFire += DistractorCoolDown;
        }
    }

    /// <summary>
    /// Follow the player
    /// </summary>
    private void FixedUpdate()
    {
        transform.right = player.position - transform.position;
    }

    /// <summary>
    /// Fire a distractor, randomly chosen from the array
    /// </summary>
    private void Fire()
    {
        PlayerDirection = (player.position - transform.position).normalized;
        Vector2 position = new Vector2(transform.position.x, transform.position.y) + PlayerDirection;
        distractorChoice = Random.Range(0, 8);
        // var distract = Instantiate(DistractorPrefab, position, Quaternion.identity);
        var distract = Instantiate(distractorArray[distractorChoice], position, Quaternion.identity);
        Rigidbody2D distractorBody = distract.GetComponent<Rigidbody2D>();
        distractorBody.velocity = DistractorVelocity * PlayerDirection;
        distractorBody.transform.right = PlayerDirection;
    }

    /// <summary>
    /// Called to create explosion animation
    /// </summary>
    public void Boom()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Invoke("Destruct", 0.1f);
    }

    /// <summary>
    /// Called from Boom() to destroy this game object
    /// </summary>
    void Destruct()
    {
        Destroy(gameObject);
    }

}
