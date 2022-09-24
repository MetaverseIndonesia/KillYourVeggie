using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public GameObject option;
    public AudioSource audioSource;
    public string mainMenu;

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
            pause.SetActive(true);
            //Pause popup sebagai parent object dari resume button, quit button, dan option button.
        }
    }
    public void HideAll() //resume
    {
        pause.SetActive(false);
        option.SetActive(false);
    }
    public void Options()
    {
        option.SetActive(true);
        //Option popup sebagai parent object dari volume slider dan back button.
    }
    public void Back()
    {
        option.SetActive(false);
    }
    public void leave() //quit
    {
        HideAll();
        SceneManager.LoadScene(mainMenu);
    }

    public void updateVolume(float volume) //change volume slider
    {
        musicVolume = volume;
    }
}
