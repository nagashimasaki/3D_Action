using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab1;
    [SerializeField]
    private GameObject effectPrefab2;
    public int unityChanHP;
    [SerializeField]
    private Text HPLabel;

    void Start()
    {
        HPLabel.text = "HP:" + unityChanHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ( "EnemyShell"))
        {
            Debug.Log("ダメージ");
            unityChanHP -= 1;
            HPLabel.text = "HP:" + unityChanHP;
            Destroy(other.gameObject);

            if (unityChanHP > 0)
            {
                GameObject effect1 = Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else
            {
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);
                Destroy(gameObject);

                //プレイヤーを破壊せずに画面から見えなくする。プレイヤーを破壊すると、その時点でメモリー上から消えるので、以降のコードが実行されない
                this.gameObject.SetActive(false); 
                Invoke("GoToGameOver", 1.5f);
            }
        }
    }
}
