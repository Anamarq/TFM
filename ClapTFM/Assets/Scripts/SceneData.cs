using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    public string nameUser;
    public int totalTries;
    public int extraTime;
    public static SceneData instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject); // Evita que el GameObject se destruya al cambiar de escena
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setData(string name, int total)
    {
        nameUser = name;
        totalTries = total;
        if (total == 0)
            extraTime = 15;
        else
            extraTime = 5;
    }

}
