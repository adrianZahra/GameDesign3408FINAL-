using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    Transform player;
    Rigidbody rb;

    public AudioClip audio;
    private AudioSource heliSpawnAudio;
    public Rigidbody explosion;

    // Speed variables
    public float slowSpeed = 6f;
    public float speed = 10f;

    // Distance thresholds
    public float closeThreshold = 20f;
    public float reallyCloseThreshold = 10f;

    // Rotation variables
    public float RotationSpeed = 10f;
    private Quaternion lookRotation;
    private Vector3 direction;

    void Start()
    {
        heliSpawnAudio = gameObject.AddComponent<AudioSource>();
        heliSpawnAudio.clip = audio;
        heliSpawnAudio.Play();
        player = GameObject.FindGameObjectWithTag("Player").transform; //Find the player asset with the "Player" tag
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(transform.position.x, player.position.y + 10f, transform.position.z);

        if ((roundManager.round % 5) != 0)
        {
            Destroy(gameObject, 0f);
            Rigidbody instantiatedProjectile = Instantiate(explosion, transform.position, transform.rotation) as Rigidbody;
        }

        Rotate();
        Move();
    }

    void Move()
    {
        Vector3 rightVector = new Vector3(1, 0, 0);
        Vector3 leftVector = new Vector3(-1, 0, 0);

        bool close = Close();

        bool atPlayer = AtPlayer();

        if (player.position.x > transform.position.x) // If the player is to the right of the helicopter
        {
            rb.AddForce(rightVector * speed);
        } else if (player.position.x < transform.position.x) // If the player is to the left of the helicopter
        {
            rb.AddForce(leftVector * speed);
        }

        if (close)
        {
            if (atPlayer)
            {
                speed = 0f; // If the helicopter is really close to the player, remove speed so that the helicopter can fully stop
                rb.drag = 1f;
            } else
            {
                speed = slowSpeed;
                rb.drag = 0.7f; // Add drag so that helicopter slows down when close to the player
            }
           
            
        } else
        {
            rb.drag = 0;
            speed = 10f;
        }
    }

    void Rotate() // Rotate towards player
    {
        direction = (player.position - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
    }

    bool Close() // Check if the helicopter's X coordinate is close to the player's X coordinate
    {
        float positionDifference = transform.position.x - player.position.x;
        if (positionDifference < closeThreshold && positionDifference > -closeThreshold)
        {
            return true;
        } else
        {
            return false;
        }
    }

    bool AtPlayer() // Check if the helicopter is really close to the player
    {
        float positionDifference = transform.position.x - player.position.x;
        if (positionDifference < reallyCloseThreshold && positionDifference > -reallyCloseThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
