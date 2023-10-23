using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("HideInInspector")]
    [HideInInspector] private GameManager gameManager;

    [Header("Menu")]
    [SerializeField] private GameObject MainMenu;

    [Header("Choose Player Menu")]
    [SerializeField] private GameObject selectPlayerMenu;
    [SerializeField] private Button ComeçarJogoBTN;
    [SerializeField] private string playerSelected;

    [Header("Choose Player Debug")]
    [SerializeField] private GameObject DebugCharacters;
    [SerializeField] private GameObject Player1;
    [SerializeField] private Transform spawnP1;
    [SerializeField] private GameObject Player2;
    [SerializeField] private Transform spawnP2;

    [Header("Credits Menu")]
    [SerializeField] private GameObject CreditsMenu;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void IrParaOMenu()
    {
        if (Player1)
            Destroy(Player1);
        if (Player2)
            Destroy(Player2);

        MainMenu.SetActive(true);
        selectPlayerMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        ComeçarJogoBTN.interactable = false;
    }
    public void IrParaSeleçãoDePersonagem()
    {
        if (Player1)
            Destroy(Player1);
        if (Player2)
            Destroy(Player2);

        MainMenu.SetActive(false);
        selectPlayerMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        ComeçarJogoBTN.interactable = false;
        Player2 = Instantiate(Resources.Load<GameObject>("Prefabs/Selection/Noturna"), spawnP2);
    }
    public void IrParaCreditos()
    {
        if (Player1)
            Destroy(Player1);
        if (Player2)
            Destroy(Player2);

        MainMenu.SetActive(false);
        selectPlayerMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        ComeçarJogoBTN.interactable = false;
    }
    public void SelecionarPersonagem(string nomeDoPersonagem)
    {
        playerSelected = nomeDoPersonagem;
        gameManager.PlayerName = nomeDoPersonagem;
        ComeçarJogoBTN.interactable = true;
        AtualizarJogadores3D();
    }
    public void AtualizarJogadores3D()
    {
        if (Player1)
            Destroy(Player1);

        Player1 = Instantiate(Resources.Load<GameObject>("Prefabs/Selection/" + playerSelected), spawnP1);
        if(!Player2)
        Player2 = Instantiate(Resources.Load<GameObject>("Prefabs/Selection/Noturna"), spawnP2);
    }
    public void ComeçarJogo()
    {
        MainMenu.SetActive(false);
        selectPlayerMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        ComeçarJogoBTN.interactable = false;
        gameManager.PlayerName = playerSelected;
        gameManager.StartCoroutine(gameManager.CreateFight(playerSelected, gameManager.fighters[gameManager.currentLevel], gameManager.arenas[gameManager.currentLevel]));
    }
    public void FecharJogo()
    {
        Application.Quit();
    }
}
