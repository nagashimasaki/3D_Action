using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    //enemyPrefabの情報を入れる箱を作る
    [SerializeField]
    private GameObject enemyPrefab;

    //ターゲットにするゲームオブジェクトの情報を入れる箱を作る
    [SerializeField]
    private GameObject taget;

    //時間の計測用の変数
    private int interval;

    public float divideTime;

    void Update()
    {
        interval += 1;

        //interval 変数の値を 60 で割った計算結果の余りの値が 0 であるなら
        if (interval % divideTime == 0)
        {
            //
            GameObject enemyB = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            enemyB.GetComponent<ChaseEnemy>().target = taget;
            //コンソールに「敵を生成」と表示する
            Debug.Log("敵を生成");
        }
    }
}
