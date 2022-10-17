using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    CircleCollider2D _circleCollider2D;
    BoxCollider2D _boxCollider2D;

    Animator _animator;

    float _jumpForce = 680.0f;
    float _walkForce = 10.0f;
    float _maxWalkSpeed = 2.0f;
    float _maxAirSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        _animator = GetComponent<Animator>();

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
        if (Input.GetKeyDown(KeyCode.Z) && _rigidbody2D.velocity.y == 0)
        {
            _rigidbody2D.AddForce(transform.up * _jumpForce);
        }

        // 左右移動
        var key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // プレイヤーの速度
        var speedX = Mathf.Abs(_rigidbody2D.velocity.x);

        // スピード制限(空中)
        if (_rigidbody2D.velocity.y != 0)
        {
            // 空中でスピード制限に引っかかっていない場合のみ力を加える
            // ただし、X軸の進行方向と逆への力は加わるようにする
            if (speedX < _maxAirSpeed || _rigidbody2D.velocity.x * key < 0)
            {
                _rigidbody2D.AddForce(transform.right * key * 0.5f);
            }
        }
        // スピード制限(地上)
        else if (speedX < _maxWalkSpeed)
        {
            _rigidbody2D.AddForce(transform.right * key * _walkForce);
        }

        // 動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // プレイヤーの速度に応じてアニメーション速度を変える
        _animator.speed = speedX / 2.0f;

        // 画面外に出たらシーンを読み込み直す(リセット)
        if (_rigidbody2D.position.y < -10f)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene");
    }
}
