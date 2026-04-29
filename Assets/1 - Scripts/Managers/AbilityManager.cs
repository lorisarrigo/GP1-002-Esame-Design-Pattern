using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    //stores variable and Object so that it can give them to the abilities
    /*it's recalled in:
     * Bullet to check if the health of the shield and to ignore the Damage area;
     * UIManager to update the Health of the shield;
     * DamageAbility to activate/deactivate the Damage Area;
     * ShieldAbility to activate/deactivate the Shield and to change the values of the fillbar;
     * ShieldArea to make the Shield area take damage;
     * SpeedAbility to make the speed at its base value;
     * AbilityUser to set the duration and the cooldown of the abilities
    */

    [Header("General Ability settings")]
    public float abilityDuration;
    public float abilityCooldown;

    //base Player Speed
    [HideInInspector] public float baseSpeed;

    [Header("Shield")]
    public GameObject shieldArea; //the Shield GameObject
    

    [Header("Damage")]
    public GameObject damageArea; //the Damage GameObject

    [Header("Unlock checks")]
    public bool ShieldCheck = false;
    public bool MaxHpCheck = false;
    public bool DamageCheck = false;

    public static AbilityManager Instance;

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
