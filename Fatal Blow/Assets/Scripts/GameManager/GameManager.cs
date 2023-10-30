using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("HideInInspector")]
    [HideInInspector] private HudManager hudManager;
    [HideInInspector] private CameraManager cameraManager;
    [HideInInspector] private MenuManager menuManager;
    [HideInInspector] public bool canFight;

    [Header("Create Fight")]
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform opponentSpawnPoint;
    [HideInInspector] private GameObject player;
    [HideInInspector] private GameObject opponent;
    [HideInInspector] private GameObject arena;

    [Header("Cinematic")]
    [SerializeField] private Transform playerAnimSpawnPoint;
    [SerializeField] private Transform opponentAnimSpawnPoint;
    [SerializeField] private Image fadeImage;

    [Header("Levels")]
    [SerializeField] public int currentLevel;
    [SerializeField] public int playerWins, opponentWins;
    [SerializeField] public string PlayerName;
    [SerializeField]
    public List<string> fighters = new List<string>
            { "FighterName",};
    [SerializeField]
    public List<string> arenas = new List<string>
            { "FighterName_Arena",};

    private void Awake()
    {
        cameraManager = FindObjectOfType<CameraManager>();
        menuManager = FindObjectOfType<MenuManager>();
        hudManager = FindObjectOfType<HudManager>();
    }
    void Start()
    {
        hudManager.healthCanvas.SetActive(false);
        fadeImage.enabled = true;
        StartCoroutine(BackToMenu());
        hudManager.HideMessage();
    }
    public IEnumerator CreateFight(string playerPrefabName, string opponentPrefabName, string arenaPrefabName)
    {

        float fadeDuration = 1.0f;
        Color startColor = fadeImage.color;
        Color visibleColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);
        Color invisibleColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f);  

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, visibleColor, elapsedTime / fadeDuration);
            yield return null;
        }
        fadeImage.color = visibleColor;
        fadeImage.enabled = true;
        yield return new WaitForSeconds(2.0f);

        if (player)
            Destroy(player);
        if (opponent)
            Destroy(opponent);
        if (arena)
            Destroy(arena);

        player = Instantiate(Resources.Load<GameObject>("Prefabs/Fighters/" + playerPrefabName));
        opponent = Instantiate(Resources.Load<GameObject>("Prefabs/Fighters/" + opponentPrefabName));
        arena = Instantiate(Resources.Load<GameObject>("Prefabs/Arenas/" + arenaPrefabName));

        player.AddComponent<PlayerManager>();
        opponent.AddComponent<EnemyManager>();

        hudManager.SetFighters(player.GetComponent<Status>(), opponent.GetComponent<Status>());
        cameraManager.SetFighters(player.GetComponent<Status>(), opponent.GetComponent<Status>());
        StartCoroutine(StartFight(player.GetComponent<Status>(), opponent.GetComponent<Status>()));
    }

    public IEnumerator StartFight(Status player, Status opponent)
    {
        float fadeDuration = 1.0f;
        Color startColor = fadeImage.color;
        Color visibleColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);
        Color invisibleColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f); 

        player.ResetStatus();
        opponent.ResetStatus();

        player.transform.position = playerAnimSpawnPoint.position;
        opponent.transform.position = opponentAnimSpawnPoint.position;

        if (opponentWins == 0 && playerWins == 0)
        {
            cameraManager.playerOnFocus = player.transform;
            cameraManager.OriginfocusPosition = new Vector3(3.5f, 1.0f, -0.5f);
            player.GetComponent<Animator>().Play("Intro");

            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                fadeImage.color = Color.Lerp(startColor, invisibleColor, elapsedTime / fadeDuration);
                yield return null;
            }
            fadeImage.color = invisibleColor;

            yield return new WaitForSeconds(3);
            cameraManager.playerOnFocus = opponent.transform;
            cameraManager.OriginfocusPosition = new Vector3(-3.5f, 1.0f, -0.5f);
            opponent.GetComponent<Animator>().Play("Intro");
            yield return new WaitForSeconds(3);
            cameraManager.OriginfocusPosition = new Vector3(0f, 0f, -5f);
        }
        else
        {
            player.transform.position = playerSpawnPoint.position;
            opponent.transform.position = opponentSpawnPoint.position;
            opponent.GetComponent<EnemyManager>().LookAtOpponent();

            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                fadeImage.color = Color.Lerp(startColor, invisibleColor, elapsedTime / fadeDuration);
                yield return null;
            }
            fadeImage.color = invisibleColor;
            opponent.GetComponent<EnemyManager>().LookAtOpponent();
        }
        hudManager.ShowMessage("Lutem!");
        yield return new WaitForSeconds(2f);
        hudManager.HideMessage();

        player.transform.position = playerSpawnPoint.position;
        opponent.transform.position = opponentSpawnPoint.position;
        opponent.GetComponent<EnemyManager>().LookAtOpponent();


        cameraManager.playerOnFocus = null;
        canFight = true;
        hudManager.healthCanvas.SetActive(true);

        opponent.GetComponent<EnemyManager>().StartCoroutine(opponent.GetComponent<EnemyManager>().FightOpponent());
    }
    public IEnumerator EndFight(Status Loser)
    {
        float fadeDuration = 2.0f;
        Color startColor = fadeImage.color;
        Color visibleColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);
        Color invisibleColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f);

        canFight = false;
        hudManager.healthCanvas.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        if (playerWins == 2)
        {
            float elapsedTime = 0f;
            yield return new WaitForSeconds(2.0f);
            hudManager.ShowMessage(player.GetComponent<Status>().Name + " Venceu");
            yield return new WaitForSeconds(5.0f);
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                fadeImage.color = Color.Lerp(startColor, visibleColor, elapsedTime / fadeDuration);
                yield return null;
            }
            fadeImage.color = visibleColor;
            if (currentLevel != 0)
            {
                currentLevel++;
                playerWins = 0;
                opponentWins = 0;
                yield return new WaitForSeconds(1.0f);
                hudManager.HideMessage();
                cameraManager.transform.position = new Vector3(0, 0, 0);
                StartCoroutine(CreateFight(PlayerName, fighters[currentLevel], arenas[currentLevel]));
            }
            else
            {
                currentLevel = 0;
                playerWins = 0;
                opponentWins = 0;
                yield return new WaitForSeconds(1.0f);
                hudManager.HideMessage();
                cameraManager.transform.position = new Vector3(0, 0, 0);
                StartCoroutine(BackToMenu());

            }
        }
        else if (opponentWins == 2)
        {

            float elapsedTime = 0f;
            yield return new WaitForSeconds(2.0f);
            hudManager.ShowMessage(opponent.GetComponent<Status>().Name + " Venceu");
            yield return new WaitForSeconds(5.0f);
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                fadeImage.color = Color.Lerp(startColor, visibleColor, elapsedTime / fadeDuration);
                yield return null;
            }
            fadeImage.color = visibleColor;
            currentLevel = 0;
            playerWins = 0;
            opponentWins = 0;
            yield return new WaitForSeconds(1.0f);
            hudManager.HideMessage();
            StartCoroutine(BackToMenu());
        }
        else if (opponentWins <= 1)
        {
            float elapsedTime = 0f;
            yield return new WaitForSeconds(2.0f);
            hudManager.ShowMessage("Próximo Round!");
            while (elapsedTime < 3f)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            hudManager.HideMessage();
            StartCoroutine(StartFight(player.GetComponent<Status>(), opponent.GetComponent<Status>()));
        }
    }
    public IEnumerator BackToMenu()
    {

        float fadeDuration = 2.0f;
        Color startColor = fadeImage.color;
        Color visibleColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);
        Color invisibleColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f);

        float elapsedTime0 = 0f;
        while (elapsedTime0 < fadeDuration)
        {
            elapsedTime0 += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, visibleColor, elapsedTime0 / fadeDuration);
            yield return null;
        }
        fadeImage.color = visibleColor;

        if (player)
            Destroy(player);
        if (opponent)
            Destroy(opponent);
        if (arena)
            Destroy(arena);

        menuManager.IrParaOMenu();

        float elapsedTime1 = 0f;
        while (elapsedTime1 < fadeDuration)
        {
            elapsedTime1 += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, invisibleColor, elapsedTime1 / fadeDuration);
            yield return null;
        }
        cameraManager.transform.position = new Vector3(0, 0, 0);
        cameraManager.transform.rotation = Quaternion.Euler(0, 0, 0);
        fadeImage.color = invisibleColor;
        fadeImage.enabled = false;
    }
}
