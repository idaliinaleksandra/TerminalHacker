using UnityEngine;

public class Hacker : MonoBehaviour {

    const string menuHint = "You may type 'menu' to enter the menu";
    string[] level1passwords = {  "book", "library", "shelf" };
    string[] level2passwords = { "police", "station", "handcuffs" };
    string[] level3passwords = { "telescope", "environment", "starfield" };

    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;

    // Use this for initialization
    void Start() {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 = Library");
        Terminal.WriteLine("Press 2 = police station");
        Terminal.WriteLine("Press 3 = NASA");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {

        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

        void RunMainMenu(string input)
        {

        bool isValidNumber = (input == "1" || input == "2" || input == "3");

                if (isValidNumber) {
                    level = int.Parse(input);
                    AskPassword();
                }
                else
                {
                    Terminal.WriteLine("What did you say?");
                }
        }

        private void CheckPassword(string input)
        {
            if (input == password)
        {
            DisplayWinScreen();
        }
        else
            {
            AskPassword();
                Terminal.WriteLine(menuHint);
            }
        }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowReward();
    }

    void ShowReward()
    {
        switch (level) {
            case 1:
                Terminal.WriteLine("Have a book");
                break;
            case 2:
                Terminal.WriteLine("You are arrested!");
                break;
            case 3:
                Terminal.WriteLine("Nasa is here!");
                break;
            default:
                Debug.LogError("What is this?");
                break;
            }
    }

    private void AskPassword()
        {
            currentScreen = Screen.Password;
            Terminal.ClearScreen();

        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
            Terminal.WriteLine("Please enter your password: ");
        Terminal.WriteLine("Hint: " + password.Anagram() );
    }

    }
