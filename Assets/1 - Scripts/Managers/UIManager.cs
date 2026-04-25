using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject inGameHUD; //si disattiva una volta attivati i Menù
    //Health system
    public Image healthBar; 
    public Image shieldBar; 

    //Abilities
    public GameObject speedIcon;
    public GameObject shieldIcon;
    public GameObject maxHpIcon;
    public GameObject damageIcon;

    private void Update()
    {
        healthBar.fillAmount = (float)PlayerMovement.Instance.currentHP / (float)PlayerMovement.Instance.maxHP;

        shieldBar.fillAmount = (float)AbilityManager.Instance.shieldCurrentHp / (float)AbilityManager.Instance.shieldMaxHp;
    }
}
