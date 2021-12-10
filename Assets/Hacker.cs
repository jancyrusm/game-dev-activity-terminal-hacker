using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    const string menuHint = "Type 'menu' anytime to go to the main menu and 'exit' to close the terminal.";
    const string goBackHint = "Type 'back' to go back and try again.";
    const string enterNumber = "Enter a number:";
    const string incorrectPassword = "Incorrect Password, Try Again!";
    //Level 1 - Herbivores (4-5)
    string[] level1Passwords = {"stego", "draco", "allo", "isano", "ankyl"}; 
    //Level 2 - Carnivores (6-7)
    string[] level2Passwords = {"troodon", "tyranno", "shanag", "raptor"}; 
    //Level 3 - Omnivores (8+)
    string[] level3Passwords = {"deinocheirus", "anserimimus", "gallimimus"}; 

    //Game State
    int level;
    enum Screen {MainMenu, Password, Win, Lose}; 
    Screen currentScreen; 
    string password;

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine("     Welcome to Terminal Hacker      "); 
        Terminal.WriteLine("         by OptiPunch Games          ");
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine("  Where would you like to hack into? ");
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine("  Press 1 for Herbivorous Dinosaurs  ");
        Terminal.WriteLine("  Press 2 for Carnivorous Dinosaurs  ");        
        Terminal.WriteLine("  Press 3 for Omnivorous Dinosaurs   ");
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine(enterNumber);
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "exit")
        {
            Application.Quit();
        }
        else if (input == "back")
        {
            AskForPassword();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine("Hint: " + password.Anagram());
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine("Enter your Password:");
    }

    void RunMainMenu(string input)
    {
        bool isvalidlevelNumber = (input == "1" || input == "2" || input == "3");
        if (isvalidlevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "1234567890")
        {
            Terminal.WriteLine("Select a level: ");            
        }
        else
        {
            InvalidNumberScreen();
        }
    }

    void InvalidNumberScreen()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine("Please enter a valid number!");
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("-------------------------------------");
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
            break;
        default:
            Debug.LogError("Invalid level number");
            break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            DisplayLoseScreen();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void DisplayLoseScreen()
    {
        currentScreen = Screen.Lose;
        Terminal.ClearScreen();
        ShowLevelTryAgain();
    }

    void ShowLevelTryAgain()
    {
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine(incorrectPassword);
        Terminal.WriteLine("-------------------------------------");
        Terminal.WriteLine(goBackHint);
        Terminal.WriteLine("-------------------------------------");
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("-------------------------------------");
                Terminal.WriteLine("           ENTRY APPROVED!           ");
                Terminal.WriteLine("-------------------------------------");
                Terminal.WriteLine("    You have succesfully bypassed    ");
                Terminal.WriteLine("            this level!              ");
                Terminal.WriteLine("-------------------------------------");
                Terminal.WriteLine("Type 'menu' to go to the main menu and pass through other levels.");
                Terminal.WriteLine("-------------------------------------");
            break;
            case 2:
                Terminal.WriteLine("-------------------------------------");
                Terminal.WriteLine("           ENTRY APPROVED!           ");
                Terminal.WriteLine("-------------------------------------");
                Terminal.WriteLine(" You've successfully passed through  ");
                Terminal.WriteLine("            this level!              ");
                Terminal.WriteLine("-------------------------------------");
                Terminal.WriteLine("Type 'menu' to go to the main menu and pass through other levels.");
                Terminal.WriteLine("-------------------------------------");
            break;
            case 3:
                Terminal.WriteLine("-------------------------------------");
                Terminal.WriteLine("          CONGRATULATIONS!!!         ");
                Terminal.WriteLine("-------------------------------------");
                Terminal.WriteLine("You have succesfully breached through");
                Terminal.WriteLine("    OptiPunch's Terminal Hacker!     ");
                Terminal.WriteLine("-------------------------------------");
                Terminal.WriteLine("");
                Terminal.WriteLine(menuHint);
            break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
