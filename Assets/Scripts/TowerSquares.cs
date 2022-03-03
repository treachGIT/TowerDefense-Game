using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSquares : MonoBehaviour
{
    //wartosci ustawiane w inspektorze unity
    public UIController uiController;
    public Color startColor;
    public Color mouseOverColor;

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }

    private void OnMouseDown()
    {
        //po wybraniu odpowiedniego miejsca, wyswietlany jest panel dodawania wiezy
        uiController.PlaceTowerPanel(this.gameObject);
    }

}
