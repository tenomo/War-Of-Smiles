using UnityEngine;
using System.Collections;

public class GamingMenu : MonoBehaviour
{

    public GameObject GameHandlerObj;
    public Texture2D menu_Texture;
    public Texture2D background_Texture;
    private bool IsVisible;
    private GameHandler gameHandler;

    private int group_width;
    private int group_height;

    private int group_x;
    private int group_y;

    private int box_widht;
    private int box_height;

    private int box_x;
    private int box_y;
    private int draw_point_x;
    private int draw_point_y;
    private int step_y;
    delegate void PerformMethod();
     

    private void Start()
    {
        gameHandler = GameHandlerObj.GetComponent<GameHandler>();
        IsVisible = false;
        InitGlobalData();
    }
    void OnGUI()
    {
        if (gameHandler.statusGame != GameHandler.Status.NormalGame & IsVisible != true)
            DrawFullSceenMenu();
        DrawMenu();
        GUI.Label(new Rect(Screen.width-120, 10, 100, 20),"Points: "+ gameHandler.GamePoints.ToString());

    }
    private void Update()
    {
        Pause();
    }
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameHandler.statusGame = GameHandler.Status.Pause;
            IsVisible = true;
        }
    }

    private void Continue()
    {
        gameHandler.StartGame();

        IsVisible = false;

    }
    private void Replay()
    {
        gameHandler.ReloadLevel();
    }
   // private void goInMenu()
  //  {
   //     Application.LoadLevel("MainMenu");
  //  }
    private void Quit()
    {
        Application.Quit();
    }


    private void InitGlobalData()
    {
        group_width = (int)(Screen.width * 0.2f); // w / 20% (20 ?)
        box_widht = group_width;
        group_x = (Screen.width - group_width) / 2;
        box_x = 0;
        box_y = 0;
        draw_point_x = (int)(box_widht * 0.3f);
    }

    private void DrawMenu()
    {
        if (IsVisible)
        {
            group_height = 300;

            box_height = group_height;
            group_y = (int)(Screen.height / 2 - group_height/2); 
            draw_point_y =  (int) (  box_height  * 0.1f);  

             
            GUI.BeginGroup(new Rect(group_x, group_y, group_width, box_height));
            GUI.DrawTexture(new Rect(box_x, box_y, box_widht, box_height), menu_Texture);
            step_y = draw_point_y;

            string[] names;
            PerformMethod[] methods = new PerformMethod[] { Continue, Replay,  Quit };// { Continue,Replay, goInMenu, Quit };
           
            if (gameHandler.statusGame == GameHandler.Status.Pause)
            {
                names = new string[] { "Continue", "Playe Agin" , "Quit" };//{ "Continue","Playe Agin", "Menu", "Quit" };                 
                DrawButtons(names, methods);
            }
            

            GUI.EndGroup();
        }
    }

    
    private void DrawFullSceenMenu()
    {

        group_height = Screen.height;
        box_height = group_height;
        group_y = 0;
        draw_point_y = (int)(box_height / 2 - (box_height / 2) * 0.1f); // c_y - c_y / 20% 


        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background_Texture);
        GUI.BeginGroup(new Rect(group_x, group_y, group_width, box_height));
        GUI.DrawTexture(new Rect(box_x, box_y, box_widht, box_height), menu_Texture);
        step_y = draw_point_y;

        string[] names;
        PerformMethod[] methods = new PerformMethod[]{ Replay, Quit };// { Replay, goInMenu, Quit };
        string[] texts;
        if (gameHandler.statusGame == GameHandler.Status.Win)
        {
            names = new string[] { "Playe Agin",   "Quit" };
            texts = new string[] { "You Win", "Result: " + gameHandler.GamePoints.ToString() };
            DrawLables(texts);
            DrawButtons(names, methods);
        }
        else if (gameHandler.statusGame == GameHandler.Status.lose)
        {
            names = new string[] { "Try Agin",   "Quit" };
            texts = new string[] { "Game Over", "Result: " + gameHandler.GamePoints.ToString() };
            DrawLables(texts);
            DrawButtons(names, methods);
        }
      

        GUI.EndGroup();
    }


    private void DrawButtons(string[] names, PerformMethod[] methods)
    { 
        if (names.Length == methods.Length)
        {
            for (int i = 0; i < methods.Length; i++)
            {
                Debug.Log("i: "+i);
                if (GUI.Button(new Rect(draw_point_x, step_y, 100, 30), names[i]))
                {
                    methods[i]();
                }
                step_y += 40;
            }
        }
        else
            Debug.LogError("names.Length and  methods.Length must be equal ");
    }
    private void DrawLables(string[] texts)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            GUI.Label(new Rect(draw_point_x, step_y, 100, 20), texts[i]);

            step_y += 30;
        }
    }
     


}



        
    
