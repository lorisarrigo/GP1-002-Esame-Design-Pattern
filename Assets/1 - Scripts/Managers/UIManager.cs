using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //Manages the element in the HUD of the Player

    //it activate when the game is running
    [SerializeField] GameObject inGameHUD; 

    //Health/Shield Bars
    public Image healthBar, shieldBar;

    //Abilities
    public GameObject speedIcon, shieldIcon, maxHpIcon, damageIcon;

    private void Update()
    {
        //Updates the 2 Bars of the Player
        healthBar.fillAmount = (float)Player.Instance.currentHP / (float)Player.Instance.maxHP;
        shieldBar.fillAmount = (float)AbilityManager.Instance.shieldCurrentHp / (float)AbilityManager.Instance.shieldMaxHp;
    }
}
