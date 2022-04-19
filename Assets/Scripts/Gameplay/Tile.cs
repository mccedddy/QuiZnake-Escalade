using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile
{  
    // Fields
    public static string question = "";
    public static string riddle = "";
    public static string answer = "";
    public static string tileStepped = "";
    public static bool isSliding = false;
    public static bool isClimbing = false;

    public static void CheckTile(int tileNumber)
    {
        // Board Layout
        // Stage 1
        if (GameControl.stage == "1")
        {
            // Reward Tile
            if (tileNumber == 7 || tileNumber == 14 || tileNumber == 20 || tileNumber == 31)
            {
                Reward(tileNumber);
            }

            // Consequence Tile
            if (tileNumber == 4 || tileNumber == 11 || tileNumber == 35 || tileNumber == 27)
            {
                Consequence(Random.Range(0, 2), Random.Range(1, 9), Random.Range(0, 4));
            }

            // Question Tile
            if (tileNumber == 6 || tileNumber == 10 || tileNumber == 12 ||
                tileNumber == 19 || tileNumber == 23 || tileNumber == 33)
            {
                Question(Random.Range(1, 7));
            }

            // Ladders
            if (tileNumber == 3)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(15);
            }
            if (tileNumber == 13)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(23);
            }
            if (tileNumber == 18)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(29);
            }

            // Snakes
            if (tileNumber == 28)
            {
                isSliding = true;
                GameControl.ClimbPlayer(12);
            }
            if (tileNumber == 30)
            {
                isSliding = true;
                GameControl.ClimbPlayer(8);
            }

            if (tileNumber == 16 || tileNumber == 24)
                RedSnake();
        }
        // Stage 2
        if (GameControl.stage == "2")
        {
            // Reward Tile
            if (tileNumber == 2 || tileNumber == 24 || tileNumber == 33 || 
                tileNumber == 44 || tileNumber == 50 || tileNumber == 57)
                Reward(tileNumber);

            // Consequence Tile
            if (tileNumber == 4 || tileNumber == 11 || tileNumber == 18 || 
                tileNumber == 29 || tileNumber == 39 || tileNumber == 46)
                Consequence(Random.Range(0, 2), Random.Range(1, 15), Random.Range(0,6));

            // Question Tile
            if (tileNumber == 3 || tileNumber == 6 || tileNumber == 9 || tileNumber == 20 ||
                tileNumber == 27 || tileNumber == 35 || tileNumber == 42 ||
                tileNumber == 49 || tileNumber == 54 || tileNumber == 61)
                Question(Random.Range(1, 11));

            // Ladders
            if (tileNumber == 13)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(21);
            }
            if (tileNumber == 15)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(30);
            }
            if (tileNumber == 26)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(43);
            }
            if (tileNumber == 36)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(44);
            }
            if (tileNumber == 48)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(49);
            }

            // Snakes
            if (tileNumber == 38)
            {
                isSliding = true;
                GameControl.ClimbPlayer(22);
            }
            if (tileNumber == 19)
            {
                isSliding = true;
                GameControl.ClimbPlayer(5);
            }

            if (tileNumber == 10 || tileNumber == 32 || tileNumber == 60)
                RedSnake();
        }
        // Stage 2
        if (GameControl.stage == "3")
        {
            // Reward Tile
            if (tileNumber == 6 || tileNumber == 27 || tileNumber == 37 || tileNumber == 57 ||
                tileNumber == 73 || tileNumber == 80 || tileNumber == 86 || tileNumber == 91)
                Reward(tileNumber);

            // Consequence Tile
            if (tileNumber == 3 || tileNumber == 16 || tileNumber == 40 ||
                tileNumber == 50 || tileNumber == 68 || tileNumber == 96)
                Consequence(Random.Range(0, 2), Random.Range(1, 18), Random.Range(0, 6));

            // Question Tile
            if (tileNumber == 5 || tileNumber == 22 || tileNumber == 30 || tileNumber == 44 ||
                tileNumber == 46 || tileNumber == 55 || tileNumber == 60 || tileNumber == 63 ||
                tileNumber == 75 || tileNumber == 76 || tileNumber == 83 || tileNumber == 94 ||
                tileNumber == 98)
                Question(Random.Range(1, 14));

            // Ladders
            if (tileNumber == 2)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(19);
            }
            if (tileNumber == 10)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(14);
            }
            if (tileNumber == 24)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(26);
            }
            if (tileNumber == 34)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(53);
            }
            if (tileNumber == 56)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(64);
            }
            if (tileNumber == 88)
            {
                isClimbing = true;
                GameControl.ClimbPlayer(93);
            }

            // Snakes
            if (tileNumber == 41)
            {
                isSliding = true;
                GameControl.ClimbPlayer(39);
            }
            if (tileNumber == 45)
            {
                isSliding = true;
                GameControl.ClimbPlayer(25);
            }
            if (tileNumber == 67)
            {
                isSliding = true;
                GameControl.ClimbPlayer(33);
            }
            if (tileNumber == 95)
            {
                isSliding = true;
                GameControl.ClimbPlayer(84);
            }

            if (tileNumber == 13 || tileNumber == 71 || tileNumber == 77)
                RedSnake();
        }
    }
    public static void Reward(int tileNumber)
    {
        Dice.clickable = false;
        Popup.popUpCanvas.enabled = true;
        Popup.inputEnabled(false);
        Popup.popUpTitle.text = "Reward Tile";
        GameControl.SFX_Reward.GetComponent<AudioSource>().Play();

        // Stage 1
        if (GameControl.stage == "1" && GameControl.difficulty == "easy")
        {
            switch (tileNumber)
            {
                case 7:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +4 Coin";
                    Coins.AddCoin(4);
                    break;
                case 14:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Coin";
                    Coins.AddCoin(1);
                    break;
                case 20:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 4 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 4);
                    break;
                case 31:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
            }
        }
        if (GameControl.stage == "1" && GameControl.difficulty == "medium")
        {
            switch (tileNumber)
            {
                case 7:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 14:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +5 Coins";
                    Coins.AddCoin(5);
                    break;
                case 20:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 4 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 4);
                    break;
                case 31:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
            }
        }
        if (GameControl.stage == "1" && GameControl.difficulty == "hard")
        {
            switch (tileNumber)
            {
                case 7:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 14:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +2 Heart";
                    GameControl.heart = GameControl.heart + 2;
                    break;
                case 20:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +7 Coins";
                    Coins.AddCoin(7);
                    break;
                case 31:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 2 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 2);
                    break;
            }
        }
        // Stage 2
        if (GameControl.stage == "2" && GameControl.difficulty == "easy")
        {
            switch (tileNumber)
            {
                case 2:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 3 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 3);
                    break;
                case 24:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +5 Coins";
                    Coins.AddCoin(5);
                    break;
                case 33:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 44:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +2 Coins";
                    Coins.AddCoin(2);
                    break;
                case 50:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 57:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 4 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 4);
                    break;
            }
        }
        if (GameControl.stage == "2" && GameControl.difficulty == "medium")
        {
            switch (tileNumber)
            {
                case 2:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 24:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 3 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 3);
                    break;
                case 33:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 5 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 5);
                    break;
                case 44:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +2 Hearts";
                    GameControl.heart = GameControl.heart + 2;
                    break;
                case 50:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +8 Coins";
                    Coins.AddCoin(8);
                    break;
                case 57:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +2 Coin";
                    Coins.AddCoin(2);
                    break;
            }
        }
        if (GameControl.stage == "2" && GameControl.difficulty == "hard")
        {
            switch (tileNumber)
            {
                case 2:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 24:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 5 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 5);
                    break;
                case 33:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 3 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 3);
                    break;
                case 44:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +2 Hearts";
                    GameControl.heart = GameControl.heart + 2;
                    break;
                case 50:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 57:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +10 Coins";
                    Coins.AddCoin(10);
                    break;
            }
        }
        // Stage 3
        if (GameControl.stage == "3" && GameControl.difficulty == "easy")
        {
            switch (tileNumber)
            {
                case 6:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +2 Coins";
                    Coins.AddCoin(2);
                    break;
                case 27:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +6 Coins";
                    Coins.AddCoin(6);
                    break;
                case 37:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 57:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +2 Hearts";
                    GameControl.heart = GameControl.heart + 2;
                    break;
                case 73:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 3 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 3);
                    break;
                case 80:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 5 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 5);
                    break;
                case 86:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 2 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 2);
                    break;
                case 91:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +9 Coins";
                    Coins.AddCoin(9);
                    break;
            }
        }
        if (GameControl.stage == "3" && GameControl.difficulty == "medium")
        {
            switch (tileNumber)
            {
                case 6:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 27:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 2 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 2);
                    break;
                case 37:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 7 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 7);
                    break;
                case 57:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 73:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 5 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 5);
                    break;
                case 80:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +2 Hearts";
                    GameControl.heart = GameControl.heart + 2;
                    break;
                case 86:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +7 Coins";
                    Coins.AddCoin(7);
                    break;
                case 91:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +5 Coins";
                    Coins.AddCoin(5);
                    break;
            }
        }
        if (GameControl.stage == "3" && GameControl.difficulty == "hard")
        {
            switch (tileNumber)
            {
                case 6:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 10 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 10);
                    break;
                case 27:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 5 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 5);
                    break;
                case 37:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n Move 4 tiles forward";
                    GameControl.ClimbPlayer(GameControl.player1Position + 4);
                    break;
                case 57:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 73:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +1 Heart";
                    GameControl.heart = GameControl.heart + 1;
                    break;
                case 80:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +2 Hearts";
                    GameControl.heart = GameControl.heart + 2;
                    break;
                case 86:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +9 Coins";
                    Coins.AddCoin(9);
                    break;
                case 91:
                    Popup.popUpText.text = "Congratulations! You received a reward!\n +7 Coins";
                    Coins.AddCoin(7);
                    break;
            }
        }
    }
    public static void Consequence(int effect, int riddleNumber, int moveBackTiles)
    {
        // Riddle
        if (effect == 0)
        {
            GameControl.SFX_Question.GetComponent<AudioSource>().Play();
            // Stage 1
            if (GameControl.stage == "1")
            {
                switch (riddleNumber)
                {
                    case 1:
                        riddle = "If I drink, I die. If I eat, I am fine. What am I? (4 letters)";
                        answer = "fire";
                        break;
                    case 2:
                        riddle = "You are my brother, but I am not your brother. What am I? (6 letters)";
                        answer = "sister";
                        break;
                    case 3:
                        riddle = "I am a color that you can eat, what am I ? (6 letters)";
                        answer = "orange";
                        break;
                    case 4:
                        riddle = "Cloud is my mother. Wind is my father. I come down but never go up. What am I? (4 letters)";
                        answer = "rain";
                        break;
                    case 5:
                        riddle = "A body part pronounced as one letter, but written with three. (Uses two different letters only)";
                        answer = "eye";
                        break;
                    case 6:
                        riddle = "I begin with your sentences, what am I? (7 letters)";
                        answer = "capital";
                        break;
                    case 7:
                        riddle = "I shrink smaller every time I take a bath. What am I? (4 letters)";
                        answer = "soap";
                        break;
                    case 8:
                        riddle = "I repeat the word you say. The more I repeat, the softer I get. I cannot be seen, but can be heard. What am I? (4 letters)";
                        answer = "echo";
                        break;
                }
            }
            // Stage 2
            if (GameControl.stage == "2")
            {
                switch (riddleNumber)
                {
                    case 1:
                        riddle = "I start with “e” end with “e”, I have whole countries inside me. What am I?";
                        answer = "europe";
                        break;
                    case 2:
                        riddle = "What is astronaut’s favorite key on keyboard?";
                        answer = "space";
                        break;
                    case 3:
                        riddle = "I sleep by day, I fly by night. I have no feathers to aid my flight. What am I?";
                        answer = "bat";
                        break;
                    case 4:
                        riddle = "am easy to waste. I am unstoppable. What am I? (12 noon)";
                        answer = "time";
                        break;
                    case 5:
                        riddle = "What building has the most stories?";
                        answer = "library";
                        break;
                    case 6:
                        riddle = "Has teeth but no mouth (tool)";
                        answer = "saw";
                        break;
                    case 7:
                        riddle = "I belong to you, but others use me more often than you do. What am I?";
                        answer = "name";
                        break;
                    case 8:
                        riddle = "What has a head and a tail, but no body or legs?(use to avail, singular)";
                        answer = "coin";
                        break;
                    case 9:
                        riddle = "What starts with “t”, filled with “t” and ends in “t”?";
                        answer = "teapot";
                        break;
                    case 10:
                        riddle = "I have a face and two hands, but I have no arms or legs. Six plus seven is one. What am I?";
                        answer = "clock";
                        break;
                    case 11:
                        riddle = "They come out at night without being called. They are lost in the day without being stolen. What are they ? ";
                        answer = "stars";
                        break;
                    case 12:
                        riddle = "What comes in may different sizes but always only one foot long? (wearable, singular)";
                        answer = "show";
                        break;
                    case 13:
                        riddle = "I am an odd number, take away one letter and I become even. What number am I?";
                        answer = "seven";
                        break;
                    case 14:
                        riddle = "I can be cracked, made, told, and played. What am I? (Just kidding, singular)";
                        answer = "joke";
                        break;
                }
            }
            // Stage 3
            if (GameControl.stage == "3")
            {
                switch (riddleNumber)
                {
                    case 1:
                        riddle = "You hold my tail while I fish for you. What am I?";
                        answer = "net";
                        break;
                    case 2:
                        riddle = "I’m an animal. I love marching. I always wear tuxedo. What am I?";
                        answer = "penguin";
                        break;
                    case 3:
                        riddle = "Tuesday, Sam and Peter went to a restaurant. After eating lunch, they paid the bill. Sam and Peter did not pay, who did ? ";
                        answer = "tuesday";
                        break;
                    case 4:
                        riddle = "What can hold a car but can’t lift a feather?";
                        answer = "garage";
                        break;
                    case 5:
                        riddle = "What starts with “P” and ends with “orn” and is really popular in the movie industry?";
                        answer = "popcorn";
                        break;
                    case 6:
                        riddle = "I have four fingers and a thumb, but I’m not living. What am I?";
                        answer = "glove";
                        break;
                    case 7:
                        riddle = "What word begins and ends with an E, but only has one letter?";
                        answer = "envelope";
                        break;
                    case 8:
                        riddle = "What kind of room has no doors or windows?";
                        answer = "mushroom";
                        break;
                    case 9:
                        riddle = "What is so delicate that saying its name breaks it?";
                        answer = "silence";
                        break;
                    case 10:
                        riddle = "What invention lets you look right through a wall?";
                        answer = "window";
                        break;
                    case 11:
                        riddle = "Tear one off and scratch its head. What was red is black instead. What is it?";
                        answer = "match";
                        break;
                    case 12:
                        riddle = "What is full of holes but still holds water?";
                        answer = "sponge";
                        break;
                    case 13:
                        riddle = "What kind of tree can you carry in your hand?";
                        answer = "palm";
                        break;
                    case 14:
                        riddle = "What can you catch but not throw?";
                        answer = "cold";
                        break;
                    case 15:
                        riddle = "The more it dries, the wetter it becomes. What is it?";
                        answer = "towel";
                        break;
                    case 16:
                        riddle = "Roast, boast, coast, post. What do you put in a toaster?";
                        answer = "bread";
                        break;
                    case 17:
                        riddle = "What gets bigger the more you take away from it?";
                        answer = "hole";
                        break;
                }
            }

            Popup.inputEnabled(true);
            Popup.popUpText.text = "Answer the riddle!\n" + riddle;
        }

        // Move back
        if (effect == 1)
        {
            GameControl.SFX_Defeat.GetComponent<AudioSource>().Play();
            // Stage 1
            if (GameControl.stage == "1" && GameControl.difficulty == "easy")
            {
                if (GameControl.player1Position == 4)
                {
                    Popup.popUpText.text = "Move 2 tiles back";
                    GameControl.ClimbPlayer(GameControl.player1Position - 2);
                }
                else
                {
                    switch (moveBackTiles)
                    {
                        case 0:
                            Popup.popUpText.text = "Move 3 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 3);
                            break;
                        case 1:
                            Popup.popUpText.text = "Move 2 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 2);
                            break;
                        case 2:
                            Popup.popUpText.text = "Move 4 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 4);
                            break;
                        case 3:
                            Popup.popUpText.text = "Move 3 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 3);
                            break;
                    }
                }
            }
            if (GameControl.stage == "1" && GameControl.difficulty == "medium")
            {
                if (GameControl.player1Position == 4)
                {
                    Popup.popUpText.text = "Move 2 tiles back";
                    GameControl.ClimbPlayer(GameControl.player1Position - 2);
                }
                else
                {
                    switch (moveBackTiles)
                    {
                        case 0:
                            Popup.popUpText.text = "Move 3 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 3);
                            break;
                        case 1:
                            Popup.popUpText.text = "Move 7 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 7);
                            break;
                        case 2:
                            Popup.popUpText.text = "Move 4 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 4);
                            break;
                        case 3:
                            Popup.popUpText.text = "Move 5 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 5);
                            break;
                    }
                }
            }
            if (GameControl.stage == "1" && GameControl.difficulty == "hard")
            {
                if (GameControl.player1Position == 4)
                {
                    Popup.popUpText.text = "Move 2 tiles back";
                    GameControl.ClimbPlayer(GameControl.player1Position - 2);
                }
                else
                {
                    switch (moveBackTiles)
                    {
                        case 0:
                            Popup.popUpText.text = "Move 5 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 5);
                            break;
                        case 1:
                            Popup.popUpText.text = "Move 8 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 8);
                            break;
                        case 2:
                            Popup.popUpText.text = "Move 7 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 7);
                            break;
                        case 3:
                            Popup.popUpText.text = "Move 9 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 9);
                            break;
                    }
                }
            }

            // Stage 2
            if (GameControl.stage == "2" && GameControl.difficulty == "easy")
            {
                if (GameControl.player1Position == 4)
                {
                    Popup.popUpText.text = "Move 2 tiles back";
                    GameControl.ClimbPlayer(GameControl.player1Position - 2);
                }
                else
                {
                    switch (moveBackTiles)
                    {
                        case 0:
                            Popup.popUpText.text = "Move 2 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 2);
                            break;
                        case 1:
                            Popup.popUpText.text = "Move 3 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 3);
                            break;
                        case 2:
                            Popup.popUpText.text = "Move 3 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 3);
                            break;
                        case 3:
                            Popup.popUpText.text = "Move 4 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 4);
                            break;
                        case 4:
                            Popup.popUpText.text = "Move 5 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 5);
                            break;
                        case 5:
                            Popup.popUpText.text = "Move 6 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 6);
                            break;
                    }
                }
            }
            if (GameControl.stage == "2" && GameControl.difficulty == "medium")
            {
                if (GameControl.player1Position == 4)
                {
                    Popup.popUpText.text = "Move 2 tiles back";
                    GameControl.ClimbPlayer(GameControl.player1Position - 2);
                }
                else
                {
                    switch (moveBackTiles)
                    {
                        case 0:
                            Popup.popUpText.text = "Move 4 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 4);
                            break;
                        case 1:
                            Popup.popUpText.text = "Move 3 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 3);
                            break;
                        case 2:
                            Popup.popUpText.text = "Move 3 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 3);
                            break;
                        case 3:
                            Popup.popUpText.text = "Move 5 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 5);
                            break;
                        case 4:
                            Popup.popUpText.text = "Move 6 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 6);
                            break;
                        case 5:
                            Popup.popUpText.text = "Move 7 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 7);
                            break;
                    }
                }
            }
            if (GameControl.stage == "2" && GameControl.difficulty == "hard")
            {
                if (GameControl.player1Position == 4)
                {
                    Popup.popUpText.text = "Move 2 tiles back";
                    GameControl.ClimbPlayer(GameControl.player1Position - 2);
                }
                else
                {
                    switch (moveBackTiles)
                    {
                        case 0:
                            Popup.popUpText.text = "Move 5 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 5);
                            break;
                        case 1:
                            Popup.popUpText.text = "Move 6 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 6);
                            break;
                        case 2:
                            Popup.popUpText.text = "Move 7 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 7);
                            break;
                        case 3:
                            Popup.popUpText.text = "Move 8 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 8);
                            break;
                        case 4:
                            Popup.popUpText.text = "Move 9 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 9);
                            break;
                        case 5:
                            Popup.popUpText.text = "Move 10 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 10);
                            break;
                    }
                }
            }

            // Stage 3
            if (GameControl.stage == "3" && GameControl.difficulty == "easy")
            {
                if (GameControl.player1Position == 3)
                {
                    Popup.popUpText.text = "Move 2 tiles back";
                    GameControl.ClimbPlayer(GameControl.player1Position - 2);
                }
                else
                {
                    switch (moveBackTiles)
                    {
                        case 0:
                            Popup.popUpText.text = "Move 9 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 9);
                            break;
                        case 1:
                            Popup.popUpText.text = "Move 7 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 7);
                            break;
                        case 2:
                            Popup.popUpText.text = "Move 7 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 7);
                            break;
                        case 3:
                            Popup.popUpText.text = "Move 8 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 8);
                            break;
                        case 4:
                            Popup.popUpText.text = "Move 5 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 5);
                            break;
                        case 5:
                            Popup.popUpText.text = "Move 6 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 6);
                            break;
                    }
                }
            }
            if (GameControl.stage == "3" && GameControl.difficulty == "medium")
            {
                if (GameControl.player1Position == 3)
                {
                    Popup.popUpText.text = "Move 2 tiles back";
                    GameControl.ClimbPlayer(GameControl.player1Position - 2);
                }
                else
                {
                    switch (moveBackTiles)
                    {
                        case 0:
                            Popup.popUpText.text = "Move 9 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 9);
                            break;
                        case 1:
                            Popup.popUpText.text = "Move 7 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 7);
                            break;
                        case 2:
                            Popup.popUpText.text = "Move 7 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 7);
                            break;
                        case 3:
                            Popup.popUpText.text = "Move 8 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 8);
                            break;
                        case 4:
                            Popup.popUpText.text = "Move 10 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 10);
                            break;
                        case 5:
                            Popup.popUpText.text = "Move 6 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 6);
                            break;
                    }
                }
            }
            if (GameControl.stage == "3" && GameControl.difficulty == "hard")
            {
                if (GameControl.player1Position == 3)
                {
                    Popup.popUpText.text = "Move 2 tiles back";
                    GameControl.ClimbPlayer(GameControl.player1Position - 2);
                }
                else
                {
                    switch (moveBackTiles)
                    {
                        case 0:
                            Popup.popUpText.text = "Move 12 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 12);
                            break;
                        case 1:
                            Popup.popUpText.text = "Move 10 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 10);
                            break;
                        case 2:
                            Popup.popUpText.text = "Move 7 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 7);
                            break;
                        case 3:
                            Popup.popUpText.text = "Move 8 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 8);
                            break;
                        case 4:
                            Popup.popUpText.text = "Move 5 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 5);
                            break;
                        case 5:
                            Popup.popUpText.text = "Move 6 tiles back";
                            GameControl.ClimbPlayer(GameControl.player1Position - 6);
                            break;
                    }
                }
            }

        }

        Dice.clickable = false;
        Popup.popUpCanvas.enabled = true;
        Popup.popUpTitle.text = "Consequence Tile";
        tileStepped = "consequence";
    }
    public static void Question(int questionNumber)
    {
        GameControl.SFX_Question.GetComponent<AudioSource>().Play();
        // Stage 1
        // Easy
        if (GameControl.stage == "1" && GameControl.difficulty == "easy")
        {
            switch (questionNumber)
            {
                case 1:
                    question = "What is the missing layer of the earth? Crust, Mantle, ____";
                    answer = "core";
                    break;
                case 2:
                    question = "Is 0 the smallest even number? yes or no?";
                    answer = "yes";
                    break;
                case 3:
                    question = "Is it right to stab your classmate in the eyes even if she is not doing anything wrong to you? yes or no?";
                    answer = "no";
                    break;
                case 4:
                    question = "(Analogy) Friendly: kind, mean: agg___ (type the full word)";
                    answer = "aggressive";
                    break;
                case 5:
                    question = "(Analogy) Plus: addition, minus: ____ (type the full word";
                    answer = "subtraction";
                    break;
                case 6:
                    question = "The 90 degree angle is also called ___ angle.";
                    answer = "right";
                    break;
            }
        }
        // Medium
        if (GameControl.stage == "1" && GameControl.difficulty == "medium")
        {
            switch (questionNumber)
            {
                case 1:
                    question = "What is the GCF (Greatest Common Factor) of 30 and 12?";
                    answer = "6";
                    break;
                case 2:
                    question = "What will be the new value of 176 if it is rounded to the nearest tens?";
                    answer = "180";
                    break;
                case 3:
                    question = "Adding it to the beginning of one word changes it into another word (such as behave into misbehave). It starts with p and ends with x.";
                    answer = "prefix";
                    break;
                case 4:
                    question = "What is the name of our galaxy";
                    answer = "milky way";
                    break;
                case 5:
                    question = "Among the seven continents, which continent does Philippine belong to?";
                    answer = "asia";
                    break;
                case 6:
                    question = "What is the largest organ of the human body? It is composed of 3 parts: Epidermis, Dermis, and Hypodermis.";
                    answer = "skin";
                    break;
            }
        }
        // Hard
        if (GameControl.stage == "1" && GameControl.difficulty == "hard")
        {
            switch (questionNumber)
            {
                case 1:
                    question = "What is the second element in the periodic table? Element symbol is not considered.";
                    answer = "helium";
                    break;
                case 2:
                    question = "Fear of spiders is called?";
                    answer = "arachnophobia";
                    break;
                case 3:
                    question = "Type of research that focuses on the objective side of the research topic, using numbers as the means to support their findings.";
                    answer = "quantitative";
                    break;
                case 4:
                    question = "ax2+bx+c=0 is called the standard form of what? (Two words, starting with “Q” and “E”)";
                    answer = "quadratic equation";
                    break;
                case 5:
                    question = "What is the atomic number of hydrogen?";
                    answer = "1";
                    break;
                case 6:
                    question = "In x^2+6=15, find the value of x using algebraic method.";
                    answer = "3";
                    break;
            }
        }
        // Stage 2
        // Easy
        if (GameControl.stage == "2" && GameControl.difficulty == "easy")
        {
            switch (questionNumber)
            {
                case 1:
                    question = "He is the sixth President of the Philippines after Manuel Roxas. His initials are E and Q.";
                    answer = "elpidio quirino";
                    break;
                case 2:
                    question = "What is the largest Ocean in the world?";
                    answer = "pacific ocean";
                    break;
                case 3:
                    question = "Every how many years does leap year happens?";
                    answer = "4";
                    break;
                case 4:
                    question = "An instrument used to see stars is called:";
                    answer = "telescope";
                    break;
                case 5:
                    question = "Average number of human milk teeth is:";
                    answer = "20";
                    break;
                case 6:
                    question = "What do you call a word that can be pronounced in two ways? (Starts with H and ends with s , 10 letters)";
                    answer = "heteronyms";
                    break;
                case 7:
                    question = "How many days are in a leap year?";
                    answer = "366";
                    break;
                case 8:
                    question = "The first animal on the moon is:___(man’s best friend)";
                    answer = "dog";
                    break;
                case 9:
                    question = "How many countries are in the world? (less than 200 but greater than 190)";
                    answer = "195";
                    break;
                case 10:
                    question = "The first man to walk on the moon is?";
                    answer = "neil armstrong";
                    break;
            }
        }
        // Medium
        if (GameControl.stage == "2" && GameControl.difficulty == "medium")
        {
            switch (questionNumber)
            {
                case 1:
                    question = "Green pigment responsible for capturing light energy during photosynthesis?";
                    answer = "chlorophyll";
                    break;
                case 2:
                    question = "What is Newton's First Law of motion?";
                    answer = "law of inertia";
                    break;
                case 3:
                    question = "Where is Taj Mahal located?";
                    answer = "india";
                    break;
                case 4:
                    question = "The basic unit of life is _____. (singular)";
                    answer = "cell";
                    break;
                case 5:
                    question = "Adverb of manner answers the question “____?”";
                    answer = "how";
                    break;
                case 6:
                    question = "This mixture’s composition is uniform all throughout, what is it called? (Ends with ‘ous’)";
                    answer = "homogeneous";
                    break;
                case 7:
                    question = "Is the sentence correct? I am more prettier than my classmate. (yes or no)";
                    answer = "no";
                    break;
                case 8:
                    question = "It serves as the control center of the cell.";
                    answer = "nucleus";
                    break;
                case 9:
                    question = "A historical event spearheaded by Adolf Hitler that killed around 6 million European Jews during WWII. (Starts with h)";
                    answer = "holocaust";
                    break;
                case 10:
                    question = "What did Marie and Pierre Currie discovered in 1898? (An element with atomic number of 88)";
                    answer = "radium";
                    break;
            }
        }
        // Hard
        if (GameControl.stage == "2" && GameControl.difficulty == "hard")
        {
            switch (questionNumber)
            {
                case 1:
                    question = "In the sentence “____shoe is this?” Which should be used; whose or who’s?";
                    answer = "whose";
                    break;
                case 2:
                    question = "This group of elements in the periodic table are man-made, they are referred to as ____ elements.";
                    answer = "synthetic";
                    break;
                case 3:
                    question = "If a ruler is 12 inches long, equivalent to 1 foot; and a yard is 3 feet. How many yards are there in 12 feet ?";
                    answer = "4";
                    break;
                case 4:
                    question = "It is a term that is used to persuade someone forcefully to do something that they are unwilling to do, what term is it ? (Starts with C, ends with e)";
                    answer = "coerce";
                    break;
                case 5:
                    question = "When the Philippines is at ____, the Philippine flag is hoisted upside down. (Historical event, 3 letter word)";
                    answer = "war";
                    break;
                case 6:
                    question = "This is a process where heat is being absorbed, what is it called? (Ends with “mic”)";
                    answer = "endothermic";
                    break;
                case 7:
                    question = "What mountain in the Philippines erupted on June 15,1911? (Its name is close with ‘sugar cane’, include ‘Mt.’ before the actual name)";
                    answer = "mt. pinatubo";
                    break;
                case 8:
                    question = "What is the acronym for “Kataas-taasang, kagalang-galangang, Katipunan ng mga Anak ng Bayan”?";
                    answer = "kkk";
                    break;
                case 9:
                    question = "Number of human heart chambers?";
                    answer = "4";
                    break;
                case 10:
                    question = "Gas giant is also called as ____ planets. (6 letter word, starts with J and ends with n)";
                    answer = "jovian";
                    break;
            }
        }
        // Stage 3
        // Easy
        if (GameControl.stage == "3" && GameControl.difficulty == "easy")
        {
            switch (questionNumber)
            {
                case 1:
                    question = "What is the most abundant element on earth?";
                    answer = "oxygen";
                    break;
                case 2:
                    question = "What type of instrument is a guitar? (percussion, string, brass, woodwind)";
                    answer = "string";
                    break;
                case 3:
                    question = "How many strings does a ukulele instrument have?";
                    answer = "4";
                    break;
                case 4:
                    question = "Refers to the ability of the joints to move through a full range of motion: ______";
                    answer = "flexibility";
                    break;
                case 5:
                    question = "cats:____; dove:aerial";
                    answer = "land";
                    break;
                case 6:
                    question = "How many vegetables are there in the song “Bahay-kubo”?";
                    answer = "17";
                    break;
                case 7:
                    question = "What does B stands in ROYGBIV colors?";
                    answer = "blue";
                    break;
                case 8:
                    question = "Which part of Asia are large rainforests located?";
                    answer = "southeast";
                    break;
                case 9:
                    question = "How many stars are there on the Philippine Flag?";
                    answer = "3";
                    break;
                case 10:
                    question = "What is the national flower of the Philippines?";
                    answer = "sampaguita";
                    break;
                case 11:
                    question = "These are lands that receive less than ten inches of rainfall a year and where a little vegetation grows.";
                    answer = "desert";
                    break;
                case 12:
                    question = "State whether true or false. Rape can only happen to females.";
                    answer = "false";
                    break;
                case 13:
                    question = "Another indoor alternative recreation for those who enjoy the beat of rhythm and movement.";
                    answer = "dance";
                    break;
            }
        }
        // Medium
        if (GameControl.stage == "3" && GameControl.difficulty == "medium")
        {
            switch (questionNumber)
            {
                case 1:
                    question = "A sterile used to cover wounds.";
                    answer = "dressing";
                    break;
                case 2:
                    question = "Form of cruelty that involves the use of words is called: ____ abuse.";
                    answer = "verbal";
                    break;
                case 3:
                    question = "What form of violence is used for political goals which include putting the public or a great number of people in fear?";
                    answer = "terrorism";
                    break;
                case 4:
                    question = "It refers to the declaration of intention to impose harm or punishment upon another.";
                    answer = "threat";
                    break;
                case 5:
                    question = "People with the power or right to command is called?";
                    answer = "authority";
                    break;
                case 6:
                    question = "_____ is taking away or forcefully moving a person against his/her will and holding him/her in unjust captivity. (Ends in “ing”)";
                    answer = "kidnapping";
                    break;
                case 7:
                    question = "A well defined collection of objects or numbers.";
                    answer = "set";
                    break;
                case 8:
                    question = "The science of collecting, classifying, summarizing, organizing, analyzing, and interpreting numerical information.";
                    answer = "statistics";
                    break;
                case 9:
                    question = "An algebraic expression which contains three terms.";
                    answer = "trinomial";
                    break;
                case 10:
                    question = "The first coordinate in an ordered pair.";
                    answer = "abscissa";
                    break;
                case 11:
                    question = "One of the four regions into which two perpendicular line separate the plane.";
                    answer = "quadrant";
                    break;
                case 12:
                    question = "The largest plateau in the world is? (Starts and ends with ‘T’)";
                    answer = "tibet";
                    break;
                case 13:
                    question = "How many volcanoes are there in Japan? (less than 200, greater than 150)";
                    answer = "165";
                    break;
            }
        }
        // Hard
        if (GameControl.stage == "3" && GameControl.difficulty == "hard")
        {
            switch (questionNumber)
            {
                case 1:
                    question = "Referred to as the story of mankind’s past.";
                    answer = "history";
                    break;
                case 2:
                    question = "The science of representing the surface features of a region in maps and charts.";
                    answer = "topography";
                    break;
                case 3:
                    question = "The Northernmost Island of the Philippines is _____ island.";
                    answer = "mavulis";
                    break;
                case 4:
                    question = "It refers to the permanently frozen sub soil.";
                    answer = "permafrost";
                    break;
                case 5:
                    question = "Part of Russia that has an area of 12.6 million square kilometers.";
                    answer = "siberia";
                    break;
                case 6:
                    question = "Sri Lanka, just like any other few country, also has an old name; what is it?";
                    answer = "ceylon";
                    break;
                case 7:
                    question = "In terms of area and population, the largest continent in the world is ____";
                    answer = "asia";
                    break;
                case 8:
                    question = "Refers to the place where people live, work, engage in such activities as recreation, trade, marketing, and others.";
                    answer = "settlement";
                    break;
                case 9:
                    question = "Find the solution for 15-x=-9";
                    answer = "24";
                    break;
                case 10:
                    question = "What is the value of b of the equation x2+7x+12=0?";
                    answer = "7";
                    break;
                case 11:
                    question = "A relationship between two numbers of the same kind is called?";
                    answer = "ratio";
                    break;
                case 12:
                    question = "What element in periodic table is located on group 4, period 7?";
                    answer = "rutherfordium";
                    break;
                case 13:
                    question = "What layer of the Ocean is considered the midnight zone?";
                    answer = "bathypelagic";
                    break;
            }
        }

        Dice.clickable = false;
        Popup.popUpCanvas.enabled = true;
        Popup.inputEnabled(true);
        Popup.popUpTitle.text = "Question Tile";
        Popup.popUpText.text = "Answer the question!\n" + question;
        tileStepped = "question";
    }
    public static void RedSnake()
    {
        Dice.clickable = false;
        Popup.popUpCanvas.enabled = true;
        Popup.inputEnabled(false);
        Popup.popUpTitle.text = "Red Snake";
        Popup.popUpText.text = "Oh no! You stepped on a red snake!\nHealth - 1";
        GameControl.heart = GameControl.heart - 1;
        GameControl.SFX_Hit.GetComponent<AudioSource>().Play();
    }
}
