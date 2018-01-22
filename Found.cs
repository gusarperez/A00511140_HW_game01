using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Found : MonoBehaviour {

    // Use this for initialization
    //Const and String
    const string menuHint = "Write the menu for the game";
    // Passwords for the levels of the game (String [] LP
    //Clothes store
    string[] LevelP1 = { "t-shirt", "underwear", "skirt", "tie", "pant" };
    //Toy store
    string[] LevelP2 = { "toy cars", "toy soldiers", "toy airplanes", "robots", "video games" };
    //Hospital
    string[] LevelP3 = { "hospital room", "nurses", "doctors", "medicines", "operating room" };
    //Toyota agency 
    string[] LevelP4 = { "corolla", "tundra", "camry", "gt86", "ft-4x" };
    //Bank of america
    string[] LevelP5 = { "dollar", "pound", "coin vault", "gold", "silver" };

    int level;
    //GameState Varibles
    enum GameState { MainMenu, Password, Win};
            GameState currenteScreen= GameState.MainMenu;
    string Password;

    void Start ()
    {
        ShowMainMenu();	
	}
	
	// Update is called once per frame
	void Update () {
    
    }
    
    void ShowMainMenu()
    {
        //Clear the Screen
        Terminal.ClearScreen();
        //Show the menu
        Terminal.WriteLine("Hello stranger, Would you like try of hack this program?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Select 1 for Clothes store");
        Terminal.WriteLine("Select 2 for Toy store");
        Terminal.WriteLine("Select 3 for Hospital");
        Terminal.WriteLine("Select 4 for Toyota Agency");
        Terminal.WriteLine("Select 5 for Bank of america");
        Terminal.WriteLine("Enter your selection");

        currenteScreen = GameState.MainMenu;
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
       else if (input == "quit" || input == "exit" || input == "close") 
        {
            //Revisar
           // Terminal.WriteLine("Plase close the browser's tab");
            Terminal.WriteLine("Exit");
            Application.Quit();
        }
        else if (currenteScreen== GameState.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currenteScreen == GameState.Password)
        {
            CheckPassword(input);
        }
    }
    private void CheckPassword( string input)
    {
        if (input== Password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }
     private void DisplayWinScreen()
    {
        Terminal.ClearScreen();

        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }
    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:Terminal.WriteLine("GOOD!");
                Terminal.WriteLine(@"
╔══════════════╗

      GOOD!

╚══════════════╝
                ");
                break;
            case 2: Terminal.WriteLine("Tank");
                Terminal.WriteLine(@"
░░░░░░███████ ]▄▄▄▄▄▄▄▄▃
▂▄▅█████████▅▄▃▂
I███████████████████].
◥⊙▲⊙▲⊙▲⊙▲⊙▲⊙▲⊙◤... 
                   ");
                break;
            case 3: Terminal.WriteLine("Hospital");
                Terminal.WriteLine(@"
 _                     _ _        _ 
| |                   (_) |      | |
| |__   ___  ___ _ __  _| |_ __ _| |
| '_ \ / _ \/ __| '_ \| | __/ _` | |
| | | | (_) \__ \ |_) | | || (_| | |
|_| |_|\___/|___/ .__/|_|\__\__,_|_|
                | |                 
                |_|                 
                    ");
                break;
            case 4: Terminal.WriteLine("Car");
                Terminal.WriteLine(@"
  ______
 /|_||_\`.__
(   _    _ _\
=`-(_)--(_)-'
                    ");
                break;
            case 5: Terminal.WriteLine("Congratulations!!");
                Terminal.WriteLine(@"
[̲̅$̲̅(̲̅100)̲̅$̲̅]    

[̲̅$̲̅(̲̅5̲̅0)̲̅$̲̅]

[̲̅$̲̅(̲̅5̲̅0)̲̅$̲̅]
");
                Terminal.WriteLine("Welcome to the Bank of America");
                break;
            default:
                Debug.LogError("Invalid level reached.");
                break;
        }
    }
    void RunMainMenu(string input)
    {
        bool isValidInput = (input == "1") || (input == "2") || (input == "3") || (input == "4") || (input == "5");

        if (isValidInput)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "A00")
        {
            Terminal.WriteLine("Please write a correct level");
        }
        else
        {
            Terminal.WriteLine("Enter a valid level");
        }
    }
    private void AskForPassword()
    {
        currenteScreen = GameState.Password;
        Terminal.ClearScreen();
        SetRandomPassword();

        Terminal.WriteLine("Enter your Password. Hint: " + Password.Anagram());
        Terminal.WriteLine(menuHint);

    }
    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                Password = LevelP1[UnityEngine.Random.Range(0, LevelP1.Length)];
                break;
            case 2:
                Password = LevelP2[UnityEngine.Random.Range(0, LevelP2.Length)];
                break;
            case 3:
                Password = LevelP3[UnityEngine.Random.Range(0, LevelP3.Length)];
                break;
            case 4:
                Password = LevelP4[UnityEngine.Random.Range(0, LevelP4.Length)];
                break;
            case 5:
                Password = LevelP5[UnityEngine.Random.Range(0, LevelP5.Length)];
                break;
            default:
                Debug.LogError("Invalid level reached.");
                break;
        }
    }
}

