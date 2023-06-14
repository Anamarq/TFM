using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //  private Vector3 respawnPos;
    //   private Quaternion respawnRot;
    //public GameObject glass;
    //public GameObject tmp;
  //  public UIManager[] canvas;
    
    public GameObject[] levels;
    public int nlev;
    public string nameUser;
    public string totalTries;
    public GameObject diagrams;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        nlev = 0;
        //respawnPos = GlassController.instance.transform.position;
        //respawnRot = GlassController.instance.transform.rotation;
        for (int i = 1; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        nameUser = SceneData.instance.nameUser;
        totalTries = SceneData.instance.totalTries.ToString("0");
       // Timer.instance.timeRemaining += SceneData.instance.extraTime;
    }

    // Update is called once per frame
    void Update()
    {
        //if(newGlass == true)
        //{
        //    Instantiate(glass, respawnPos, respawnRot);
        //    newGlass = false;
        //}

    }

    public void Finish()
    {

        levels[nlev].GetComponent<FadeOut>().StartFading();
        //Fading.instance.Fade(levels[nlev].GetComponent<Renderer>());
        //levels[nlev].SetActive(false);
        string path = "/" + nameUser + totalTries + ".json";
        if (nlev == 0)
            SaveJson.instance.SaveToJson(ChangeGlass.instance.pointGlass.ToString(), path);
        else if (nlev == 1)
            SaveJson.instance.SaveToJson( ChangeWok.instance.points.ToString(), path);
        else if (nlev == 2)
            SaveJson.instance.SaveToJson( DrinkGlass.instance.nDrink.ToString(), path);
        else if (nlev == 3) 
            SaveJson.instance.SaveToJson(CapPoints.instance.points.ToString(), path);
        else if (nlev == 4)
            SaveJson.instance.SaveToJson(ChangeBasket.instance.nbasket.ToString(), path);
        else if (nlev == 5)
            SaveJson.instance.SaveToJson(ColorsShelfPoints.instance.points.ToString(), path);
        else if (nlev == 6)
            SaveJson.instance.SaveToJson(FaucetController.instance.nfaucet.ToString(), path);
        else if (nlev == 7)
            SaveJson.instance.SaveToJson(OvenController.instance.nOven.ToString(), path);
        ++nlev;
        if (nlev < levels.Length)
        {
            levels[nlev].SetActive(true);
            ChangeCanvas.instance.changeCanvas(nlev);
            levels[nlev].GetComponent<FadeOut>().StartActivate();
            Timer.instance.Restart();
        }
        else
        {
            SaveJson.instance.SaveNamesToJson(nameUser, SceneData.instance.totalTries, "/participants.json");
            diagrams.SetActive(true);
            DiagramController.instance.LoadDiagrams();
           // Application.Quit();
        }
       // FadeOut.instance.StartActivate();

    }
    //public void Restart()
    //{
    //  //  SceneManager.LoadScene("TFM");
    //    Timer.instance.timeRemaining = 60;
    //    ChangeGlass.instance.ResetPos();
    //}
    //public void changeCanvas(string valor)
    //{
    //    for (int i = 0; i < canvas.Length; i++)
    //    {
    //        canvas[i].numActions.text = valor;
    //    }
    //}

}
