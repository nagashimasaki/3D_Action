using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //エフェクト1を入れる箱を作る
    //[SerializeField]
    //private GameObject effectPrefab1;

    //エフェクト2を入れる箱を作る
    //[SerializeField]
    //private GameObject effectPrefab2;

    //objectHP 変数にHPの値を入れる
    public int objectHP;

    /// <summary>
    /// このメソッドはコライダー同士がぶつかった瞬間に呼び出される
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //ぶつかった相手のTagにAttackという名前が付いていたら（条件）
        if (other.gameObject.CompareTag("Attack"))
        {
            Debug.Log("通過");
            //オブジェクトのHPを１ずつ減少させる
            objectHP -= 1;

            //HPが０よりも大きい場合には（条件）
            if (objectHP > 0)
            {
                //エフェクト1のプレファブ・ゲームオブジェクトからクローンのゲームオブジェクトを、
                //このスクリプトがアタッチしている,ゲームオブジェクトの位置にエフェクト1を無回転で生成し、
                //そのゲームオブジェクトの情報を左辺の effect 変数に代入することで制御を行える状態にする
                //GameObject effect = Instantiate(effectPrefab1, other.transform.position, Quaternion.identity);

                //画面に表示しているエフェクト1をを2秒後に破棄する
                //Destroy(effect, 2.0f);
            }
            //HPが０よりも小さい場合には（条件）
            else
            {
                //エフェクト2のプレファブ・ゲームオブジェクトからクローンのゲームオブジェクトを、
                //このスクリプトがアタッチしている,ゲームオブジェクトの位置にエフェクト2を無回転で生成し、
                //そのゲームオブジェクトの情報を左辺の effect2 変数に代入することで制御を行える状態にする
                //GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);

                //画面に表示しているエフェクト2を2秒後に破壊する
                //Destroy(effect2, 2.0f);

                //このスクリプトが付いているオブジェクトを破壊する
                Destroy(gameObject);
            }
        }
    }
}
