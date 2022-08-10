using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RedZoneController : MonoBehaviour
{
    public Transform[] waypoints; //array of waypoints on map
    public int speed;

    private int waypointIndex;
    private float dist;

    public AudioSource lifeLost;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        lifeLost = GetComponent<AudioSource>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

     void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (dist < 1) 
        {
            IncreaseIndex();
        };

        Patrol();

    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LifeCount.totalLives -= 1;
            lifeLost.Play();
            animator.SetTrigger("Change");
        }
    }
}
