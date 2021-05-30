using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDeter : MonoBehaviour
{
    public static GameDeter instance;

    public List<MonsterMaterial> monsterMaterialsList = new List<MonsterMaterial>();

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMonsterMaterialList(MonsterMaterial monsterMaterial)
    {
        foreach (MonsterMaterial material in monsterMaterialsList)
        {
            if (material.monsterMaterialTyp == monsterMaterial.monsterMaterialTyp)
            {
                material.materialreward += monsterMaterial.materialreward;
                return;
            }
        }
        monsterMaterialsList.Add(monsterMaterial);
    }
}
