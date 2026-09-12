using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int scoreMultiplier = 1;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    // 結果画面
    public GameObject resultPanel;
    public TextMeshProUGUI resultScoreText;

    // 制限時間
    public float timeLimit = 60f;

    private float currentTime;

    private bool gameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentTime = timeLimit;

        resultPanel.SetActive(false);

        UpdateScore();
        UpdateTime();
    }

    private void Update()
    {
        if (gameOver)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOver();
        }

        UpdateTime();
    }

    // 宝を取ったとき
    public void AddScore(int amount)
    {
        if (gameOver)
            return;

        score += amount * scoreMultiplier;

        UpdateScore();

        Debug.Log("スコア：" + score);
    }

    // チェックポイント
    public void MultiplyScore(int multiplier)
    {
        if (gameOver)
            return;

        score *= multiplier;

        UpdateScore();

        Debug.Log("チェックポイント通過！ スコア：" + score);
    }

    private void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    private void UpdateTime()
    {
        timeText.text = "Time : " + Mathf.Ceil(currentTime);
    }

    // ゲームオーバー
    private void GameOver()
    {
        gameOver = true;

        Debug.Log("時間切れ！");

        // Playerを止める
        PlayerController player = FindFirstObjectByType<PlayerController>();

        if (player != null)
        {
            player.enabled = false;
        }

        // 結果画面を表示
        resultPanel.SetActive(true);

        // 最終スコアを表示
        resultScoreText.text = "Score : " + score;
    }

    // Retry
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}