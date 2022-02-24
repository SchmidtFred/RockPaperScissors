using System;
using System.Collections.Generic;

int playerScore = 0;
int compScore = 0;
Random randomizer = new Random();

List<string> art = new List<string>() {
    @"
    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)", 
    @"
    _______
---'    ____)____
           ______)
          _______)
         _______)
---.__________)",
    @"
    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)"
};
bool playingStill = true;

while (playingStill) {
    playingStill = Main();
}




bool Main() {
    while (playerScore < 3 && compScore < 3) {
        ShowScore(playerScore, compScore);
        RunGame();
    }
    //display winner
    ShowScore(playerScore, compScore);
    Console.WriteLine($@"{(playerScore == 3 ? "Player" : "Computer")} Wins!
    Play Again? (Y/N)");
    string response = Console.ReadLine().ToLower();
    while (response != "y" && response != "n") {
        Console.WriteLine("Please use Y or N. Play Again? (Y/N)");
        response = Console.ReadLine().ToLower();
    }
    //if play again reset scores and run main
    if (response == "y") {
        compScore = 0;
        playerScore = 0;
        return true;
    } else {
        return false;
    }
}

void ShowScore(int playerScore, int compScore) {
    Console.WriteLine($@"-------------------------
    | Player: {playerScore} | Computer: {compScore} |
    ---------------------");
}

void RunGame() {
    Console.WriteLine(@"What would you like to throw?
    1) Rock
    2) Paper
    3) Scissors");
    string response = Console.ReadLine();
    while (response != "1" && response != "2" && response != "3") {
        Console.WriteLine("Please choose one of the three options.");
        Console.WriteLine(@"What would you like to throw?
        1) Rock
        2) Paper
        3) Scissors");
        response = Console.ReadLine();
    }
    //convert this repsonse to an int for reference with art
    GameResults(int.Parse(response) - 1);
}

void GameResults(int playerResponse) {
    int compChoice = randomizer.Next(3);
    Console.WriteLine($@"{art[playerResponse]}\nvs.\n{art[compChoice]}");
    if (compChoice != playerResponse) {
        // determine results as more mathematical as opposed to a long string of if elses
        if (playerResponse > compChoice) {
            //make sure rock beats scissors
            if (playerResponse == 2 && compChoice == 0) {
                compScore++;
            } else {
                playerScore ++;
            }
        } else {
            //make sure rock beats scissors
            if (playerResponse == 0 && compChoice == 2) {
                playerScore++;
            } else {
                compScore++;
            }
        }
    }
    Console.ReadLine();
    Console.Clear();

}