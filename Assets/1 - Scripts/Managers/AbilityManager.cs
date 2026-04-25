using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public float abilityDuration;
    public float abilityCooldown;
    [HideInInspector] public float baseSpeed;
    
    public GameObject shieldArea;
    public float shieldMaxHp;
    public float shieldCurrentHp;
    
    public GameObject damageArea;

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
        baseSpeed = PlayerMovement.Instance.speed;
    }
}
