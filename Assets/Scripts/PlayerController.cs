using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    float _jumpForce = 680.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        // 重力の設定
        _rigidbody2D.gravityScale = 3;
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
