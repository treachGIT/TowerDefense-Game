using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public int HP = 40;
    public GameController gameController;
    public Text hpText;

    public void Start()
    {
        hpText.text = HP.ToString();
    }

    public void TakeDamage(int damage)
    {
        HP = HP - damage;

        if(HP <= 0)
        {
            gameController.isGame = false;
        }

        hpText.text = HP.ToString();
    }
}
