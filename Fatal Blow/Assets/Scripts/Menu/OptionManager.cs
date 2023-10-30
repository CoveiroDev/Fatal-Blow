using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    [Header("Menus")]
    PlayerControls playerControls;
    [SerializeField] private GameObject sobre;
    [SerializeField] private GameObject menu;

    private void OnEnable()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();
    }
    private void Update()
    {
        if (playerControls.Player.Pause.triggered)
        {
            TurnMenu();
        }
    }
    private void Start()
    {
        menu.SetActive(false);
        sobre.SetActive(false);
    }
    public void TurnSobre()
    {
        bool sobreActive = sobre.activeSelf;
        sobre.SetActive(!sobreActive);
    }
    public void TurnMenu()
    {
        bool menuActive = menu.activeSelf;
        menu.SetActive(!menuActive);
        if (menu == true && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            sobre.SetActive(false);
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
    }
}