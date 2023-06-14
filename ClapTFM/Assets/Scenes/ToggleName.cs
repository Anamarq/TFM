using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToggleName : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text textPrueba;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelected()
    {
        textPrueba.text = text.text;
        string name = text.text;
        LoginUser.instance.SetNameUser(name);
    }
}
