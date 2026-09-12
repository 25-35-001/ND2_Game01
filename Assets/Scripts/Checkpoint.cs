using UnityEngine;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public int multiplier = 2;// このチェックポイントで何回倍率をかけたか

    private int useCount = 0;

    // 最大2回
    private int maxUseCount = 2;

    // UI
    public TextMeshProUGUI checkpointText;

    private void Start()
    {
        UpdateCheckpointText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (useCount < maxUseCount) //2回未満なら実行される
            {
                useCount++;

                GameManager.Instance.MultiplyScore(multiplier);//GameManagerにスコア加算をしてもらう

                UpdateCheckpointText();

                Debug.Log(
                    "チェックポイント：" +
                    useCount +
                    "回目 / スコア：" +
                    GameManager.Instance.score
                );
            }
        }
    }

    private void UpdateCheckpointText()
    {
        checkpointText.text =
            "Checkpoint : " + useCount + " / " + maxUseCount;
    }
}