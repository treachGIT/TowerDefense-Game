using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //panele ustawiane w inspektorze unity
    public GameObject uiEnemy;
    public GameObject mainMenu;
    public GameObject startMenu;
    public GameController gameController;

    public GameObject selectedBorder;
    public GameObject easyButton;
    public GameObject normalButton;
    public GameObject hardButton;

    public GameObject placeTowerPanel;
    public GameObject placeSquare;

    public GameObject timerPanel;
    public Text moneyText;

    public GameObject updatesPanel;

    public GameObject baseHpPanel;

    public GameObject endGamePanel;
    public Text waveText;

    public void ShowMainMenu()
    {
        startMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ShowStartMenu()
    {
        mainMenu.SetActive(false);
        startMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetEasyDifficulty()
    {
        selectedBorder.transform.position = easyButton.transform.position;
        //po przycisnieciu przycisku w ui, wywolywana jest metoda gameControllera do zmiany strategii
        gameController.waveController.ChangeStrategy(gameController.easyWaveStrategy);
    }

    public void SetNormalDifficulty()
    {
        selectedBorder.transform.position = normalButton.transform.position;
        gameController.waveController.ChangeStrategy(gameController.normalWaveStrategy);
    }

    public void SetHardDifficulty()
    {
        selectedBorder.transform.position = hardButton.transform.position;
        gameController.waveController.ChangeStrategy(gameController.hardWaveStrategy);
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Destroy(uiEnemy);
        gameController.StartGame();
    }

    public void PlaceTowerPanel(GameObject placeSquare)
    {
        this.placeSquare = placeSquare;
        placeTowerPanel.SetActive(true);
    }

    public void BuildFreezeTower()
    {
        placeTowerPanel.SetActive(false);
        //po przycisnieciu przycisku w ui, wywolywana jest metoda gameControllera do budowy nowej wiezy
        gameController.PlaceNewTower(new FreezeTowerCreator(), placeSquare);
    }

    public void BuildFireTower()
    {
        placeTowerPanel.SetActive(false);
        gameController.PlaceNewTower(new FireTowerCreator(), placeSquare);
    }

    public void ExitPlaceTowerPanel()
    {
        placeTowerPanel.SetActive(false);
    }

    public void ShowTimerPanel(int money)
    {
        moneyText.text = money.ToString();
        timerPanel.SetActive(true);
    }

    public void ExitTimerPanel()
    {
        timerPanel.SetActive(false);
    }

    public void ShowUpdatesPanel()
    {
        updatesPanel.SetActive(true);
    }

    public void ExitUpdatesPanel()
    {
        updatesPanel.SetActive(false);
    }

    public void UpgradeAttackSpeed()
    {
        updatesPanel.SetActive(false);
        //po przycisnieciu przycisku w ui, wywolywana jest komenda ulepszenia wiezy
        gameController.UpgradeAttackSpeed();
    }

    public void UpgradeDamage()
    {
        updatesPanel.SetActive(false);
        gameController.UpgradeDamage();
    }

    public void UpgradeBulletSpeed()
    {
        updatesPanel.SetActive(false);
        gameController.UpgradeBulletSpeed();
    }

    public void ShowHpPanel()
    {
        baseHpPanel.SetActive(true);
    }

    public void ExitHpPanel()
    {
        baseHpPanel.SetActive(false);
    }

    public void ShowEndGamePanel(int waveNumber)
    {
        endGamePanel.SetActive(true);
        waveText.text = waveNumber.ToString();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
