using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioPlayerHelper : MonoBehaviour
{
    public KeyCode keycode = KeyCode.P;
    public AudioSource audioSource;

    private void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            Play();
        }
    }

    public void Play()
    {
        audioSource.Play();
    }
}
