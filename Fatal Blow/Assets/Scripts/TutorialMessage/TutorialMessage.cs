using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
    PlayerControls playerControls;
    public GameObject canvas;
    public bool onTutorial;

    private void Awake()
    {
        canvas.SetActive(false);
    }
    void OnEnable()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();

    }
    public void ShowMessage()
    {
        onTutorial = true;
        canvas.SetActive(true);
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }
    private void Update()
    {
        if (playerControls.Player.Pause.triggered && onTutorial)
        {
            HideMessage();
            onTutorial = false;
        }
    }

    public void HideMessage()
    {
        onTutorial = false;
        canvas.SetActive(false);
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }
}
