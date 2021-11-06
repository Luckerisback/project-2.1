
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveView : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerUpHandler, IPointerExitHandler, IPointerDownHandler
{
     
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject respawnArrow;
    private Vector2 _startPos;
    private bool _swipeRight;
    private const float _swipeRange = 50;

    private void Start()
    {
        
        PlayerParametersInGame.RespawnArrow = respawnArrow;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.delta.x > 0 && eventData.position.x > _startPos.x + _swipeRange)
        {
            rightArrow.SetActive(true);
            leftArrow.SetActive(false);
            _startPos.x = eventData.position.x;
            PlayerParametersInGame.PlayerControlV2.Walk(1);
            PlayerParametersInGame.PlayerControlV2.SetWalkAnim();
            if (!PlayerParametersInGame.PlayerControlV2.faceRight)
            {
                PlayerParametersInGame.PlayerControlV2.Reflect();
            }
            
        }
        else if (eventData.delta.x < 0 && eventData.position.x < _startPos.x - _swipeRange)
        {
            rightArrow.SetActive(false);
            leftArrow.SetActive(true);
            _startPos.x = eventData.position.x;
            PlayerParametersInGame.PlayerControlV2.SetWalkAnim();
            PlayerParametersInGame.PlayerControlV2.Walk(-1);
            if (PlayerParametersInGame.PlayerControlV2.faceRight)
            {
                PlayerParametersInGame.PlayerControlV2.Reflect();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerParametersInGame.PlayerControlV2.IdleState();
        PlayerParametersInGame.PlayerControlV2.Walk(0);
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }
}
