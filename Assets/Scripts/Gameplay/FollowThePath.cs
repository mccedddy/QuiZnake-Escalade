using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;
    public bool climbAllowed = false;
    public int end = 0;
    public bool isMoving = false;
    private bool walkingAudio = false;

    // START
    void Start()
    {
        //waypointIndex = 0;
        moveAllowed = false;
        climbAllowed = false;
        end = 0;
        isMoving = false;

        // Load and Delete Save
        if (PlayerPrefs.GetString("continued") == "true")
        {
            SaveData.Load();
            waypointIndex = PlayerPrefs.GetInt("waypointIndex");
        }

        transform.position = waypoints[GameControl.player1Position - 1].transform.position;
    }

    // UPDATE
    private void Update()
    {
        if (moveAllowed)
            Move();
        if (climbAllowed && !isMoving)
            Climb(end);

        // Walking Audio
        if (isMoving && walkingAudio == false)
        {
            GameControl.SFX_Walk.GetComponent<AudioSource>().Play();
            walkingAudio = true;
        }
        if (isMoving == false)
        {
            GameControl.SFX_Walk.GetComponent<AudioSource>().Stop();
            walkingAudio = false;
        }
    }

    // Follow waypoints
    private void Move()
    {
        isMoving = true;
        Dice.clickable = false;

        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }

    // Climb or Slide
    private void Climb(int end)
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[end-1].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[end-1].transform.position)
            {
                waypointIndex = end - 1;

                climbAllowed = false;
                GameControl.player1StartWaypoint = end - 1;
                GameControl.player1Position = GameControl.player1StartWaypoint + 1;
                end = 0;
            }
        }
    }
}