using System;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class LauncherUI : MonoBehaviour
{
   private Button game1Button;
   private Button game2Button;
   private Button game3Button;
   private Button game4Button;
   private Button quit;

   private Text messageText;

   private Transform messageTransform;

   private Process process;
   
   void Awake()
   {
      Application.targetFrameRate = 60; //Change to 30 if getting performance issues
      Application.runInBackground = false;
      
      game1Button = transform.Find("game1Button").GetComponent<Button>();
      game2Button = transform.Find("game2Button").GetComponent<Button>();
      game3Button = transform.Find("game3Button").GetComponent<Button>();
      game4Button = transform.Find("game4Button").GetComponent<Button>();
      quit = transform.Find("Quit").GetComponent<Button>();

      messageText = transform.Find("Message").GetComponent<Text>();

      messageTransform = transform.Find("PlayingMessage");
      messageTransform.gameObject.SetActive(false);

      game1Button.onClick.AddListener(launchGame1);
      game2Button.onClick.AddListener(launchGame2);
      game3Button.onClick.AddListener(launchGame3);
      game4Button.onClick.AddListener(launchGame4);
      quit.onClick.AddListener(Quit);
   }

   public void Quit()
   {
      Application.Quit();
   }
   
   public void launchGame1()
   {
      string path = Application.dataPath + "/../DaniDev/Karlson2D/Karlson.exe";
      process = Process.Start(path);
      ShowPlayingMessage("Karlson 2D is currently running!");
   }
   
   public void launchGame2()
   {
      string path = Application.dataPath + "/../DaniDev/RERUN/RERUN.exe";
      process = Process.Start(path);
      ShowPlayingMessage("RE:RUN is currently running!");
   }
   
   public void launchGame3()
   {
      string path = Application.dataPath + "/../DaniDev/Balls/Balls.exe";
      process = Process.Start(path);
      ShowPlayingMessage("Balls is currently running");
   }
   
   public void launchGame4()
   {
      string path = Application.dataPath + "/../DaniDev/Karlson/Karlson.exe";
      process = Process.Start(path);
      ShowPlayingMessage("Karlson (itch.io) is currently running");
   }

   private void Update()
   {
      if (process.HasExited)
      {
         process = null;
         messageTransform.gameObject.SetActive(false);
      }
   }

   private void ShowPlayingMessage(string message)
   {
      messageTransform.gameObject.SetActive(true);
      messageText.text = message;
   }
}