using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanController : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    Rigidbody rb;

    [SerializeField]
    private float jumpForce = 0;

    [Header("ユニティちゃんの動く速さ")]
    public float moveSpeed;

    [Header("ユニティちゃんの旋回する速さ")]
    public float turnSpeed;

    private float movementInputValue;

    private float turnInputValue;

    void Start()
    {
        //このスクリプトが付いているゲームオブジェクトからRigidbody コンポーネントの情報を取得して
        //rb 変数にRigidbody コンポーネントの情報を入れる
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //スペースキーが押されたら
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //jumpForce 変数に入っている値の数値分上に力を加える
            rb.AddForce(transform.up * jumpForce);
        }

        //UnitychanMovement メソッドを作る
        UnitychanMovement();

        //UnitychanTurn メソッドを作る
        UnitychanTurn();
    }

    /// <summary>
    /// 前進・後退のメソッド
    /// </summary>
    void UnitychanMovement()
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    /// <summary>
    /// 旋回のメソッド
    /// </summary>
    void UnitychanTurn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
