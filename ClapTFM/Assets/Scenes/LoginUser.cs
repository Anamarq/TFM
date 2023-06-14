using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginUser : MonoBehaviour
{
    public GameObject LoginCanvas;
    public GameObject start;
    public GameObject newUser;
    private TouchScreenKeyboard overlayKeyboard;
    public TMP_Text text;
    private string nameUser;

    public static LoginUser instance;
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (overlayKeyboard != null)
            text.text = overlayKeyboard.text;
        if (overlayKeyboard != null && overlayKeyboard.status == TouchScreenKeyboard.Status.Done)
        {
            SetNameUser(text.text);
            LoadScene();
        }
    }

    public void SetNameUser(string newNameUser)
    {
       nameUser = newNameUser;
    }
    public void LoadScene()
    {
        //SaveJson.instance.SaveNamesToJson(nameUser, "/participants.json");
        SaveJson.instance.SetData(nameUser, "/participants.json");
        SceneManager.LoadScene(1);
      //  Timer.instance.timerIsRunning = true;
    }

    public void Login()
    {
        LoginCanvas.SetActive(true);
        start.SetActive(false);
    }
    public void Return()
    {
        LoginCanvas.SetActive(false);
        start.SetActive(true);
    }
    public void NewUser()
    {
        newUser.SetActive(true);
        start.SetActive(false);
        overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
    public void ReadText()
    { 
            //Ponerlo en otro script, que irá en cada toggle. Este script lee el texto y llama a la función newUser que tengo que cambiar para que envíe el nombre usuario
    }
}
