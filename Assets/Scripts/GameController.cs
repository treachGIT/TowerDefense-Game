using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //wartości ustawiane w inspektorze unity
    public Camera mainCamera;
    public Camera uiCamera;
    public UIController uIController;

    public GameObject spawnPortal;
    public GameObject enemyPrefab;
    public Transform[] pathPoints;

    public Timer timer;

    public EasyWaveStrategy easyWaveStrategy;
    public NormalWaveStrategy normalWaveStrategy;
    public HardWaveStrategy hardWaveStrategy;
    //

    public WaveController waveController;

    public bool isGame = false;
    bool shouldSpawnWave = false;

    public TowerCreator creator;
    public List<GameObject> towers = new List<GameObject>();
    public List<GameObject> towersToUpgrade = new List<GameObject>();
    public List<GameObject> towersPlacedThisRound = new List<GameObject>();
    private UpgradeHandler upgradeHandler;

    private int money = 150;
    private int moneyForOneEnemy = 10;

    void Start()
    {
        easyWaveStrategy = new EasyWaveStrategy();
        normalWaveStrategy = new NormalWaveStrategy();
        hardWaveStrategy = new HardWaveStrategy();

        waveController = new WaveController(spawnPortal, enemyPrefab);
        waveController.ChangeStrategy(normalWaveStrategy);

        upgradeHandler = new UpgradeHandler();

        TurnOffTowerSquares(); 
    }

    void Update()
    {
        if (isGame)
        {
            if (shouldSpawnWave)
            {
                startNewWave();
                shouldSpawnWave = false;
            }

            GameHandler();      
        }
        else if (isGame == false)
        {
            if (waveController.waveCount == 0)
            {
                StartMenu();
            }
            else
            {
                uIController.ShowEndGamePanel(waveController.waveCount);
            }         
        }

    }

    public void StartMenu()
    {
        uiCamera.enabled = true;
        mainCamera.enabled = false;
    }

    public void StartGame()
    {
        isGame = true;
        uIController.ShowTimerPanel(money);
        uIController.ShowUpdatesPanel();
        TurnOffTowers();
        TurnOnTowerSquares();
        timer.StartTimer();
        mainCamera.enabled = true;
        uiCamera.enabled = false;
    }

    //rozpoczecie nowej fali przeciwników
    public void startNewWave()
    {
        waveController.GenerateWave();
        waveController.SetWavePath(pathPoints);
    }

    public void GameHandler()
    {
        if (timer.timerIsRunning == false)
        {
            //jezeli nie ma przerwy sprawdzamy czy fala się skończyła
            if (waveController.IfWaveEnded() == true)
            {
                //po zakończeniu fali aktualizowane są pieniądze gracza
                //wyświetlane są również odpowienie panele UI

                money = money + waveController.enemies.Count * moneyForOneEnemy;
                uIController.ShowTimerPanel(money);
                uIController.ShowUpdatesPanel();
                uIController.ExitHpPanel();
                TurnOffTowers();
                TurnOnTowerSquares();
                timer.StartTimer();

                //ustawienie wież na które działają komendy ulepszające
                towersToUpgrade = new List<GameObject>();
                towersToUpgrade.AddRange(towers);
            }
        }
        else
        {  
            if (timer.timeRemaining <= 0)
            {
                //ustawienie wież dodanych w obecnej rundzie do aktualizacji i wywołanie na nich wszystkich komend z historii
                towersToUpgrade = new List<GameObject>();
                towersToUpgrade.AddRange(towersPlacedThisRound);
                upgradeHandler.executeAllCommandsFromHistory();
                towers.AddRange(towersToUpgrade);
                towersPlacedThisRound = new List<GameObject>();


                //ustawiamy panele ui do rozpoczęcia fali 
                uIController.ExitTimerPanel();
                TurnOnTowers();
                TurnOffTowerSquares();
                uIController.ExitPlaceTowerPanel();
                uIController.ExitUpdatesPanel();
                uIController.ShowHpPanel();
                timer.timerIsRunning = false;
                shouldSpawnWave = true;
            }
        }
    }

    //tworzenie nowej wieży
    public void PlaceNewTower(TowerCreator currentCreator, GameObject placeObject)
    {
        //utworzenie nowej wieży przy użyciu metody fabrykującej
        creator = currentCreator;
        GameObject tower = creator.placeTower(placeObject.transform.position);
        tower.GetComponent<SphereCollider>().enabled = false;

        int tempValue =  money - tower.GetComponent<Tower>().value;
        if (tempValue < 0)
        {
            Destroy(tower);
            uIController.PlaceTowerPanel(placeObject);          
        }
        else
        {
            money = tempValue;
            uIController.ShowTimerPanel(money);
            towersPlacedThisRound.Add(tower);
            placeObject.SetActive(false);
        }
    }


    //metody wyłączające i właczające collidery wież
    public void TurnOffTowers()
    {
        try
        {
            foreach (GameObject tower in towers)
            {
                tower.GetComponent<SphereCollider>().enabled = false;
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }  
    }

    public void TurnOnTowers()
    {
        try
        {
            foreach (GameObject tower in towers)
            {
                tower.GetComponent<SphereCollider>().enabled = true;
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }


    //metody ustawiające pola do tworzenia wież
    public void TurnOffTowerSquares()
    {
        GameObject[] towerSquares = GameObject.FindGameObjectsWithTag("TowerSquare");
        foreach (GameObject square in towerSquares)
        {
            square.transform.position = square.transform.position + new Vector3(0, -1, 0);
        }
    }

    public void TurnOnTowerSquares()
    {
        GameObject[] towerSquares = GameObject.FindGameObjectsWithTag("TowerSquare");
        foreach (GameObject square in towerSquares)
        {
            square.transform.position = square.transform.position + new Vector3(0, 1, 0);
        }
    }

    //metody ulepszeń wykonywane przez przyciski w uicontrollerze
    public void UpgradeDamage()
    {
        Command command = new DamageUpgradeCommand(this);
    
        upgradeHandler.executeCommand(command);
    }

    public void UpgradeAttackSpeed()
    {
        Command command = new ASUpgradeCommand(this);

        upgradeHandler.executeCommand(command);
    }

    public void UpgradeBulletSpeed()
    {
        Command command = new BSUpgradeCommand(this);

        upgradeHandler.executeCommand(command);
    }

}
