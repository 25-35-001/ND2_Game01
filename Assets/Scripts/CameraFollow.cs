using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    // ステージの範囲
    public float minX = -100f;
    public float maxX = 100f;
    public float minY = -50f;
    public float maxY = 50f;

    void LateUpdate()
    {
        if (player == null)
            return;

        // Playerの位置を取得
        float x = player.position.x;
        float y = player.position.y;

        // カメラの大きさを考慮
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // カメラがステージ外に出ないように制限
        x = Mathf.Clamp(
            x,
            minX + cameraWidth,
            maxX - cameraWidth
        );

        y = Mathf.Clamp(
            y,
            minY + cameraHeight,
            maxY - cameraHeight
        );

        // カメラを移動
        transform.position = new Vector3(
            x,
            y,
            transform.position.z
        );
    }
}