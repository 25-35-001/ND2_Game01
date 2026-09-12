using UnityEngine;

public class Takara : MonoBehaviour
{
    public int score = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);
            //G‚ê‚½‚çíœ
            Destroy(gameObject);
        }
    }
}
