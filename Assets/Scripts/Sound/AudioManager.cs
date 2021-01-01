using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        //verify if theres aaudiomanager active in the next scene and destroys the old one
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        //verify the list of sounds through their names and apply a sound object
        foreach (Sound gameSound in sounds)
        {
            //to facilitate the use of the AudioSource through all the scripts
            //creates and audio source to a component when this script is called
            gameSound.source = gameObject.AddComponent<AudioSource>();
            gameSound.source.clip = gameSound.clip;
            
            //volume control
            gameSound.source.volume = gameSound.volume;
            gameSound.source.pitch = gameSound.pitch;
            gameSound.source.loop = gameSound.loop;
        }
    }

    public void PlayAudio(string name)
    {
        //verify in the array list the name of the sound
        Sound gameSound = Array.Find(sounds, sound => sound.name == name);
        if (gameSound == null)
        {
            return;
        }
        gameSound.source.Play();
        
    }
    
    public void StopAudio (string name)
    {
        Sound gameSound = Array.Find(sounds, sound => sound.name == name);
        if (gameSound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        gameSound.source.Stop ();
    }
    
    //use this codes to call a specific game sound by the name
    /*Private void Start()
    {
        Start a audio File
        FindObjectOfType<AudioManager>().PlayAudio(("NameOfSound"));
        
        Stop a audio File (in case of loop activated)
        FindObjectOfType<AudioManager>().StopAudio(("NameOfSound"));
    }*/
}