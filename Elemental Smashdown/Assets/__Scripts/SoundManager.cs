using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    public AudioClip click;
    public AudioClip selectUp;
    public AudioClip selectDown;
    public AudioClip goodAttack;
    public AudioClip badAttack;
    public AudioClip endTurn;
    public AudioClip win;

    private AudioSource source;
    private AudioClip clip;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
    }

    public void PlaySound(string key, float vol)
    {
        source.pitch = 1f;

        if (key == "click")
        {
            source.PlayOneShot(click, vol);
        }
        else if (key == "selectUp")
        {
            source.PlayOneShot(selectUp, vol);
        }
        else if (key == "selectDown")
        {
            source.PlayOneShot(selectDown, vol);
        }
        else if (key == "goodAttack")
        {
            clip = goodAttack;
            source.pitch = Random.Range(.8f, 1.2f);
            source.PlayOneShot(clip, vol);
        }
        else if (key == "badAttack")
        {
            clip = badAttack;
            source.pitch = Random.Range(.8f, 1.2f);
            source.PlayOneShot(clip, vol);
        }
        else if (key == "endTurn")
        {
            source.PlayOneShot(endTurn, vol);
        }
        else if (key == "win")
        {
            source.PlayOneShot(win, vol);
        }
    }

}
