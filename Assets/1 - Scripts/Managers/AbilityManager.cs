using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public float abilityDuration;
    public float abilityCooldown;
    [HideInInspector] public float baseSpeed;
    public GameObject shieldArea;
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
