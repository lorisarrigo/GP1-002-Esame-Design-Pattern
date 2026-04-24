using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{

    public float abilityDuration;
    [HideInInspector] public float baseSpeed;
    public GameObject shieldArea;
    public Image shieldBar; //da spostare nello UImanager
    public Image healthBar;
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
