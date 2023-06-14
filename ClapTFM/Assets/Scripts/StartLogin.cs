using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartLogin : MonoBehaviour
{
    //public TMP_InputField inputField;
    public TMP_Text text;
    private TouchScreenKeyboard overlayKeyboard;
    //public static string inputText = "";
    public GameObject button;
   // OVRCameraRig cameraRig = FindObjectOfType<OVRCameraRig>();
    // Start is called before the first frame update
    void Start()
    {
        //overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    // Update is called once per frame
    void Update()
    {
        if (overlayKeyboard != null)
            text.text = overlayKeyboard.text;
        if (overlayKeyboard != null && overlayKeyboard.status == TouchScreenKeyboard.Status.Done)
        {
            NewUser();
        }
    }
    //public void GetText()
    //{
    //    string text = inputField.text;
    //    Debug.Log("Texto ingresado: " + text);
    //}
    public void NewUser()
    {
        string name = text.text;
        //GameManager.instance.nameUser = name;
        SaveJson.instance.SetData(name, "/participants.json");
        Timer.instance.timerIsRunning = true;
       // overlayKeyboard = null;
        //cameraRig.GetComponent<OVRManager>().
        transform.parent.gameObject.SetActive(false);
    }

    public void ActiveKeyboard()
    {
        overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
    //Crear otro json en el que se guarde una lista de nombres de usuarios y el número de intentos
    //Función que llame al json y mire si existe el nombre y sino lo añade
    //al iniciar, mirar si ya existe el nombre, y cuantos intentos lleva
    //guardar el númerp de intentos en el string 
    
}
