using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    public GameObject PauseMenu;
    public void BackToPlay()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
