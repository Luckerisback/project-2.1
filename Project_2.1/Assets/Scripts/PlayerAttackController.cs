
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttackController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isAttack;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isAttack = true;
        ShootAutoAttack();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isAttack = false;
    }

    private async void ShootAutoAttack()
    {
        while (_isAttack)
        {
           PlayerParametersInGame.Weapon.Shoot();
            await Task.Delay(170);
            await Task.Yield();
        }
    }
    
}
