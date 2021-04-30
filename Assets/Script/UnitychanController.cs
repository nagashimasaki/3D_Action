using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanController : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    Rigidbody rb;

    [Header("ジャンプ力")]             
    public float jumpPower;
    [Header("地面判定用レイヤー")]
    public LayerMask groundLayer;
    private bool isGround;


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
        //UnitychanMovement メソッドを作る
        UnitychanMovement();

        //UnitychanTurn メソッドを作る
        UnitychanTurn();

        // ジャンプ
        Jump();
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

    /// <summary>    
	/// ジャンプ
	/// </summary>
	private void Jump()
    {
        //  Linecastでキャラの足元に地面があるか判定  地面があるときはTrueを返す
        isGround = Physics.Linecast(transform.position + transform.up * 1, transform.position - transform.up * 0.3f, groundLayer);

        //  着地していたとき、キー入力のJumpで反応（GetButton）スペースキー(GetKey)
        if (Input.GetButtonDown("Jump") && isGround)
        {
            //  着地判定をfalse
            isGround = false;

            //  AddForceにて上方向へ力を加える
            rb.AddForce(Vector3.up * jumpPower);
        }
    }        
}
