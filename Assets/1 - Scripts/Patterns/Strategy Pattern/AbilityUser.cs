using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityUser : MonoBehaviour
{
    InputMap inputs;
    [SerializeField] IAbility _currentAbility;
    public IAbility CurAbility { get => _currentAbility; set => _currentAbility = value; }
    bool isActive = false;
    private void Awake()
    {
        inputs = new InputMap();
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.ActivateAbility.started += Activate;
    }
    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.ActivateAbility.started -= Activate;
    }
    void Activate(InputAction.CallbackContext context)
    {
        StartCoroutine(StartAbility());         
    }

    IEnumerator StartAbility()
    {
        if (isActive == false)
        {
            _currentAbility?.UseAbility();
            isActive = true;
            Debug.Log(isActive);
        }
        if(CurAbility is not MaxHPAbility)
            yield return new WaitForSeconds(AbilityManager.Instance.abilityDuration);
        else
            yield return new WaitForSeconds(0);
        isActive = false;
        Debug.Log(isActive);

        _currentAbility?.ResetPlayerStatus();
    }
}
