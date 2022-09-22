using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject option;
    public AudioSource audioSource;

    private float musicVolume = 1f;
    private void Start()
    {
        HideAll();
        audioSource.Play();
    }
    void Update()
    {
        audioSource.volume = musicVolume;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            option.SetActive(true);
            //Option popup sebagai parent object dari resume button, quit button, dan volume slider.
        }
    }
    public void HideAll() //resume
    {
        option.SetActive(false);
    }
    public void quit() //quit
    {
        HideAll();
        Application.Quit();
    }

    public void updateVolume(float volume) //change volume slider
    {
        musicVolume = volume;
    }
}
