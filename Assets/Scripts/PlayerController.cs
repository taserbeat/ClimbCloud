using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    CircleCollider2D _circleCollider2D;
    BoxCollider2D _boxCollider2D;

    float _jumpForce = 680.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        // 重力の設定
        _rigidbody2D.gravityScale = 3;

        // 当たり判定の設定
        _circleCollider2D.offset = new Vector2(0, -0.3f);
        _circleCollider2D.radius = 0.15f;

        _boxCollider2D.offset = new Vector2(0, 0);
        _boxCollider2D.size = new Vector2(0.3f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        // ジャンプする
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _rigidbody2D.AddForce(transform.up * _jumpForce);
        }
    }
}
