using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    //移動メソッド
    // Player InputのMoveから呼ばれる
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(
            moveInput.x,
            moveInput.y,
            0f
        );

        // 移動中かどうか
        bool isMoving = moveInput.sqrMagnitude > 0.01f;

        animator.SetBool("IsMoving", isMoving);

        transform.position += movement * moveSpeed * Time.deltaTime;

        // 左右を向く
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}