using UnityEngine;
using System.Collections;

public class PlayerFlags : MonoBehaviour
{

    [Space]
    [Header("Actor Templates")]
    public Actor playerTemplate;
    public Actor monsterTemplate;

    //startposition decider
    public bool inside;

    public bool togglePlayerMovement = true;

    private BattleWindow battleWindow;
    public Actor playerActor;
    private StatsWindow statsWindow;

    public GameObject eImage;

    public int money = 15;

    //mesage window
    public WindowManager windowManager
    {
        get
        {
            return GenericWindow.manager;
        }
    }

    public void Start()
    {
        playerActor = playerTemplate.Clone<Actor>();
        playerActor.ResetHealth();

        
    }


    // Update is called once per frame
    void Update()
    {
        //start - end battle tests 
        if (Input.GetKeyUp(KeyCode.Q))
        {
           StartBattle();
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
           EndBattle();
        }
        //window manager test
        if (Input.GetKeyUp(KeyCode.M))
        {
            var messageWindow = windowManager.Open((int)Windows.MessageWindow - 1, false) as MessageWindow;
            messageWindow.text = "heres text";

        }
      
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            StartBattle();
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Dialog")
        {
            eImage.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Dialog")
        {
            eImage.SetActive(false);
        }

    }
    public void StartBattle()
    {
        var monsterActor = monsterTemplate.Clone<Actor>();
        monsterActor.ResetHealth();

        statsWindow = windowManager.Open((int)Windows.StatsWindow - 1, false) as StatsWindow;
        statsWindow.target = playerActor;
        statsWindow.UpdateStats();

        battleWindow = windowManager.Open((int)Windows.BattleWindow - 1, false)as BattleWindow;
        battleWindow.battleOverCallback += BattleOver;
        battleWindow.StartBattle(playerActor,monsterActor);
        togglePlayerMovement = false;
    }

    public void EndBattle()
    {
        statsWindow.Close();
        battleWindow.Close();
        togglePlayerMovement = true;
    }

    private void BattleOver(bool playerWin)
    {
        EndBattle();

        if(!playerWin)
        {
            playerActor = null;
            StartCoroutine(ExitGame());
            
        }
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(2);
        windowManager.Open((int)Windows.gameOverWindow - 1);
    }

}