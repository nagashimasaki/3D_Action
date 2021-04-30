using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShotShell : MonoBehaviour
{
    //砲弾のスピード
    public float shotSpeed;

    //複製対象のゲームオブジェクト
    [SerializeField]
    private GameObject enemyShellPrefab;

    //砲弾を打つときの音
    [SerializeField]
    private AudioClip shotSound;

    //時間の計測用の変数
    private int interval;

    void Update()
    {
        //時間を1ずつ加算する
        interval += 1;

        //interval 変数の値を 60 で割った計算結果の余りの値が 0 であり、かつ、stopTimer 変数の値が 0 か、0 以下であるなら
        if (interval % 60 == 0)
        {
            //敵の弾のプレファブ・ゲームオブジェクトからクローンのゲームオブジェクトを、このスクリプトがアタッチしている
            //ゲームオブジェクトの位置に無回転の状態で生成し、そのゲームオブジェクトの情報を左辺の enemyShell 変数に代入することで
            //制御を行える状態にする
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            //enemyShellの中にあるRigidbodyコンポーネントの情報をenemyShellRb変数に代入する
            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            //enemyShellRb変数の情報のAddForceメソッドで砲弾に力を加え続ける
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            //鳴らしたいオーディオクリップ（shotSound）と座標を引数に指定して、指定した場所に新しく一時オブジェクトを生成し、効果音を鳴らす
            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            //enemyShelオブジェクトを3秒後に破壊する
            Destroy(enemyShell, 3.0f);
        }
    }
}
