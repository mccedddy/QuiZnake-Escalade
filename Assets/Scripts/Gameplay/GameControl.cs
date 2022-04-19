using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Inspector Fields
    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;
    [SerializeField] GameObject heart4;
    [SerializeField] GameObject heart5;

    // Fields
    public static GameObject player1;
    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player1Position = 1;
    public static bool gameOver = false;
    public static int heart = 5;
    public Sprite heartFull;
    public Sprite heartEmpty;
    private bool coinAdded = false;
    public static string level;
    public static string stage;
    public static string difficulty;
    public static GameObject SFX_Walk;
    public static GameObject SFX_ButtonClick;
    public static GameObject SFX_Coin;
    public static GameObject SFX_Hit;
    public static GameObject SFX_Question;
    public static GameObject SFX_Reward;
    public static GameObject SFX_Correct;
    public static GameObject SFX_Wrong;
    public static GameObject SFX_Victory;
    public static GameObject SFX_Defeat;
    public static bool checkedTile = false;
    private static GameObject board;
    private static bool resultSoundPlaying = false;
    private static int waypointIndex;
    private static float xOldValue;
    private static float xNewValue;
    //Animator animator = player1.GetComponent<Animator>();

    // START
    public void Start()
    {
        // Set player1 GameObject
        player1 = GameObject.Find("Player1");

        // Detect stage and difficulty
        level = SceneManager.GetActiveScene().name;
        DetectStage();

        // Reset variables
        player1.GetComponent<FollowThePath>().moveAllowed = false;
        diceSideThrown = 0;
        player1StartWaypoint = 0;
        player1Position = 1;
        gameOver = false;
        coinAdded = false;
        heart = 5;
        resultSoundPlaying = false;

        if (difficulty == "easy")
        { heart = 5; }

        // SFX
        SFX_Walk = GameObject.Find("SFX_Walk");
        SFX_ButtonClick = GameObject.Find("SFX_ButtonClick");
        SFX_Coin = GameObject.Find("SFX_Coin");
        SFX_Hit = GameObject.Find("SFX_Hit");
        SFX_Question = GameObject.Find("SFX_Question");
        SFX_Reward = GameObject.Find("SFX_Reward");
        SFX_Correct = GameObject.Find("SFX_Correct");
        SFX_Wrong = GameObject.Find("SFX_Wrong");
        SFX_Victory = GameObject.Find("SFX_Victory");
        SFX_Defeat = GameObject.Find("SFX_Defeat");
        SFX_Walk.GetComponent<AudioSource>().mute = false;

        // Load Board
        board = GameObject.Find("Board");
        if (stage == "1")
            board.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Boards/In Game/Board_" + PlayerPrefs.GetString("6x6Equipped"));
        if (stage == "2")
            board.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Boards/In Game/Board_" + PlayerPrefs.GetString("8x8Equipped"));
        if (stage == "3")
            board.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Boards/In Game/Board_" + PlayerPrefs.GetString("10x10Equipped"));

        // Load Character
        player1.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Characters/Animation/Controller_" + PlayerPrefs.GetString("characterEquipped")) as RuntimeAnimatorController;

        // Load and Delete Save
        if (PlayerPrefs.GetString("continued") == "true")
        {
            SaveData.Load();
            player1.GetComponent<FollowThePath>().waypointIndex = PlayerPrefs.GetInt("waypointIndex");
        }
        SaveData.DeleteSave();

        // Set player position
        player1.transform.position = player1.GetComponent<FollowThePath>().waypoints[player1Position - 1].transform.position;
    }

    // UPDATE
    void Update()
    {
        // Set variables
        waypointIndex = player1.GetComponent<FollowThePath>().waypointIndex;

        // Stop moving
        if (waypointIndex >
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1StartWaypoint = waypointIndex - 1;
            Dice.clickable = true;
            player1.GetComponent<FollowThePath>().isMoving = false;
        }

        // Stage 1 Victory
        if (stage == "1")
        {
            // Game Over (Victory)
            if (player1.GetComponent<FollowThePath>().waypointIndex == 36)
            {
                gameOver = true;
                Dice.clickable = true;
                Popup.popUpCanvas.enabled = true;
                Popup.popUpTitle.text = "Game Over";
                Popup.popUpText.text = "Victory!";
                if (resultSoundPlaying == false)
                {
                    SFX_Walk.GetComponent<AudioSource>().mute = true;
                    SFX_Victory.GetComponent<AudioSource>().Play();
                    resultSoundPlaying = true;
                }
                SaveData.DeleteSave();
                PlayerPrefs.SetString("stage1Cleared", "true");

                if (coinAdded == false)
                {
                    Coins.AddCoin(5 + heart);
                    coinAdded = true;
                }

                Popup.popUpButton.onClick.AddListener(() =>
                {
                    if (gameOver == true)
                    {
                        Popup.popUpText.text = "Please wait...";
                        BeginLoadLevel();
                    }
                });
            }
        }
        // Stage 2 Victory
        if (stage == "2")
        {
            // Game Over (Victory)
            if (waypointIndex == 64)
            {
                gameOver = true;
                Dice.clickable = true;
                Popup.popUpCanvas.enabled = true;
                Popup.popUpTitle.text = "Game Over";
                Popup.popUpText.text = "Victory!";
                if (resultSoundPlaying == false)
                {
                    SFX_Walk.GetComponent<AudioSource>().mute = true;
                    SFX_Victory.GetComponent<AudioSource>().Play();
                    resultSoundPlaying = true;
                }
                SaveData.DeleteSave();
                PlayerPrefs.SetString("stage2Cleared", "true");

                if (coinAdded == false)
                {
                    Coins.AddCoin(10 + heart);
                    coinAdded = true;
                }

                Popup.popUpButton.onClick.AddListener(() =>
                {
                    if (gameOver == true)
                    {
                        BeginLoadLevel();
                    }
                });
            }
        }
        // Stage 3 Victory
        if (stage == "3")
        {
            // Game Over (Victory)
            if (waypointIndex == 100)
            {
                gameOver = true;
                Dice.clickable = true;
                Popup.popUpCanvas.enabled = true;
                Popup.popUpTitle.text = "Game Over";
                Popup.popUpText.text = "Victory!";
                if (resultSoundPlaying == false)
                {
                    SFX_Walk.GetComponent<AudioSource>().mute = true;
                    SFX_Victory.GetComponent<AudioSource>().Play();
                    resultSoundPlaying = true;
                }
                SaveData.DeleteSave();

                if (coinAdded == false)
                {
                    Coins.AddCoin(20 + heart);
                    coinAdded = true;
                }

                Popup.popUpButton.onClick.AddListener(() =>
                {
                    if (gameOver == true)
                    {
                        BeginLoadLevel();
                    }
                });
            }
        }

        // Heart 5 display
        if (gameOver == false)
        {
            switch (heart)
            {
                case 5:
                    heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart2.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart3.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart4.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart5.GetComponent<SpriteRenderer>().sprite = heartFull;
                    break;
                case 4:
                    heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart2.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart3.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart4.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart5.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                    break;
                case 3:
                    heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart2.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart3.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart4.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                    heart5.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                    break;
                case 2:
                    heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart2.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                    heart4.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                    heart5.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                    break;
                case 1:
                    heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
                    heart2.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                    heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                    heart4.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                    heart5.GetComponent<SpriteRenderer>().sprite = heartEmpty;
                    break;
            }
        }
        
        // Defeat
        if (heart <= 0)
        {
            heart1.GetComponent<SpriteRenderer>().sprite = heartEmpty;
            heart2.GetComponent<SpriteRenderer>().sprite = heartEmpty;
            heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
            heart4.GetComponent<SpriteRenderer>().sprite = heartEmpty;
            heart5.GetComponent<SpriteRenderer>().sprite = heartEmpty;

            // Game Over (Defeat)
            gameOver = true;
            Dice.clickable = true;
            Popup.popUpCanvas.enabled = true;
            Popup.popUpTitle.text = "Game Over";
            Popup.popUpText.text = "You Lose!";
            if (resultSoundPlaying == false)
            {
                SFX_Walk.GetComponent<AudioSource>().mute = true;
                SFX_Defeat.GetComponent<AudioSource>().Play();
                resultSoundPlaying = true;
            }
            heart = 5;
            SaveData.DeleteSave();

            Popup.popUpButton.onClick.AddListener(() =>
            {
                if (gameOver == true)
                {
                    BeginLoadLevel();
                }
            });
        }

        // Heart per difficulty
        if (difficulty == "easy")
            if (heart > 5) { heart = 5; }
        if (difficulty == "medium")
            if (heart > 4) { heart = 4; }
        if (difficulty == "hard")
            if (heart > 3) { heart = 3; }

        // CheckTile after walking
        if (waypointIndex == player1Position && checkedTile == false)
        {
            Tile.CheckTile(player1Position);
            checkedTile = true;
        }

        // Animation
        // Run
        if (player1.GetComponent<FollowThePath>().isMoving == true) 
        {
            player1.GetComponent<Animator>().SetBool("isMoving", true);
        }
        // Idle
        else
        {
            player1.GetComponent<Animator>().SetBool("isMoving", false);
        }

        // Facing
        // Stage 1
        if (stage == "1")
        {
            if ((waypointIndex > 5 && waypointIndex <= 12) || 
                (waypointIndex > 17 && waypointIndex <= 24) || 
                (waypointIndex > 29))
            {
                player1.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                player1.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (stage == "2")
        {
            if ((waypointIndex > 7 && waypointIndex <= 16) ||
                (waypointIndex > 23 && waypointIndex <= 32) ||
                (waypointIndex > 39 && waypointIndex <= 48) ||
                (waypointIndex > 55 && waypointIndex <= 64) ||
                (waypointIndex > 71))
            {
                player1.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                player1.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (stage == "3")
        {
            if ((waypointIndex > 9 && waypointIndex <= 20) ||
                (waypointIndex > 29 && waypointIndex <= 40) ||
                (waypointIndex > 49 && waypointIndex <= 60) ||
                (waypointIndex > 69 && waypointIndex <= 80) ||
                (waypointIndex > 89))
            {
                player1.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                player1.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        // Slide
        xNewValue = player1.transform.position.x;
        if (Tile.isSliding == true)
        {
            if (xNewValue < xOldValue)
            {
                player1.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                player1.GetComponent<SpriteRenderer>().flipX = false;
            }
            player1.GetComponent<Animator>().SetBool("isSliding", true);
        }
        else
        {
            player1.GetComponent<Animator>().SetBool("isSliding", false);
        }
        if (player1.GetComponent<FollowThePath>().isMoving == true & Tile.isSliding == true)
        {
            Tile.isSliding = false;
        }

        // Climb
        if (Tile.isClimbing == true)
        {
            if (xNewValue < xOldValue)
            {
                player1.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                player1.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (player1.GetComponent<FollowThePath>().isMoving == true & Tile.isClimbing == true)
        {
            Tile.isClimbing = false;
        }
        xOldValue = player1.transform.position.x;
    }

    // Move
    public static void MovePlayer()
    {
        player1.GetComponent<FollowThePath>().moveAllowed = true;
    }

    // Climb
    public static void ClimbPlayer(int end)
    {
        player1.GetComponent<FollowThePath>().climbAllowed = true;
        player1.GetComponent<FollowThePath>().end = end;
    }

    // Debug
    private static void DetectStage()
    {
        // Stage 1
        if (level == "Stage1-easy")
        {
            stage = "1";
            difficulty = "easy";
        }
        else if (level == "Stage1-medium")
        {
            stage = "1";
            difficulty = "medium";
        }
        else if (level == "Stage1-hard")
        {
            stage = "1";
            difficulty = "hard";
        }

        // Stage 2
        else if (level == "Stage2-easy")
        {
            stage = "2";
            difficulty = "easy";
        }
        else if (level == "Stage2-medium")
        {
            stage = "2";
            difficulty = "medium";
        }
        else if (level == "Stage2-hard")
        {
            stage = "2";
            difficulty = "hard";
        }

        // Stage 3
        else if (level == "Stage3-easy")
        {
            stage = "3";
            difficulty = "easy";
        }
        else if (level == "Stage3-medium")
        {
            stage = "3";
            difficulty = "medium";
        }
        else if (level == "Stage3-hard")
        {
            stage = "3";
            difficulty = "hard";
        }
    }
    public void BeginLoadLevel()
    {
        Debug.Log("Loading");
        StartCoroutine(LoadLevelAsync());
    }
    private IEnumerator LoadLevelAsync()
    {
        var progress = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

        while (!progress.isDone)
        {
            // Check each frame if the scene has completed.
            yield return null;
        }

        // Code after this point is executed after the new scene has loaded
        Debug.Log("Scene Loaded");
        SceneManager.LoadScene("MainMenu");
    }
}
