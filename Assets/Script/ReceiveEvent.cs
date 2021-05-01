using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveEvent : MonoBehaviour
{
	//剣のコライダ
	public Collider col;

	//AudioSource
	public AudioSource audioSource;

	//効果音の配列
	public AudioClip[] se;             

	//　足が地面に付いた時のイベント
	void Step()
	{
		Debug.Log("Step");
		audioSource.PlayOneShot(se[0]);
	}

	//　剣を振りおろす時のイベント
	void AttackStart()
	{
		audioSource.PlayOneShot(se[1]);
		col.enabled = true;
	}

	//　剣を振り終わった時のイベント
	void AttackEnd()
	{
		col.enabled = false;
	}
}
