using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    //stores variable and Object so that it can give them to the abilities

    [Header("General Ability settings")]
    public float abilityDuration;
    public float abilityCooldown;

    [HideInInspector] public float baseSpeed; //base Player Speed
    [HideInInspector] public bool invincible; //bool used in the MaxHp Ability 
    
    [Header("Shield")]
    public GameObject shieldArea; //the Shield GameObject
    
    [Header("Damage")]
    public GameObject damageArea; //the Damage GameObject

    [Header("Unlock checks")]
    public bool ShieldCheck = false; 
    public bool MaxHpCheck = false;
    public bool DamageCheck = false;

    public static AbilityManager Instance;
    /*it's recalled in:
     * Bullet to check the Sps and to ignore the Damage area;
     * UIManager to check if an Ability it's collected and so to activate/deactivate the icons;
     * Abilities (DamageAbility) to activate/deactivate the Damage Area;
     * Abilities (ShieldAbility) to activate/deactivate the Shield and to change the values of the fillbar;
     * Abilities (SpeedAbility) to make the speed at its base value;
     * Abilities (MaxHPAbility) to make the player invincible;
     * AbilitySwitcher to Enable the selection of the abilities if the connected bools are true;
     * AbilityUser to Enable the ability if the connected bools are true, set the duration and the cooldown of the abilities
    */

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        baseSpeed = Player.Instance.speed;
    }
}
