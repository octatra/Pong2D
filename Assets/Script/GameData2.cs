using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData2 : MonoBehaviour
{
    public static GameData2 instace;

    [Header("Prefab")]
    public GameObject BallPrefabSet;


    public bool isSinglePlayer;
    public float gameTimer;

    public void Awake()
    {
        if (instace != null)

            Destroy(gameObject);
        else
            instace = this;

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
