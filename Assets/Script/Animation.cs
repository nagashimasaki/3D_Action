using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
	// Animator コンポーネント
	private Animator animator;

	public CapsuleCollider capsuleCollider;

	// 設定したフラグの名前
	private const string key_isRun = "isRun";
	private const string key_isJump = "isJump";

	// 初期化メソッド
	void Start()
	{
		// 自分に設定されているAnimatorコンポーネントを習得する
		animator = GetComponent<Animator>();
	}

	// 1フレームに1回コールされる
	void Update()
	{
		Attack1Start();

		Attack1End();

		// 矢印下ボタンを押下している
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        { 
			// WaitからRunに遷移する
			animator.SetBool(key_isRun, true);
		}
		else
		{
			// RunからWaitに遷移する
			animator.SetBool(key_isRun, false);
		}

		// Wait or Run からJumpに切り替える処理
		// スペースキーを押下している
		if (Input.GetKey(KeyCode.Space))
		{
			// Wait or RunからJumpに遷移する
			animator.SetBool(key_isJump, true);
		}
		else
		{
			// JumpからWait or Runに遷移する
			animator.SetBool(key_isJump, false);
		}

		// Wait or Run からAttackに切り替える処理
		//キーボードのVボタンが押された時
		if (Input.GetKey(KeyCode.V))
		{
			animator.SetBool("isAttack", true);
		}
		else
		{
			// JumpからWait or Runに遷移する
			animator.SetBool("isAttack", false);
		}
	}

	void Attack1Start()
	{
		capsuleCollider.enabled = true;
	}

	//アニメーションイベント
	//アニメーションの終了と同時にColliderを消す
	//アニメーションを攻撃から待機へ戻す
	void Attack1End()
	{
		capsuleCollider.enabled = false;
		animator.SetBool("isAttack", false);
	}
}
