using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{

    //ターゲットにするゲームオブジェクトの情報を入れる箱を作る
    [SerializeField]
    public GameObject target;

    //NavMeshAgent コンポーネントの情報を扱うための変数
    private NavMeshAgent agent;

    private Animator anim;

    void Start()
    {
        //NavMeshAgentコンポーネントはゲームオブジェクトを自動的に移動させる情報を持っている
        //agent 変数でNavMeshAgentコンポーネントの情報を使えるようにする
        agent = GetComponent<NavMeshAgent>();

        //アニメーターコンポーネントを使えるようにする
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //ターゲットの情報が入っていたら
        if (target != null)
        {
            //ターゲットの位置を目的地に設定する
            agent.destination = target.transform.position;

            anim.SetFloat("spped", agent.velocity.sqrMagnitude);
            ////このゲームオブジェクトの位置が目的地と違う場合
            //if (transform.position != agent.destination) 
            //{

            //    //アニメーションを歩いているアニメーションにする
            //    anim.SetBool("walking", true);
            //}

            ////目的地に付いている場合
            //else
            //{

            //    //アニメーションをaidlの状態にする
            //    anim.SetBool("walking", false);
            //}
        }
    }
}
