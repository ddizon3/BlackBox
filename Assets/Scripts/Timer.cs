using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static float currentTime;
    public float startingTime;

    public Animator anim;
    public AudioSource buzzAlert;

    [SerializeField] Text timer;

    void Start()
    {
        buzzAlert = GetComponent<AudioSource>();
        currentTime = startingTime;
        string minutes = ((int)currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        timer.text = minutes + ":" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        CountdownController cc = FindObjectOfType<CountdownController>();

        if (!cc || !cc.gameStarted)
        {
            return;
        }

        currentTime -= 1 * Time.deltaTime;

        string minutes = ((int) currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");

        timer.text = minutes + ":" + seconds;

        if (currentTime <= 6 && currentTime > 0)
        {
            if (!buzzAlert.isPlaying)
            {
                buzzAlert.Play();
            }

            anim.SetBool("timeTicking", true);
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            anim.SetBool("timeTicking", false);
            buzzAlert.Pause();
        }
    }
}
