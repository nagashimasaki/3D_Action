using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SkyboxChanger skyboxChanger;

    void Awake()
    {
        // Skyboxの変更
        skyboxChanger.ChangeSkybox();
    }
}
