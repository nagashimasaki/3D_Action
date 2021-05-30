using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MonsterMaterial
{
    public MonsterMaterialTyp monsterMaterialTyp;

    public int materialreward;
}

public class MonsterMaterialobject : MonoBehaviour
{
    
    public MonsterMaterial monsterMaterial; 
    [SerializeField]
    private AudioClip getSound;
    [SerializeField]
    private GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //ss = GameObject.Find("ShotShell").GetComponent<ShotShell>();
            //ss.AddShell(reward);
            GameDeter.instance.AddMonsterMaterialList(monsterMaterial);
            //gameObject.SetActive(false);
            Destroy(gameObject);
            //AudioSource.PlayClipAtPoint(getSound, transform.position);
            //GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            //Destroy(effect, 0.5f);
        }
    }
}
