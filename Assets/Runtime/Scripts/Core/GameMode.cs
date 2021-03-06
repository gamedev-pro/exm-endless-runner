using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameMode : MonoBehaviour
{
    [SerializeField] private GameSaver gameSaver;

    [Header("Player")]
    [SerializeField] PlayerController player;
    [SerializeField] PlayerAnimationController playerAnimationController;

    [Header("UI")]
    [SerializeField] private MainHUD mainHud;

    [SerializeField] private MusicPlayer musicPlayer;

    [Header("Gameplay")]
    [SerializeField] private float startPlayerSpeed = 10;
    [SerializeField] private float maxPlayerSpeed = 20;
    [SerializeField] private float timeToMaxSpeedSeconds = 5 * 60;

    [SerializeField] private float reloadGameDelay = 3;

    [SerializeField]
    [Range(0, 5)]
    private int startGameCountdown = 5;

    [Header("Score")]
    [SerializeField] private float baseScoreMultiplier = 1;

    private float score;

    public SaveGameData CurrentSave => gameSaver.CurrentSave;
    public AudioPreferences AudioPreferences => gameSaver.AudioPreferences;

    public int Score => Mathf.RoundToInt(score);

    public int CherriesPicked { get; set; }
    public int PeanutsPicked { get; set; }

    public int TemporaryScoreMultipler
    {
        get => temporaryScoreMultiplier;
        set => temporaryScoreMultiplier = Mathf.Max(1, value);
    }

    private int temporaryScoreMultiplier = 1;
    private float startGameTime;

    private bool isGameRunning = false;

    private void Awake()
    {
        gameSaver.LoadGame();
        SetWaitForStartGameState();
        player.PlayerDeathEvent += OnPlayerDeath;
    }

    private void OnDestroy()
    {
        player.PlayerDeathEvent -= OnPlayerDeath;
    }

    private void Update()
    {
        if (isGameRunning)
        {
            float timePercent = (Time.time - startGameTime) / timeToMaxSpeedSeconds;
            player.ForwardSpeed = Mathf.Lerp(startPlayerSpeed, maxPlayerSpeed, timePercent);
            float extraScoreMultiplier = 1 + timePercent;
            score += baseScoreMultiplier * TemporaryScoreMultipler * extraScoreMultiplier * player.ForwardSpeed * Time.deltaTime;
        }
    }

    private void SetWaitForStartGameState()
    {
        player.enabled = false;
        isGameRunning = false;
        mainHud.ShowOverlay<StartGameOverlay>();
        musicPlayer.PlayStartMenuMusic();
    }

    public void OnPlayerDeath()
    {
        GameOver();
    }

    public void GameOver()
    {
        isGameRunning = false;
        player.ForwardSpeed = 0;

        gameSaver.SaveGame(new SaveGameData
        {
            HighestScore = Score > gameSaver.CurrentSave.HighestScore ? Score : gameSaver.CurrentSave.HighestScore,
            LastScore = Score,
            TotalCherriesCollected = gameSaver.CurrentSave.TotalCherriesCollected + CherriesPicked,
            TotalPeanutsCollected = gameSaver.CurrentSave.TotalPeanutsCollected + PeanutsPicked
        });

        StartCoroutine(ReloadGameCoroutine());
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCor());
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private IEnumerator StartGameCor()
    {
        musicPlayer.PlayMainTrackMusic();
        yield return StartCoroutine(mainHud.PlayStartGameCountdown(startGameCountdown));
        yield return StartCoroutine(playerAnimationController.PlayStartGameAnimation());

        player.enabled = true;
        player.ForwardSpeed = startPlayerSpeed;
        startGameTime = Time.time;
        isGameRunning = true;
    }

    private IEnumerator ReloadGameCoroutine()
    {
        yield return new WaitForSeconds(1);
        musicPlayer.PlayGameOverMusic();
        yield return new WaitForSeconds(reloadGameDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
