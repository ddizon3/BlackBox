using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls the flasing of the buttons
//controls collision with buttons
//controls score

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Renderer myObject;
    public float timeToChange = 3f;
    public float timeSinceChange = 0f;
    private bool isGreen = false;

    public AudioSource btnSound;

    void Start()
    {
        btnSound = GetComponent<AudioSource>();
    }

    void Update()
    {

        timeSinceChange += Time.deltaTime;

        if (timeSinceChange >= timeToChange && isGreen == false)
        {     
            //apply color to current object
            myObject.material.color = Color.green;

            timeSinceChange = 0;
            timeToChange = Random.Range(2.0f, 8.0f);
            isGreen = true;

        } else if (timeSinceChange >= timeToChange && isGreen == true)
        {
            //apply color to current object
            myObject.material.color = Color.red;

            timeSinceChange = 0;
            timeToChange = Random.Range(2.0f, 8.0f);
            isGreen = false;
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player" && isGreen == true)
        {
            GameManager.totalScore++;
            btnSound.Play();

            isGreen = false;
            myObject.material.color = Color.red;
        }

    }
}
