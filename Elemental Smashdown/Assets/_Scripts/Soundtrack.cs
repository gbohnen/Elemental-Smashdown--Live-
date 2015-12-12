using UnityEngine;
using System.Collections;

public class Soundtrack : MonoBehaviour
{
    // singleton that gets replaced when a new one enters
    public static Soundtrack instance = null;

    // Variable for projectile GameObject
    public GameObject projectile;

    // Variable for shootSound AudioClip
    public AudioClip shootSound;

    // Variable for AudioSource
    AudioSource source;

    // master volume
    public static float sliderValue = 1;

    // Used to inititalize any variables or game state before the game starts
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this && instance != this && Application.loadedLevelName != "Main menu")
        {
            Destroy(instance.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // play sound once
        source.PlayOneShot(shootSound, .8f);

        if (Application.loadedLevelName == "play")
        {
            AudioListener.volume = sliderValue;
        }

    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {

        }
    }
}
