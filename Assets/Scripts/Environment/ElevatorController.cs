using System;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [Header("On Flashlight")]
    [SerializeField] private Sprite flashlightOnSprite;
    [SerializeField] private GameObject flashlightGameObject;

    private SpriteRenderer _spriteRenderer;
    private SliderJoint2D _sliderJoint2D;

    private bool _isTrigger = false;

    private void Awake()
    {
        _sliderJoint2D = GetComponent<SliderJoint2D>();
        _spriteRenderer = flashlightGameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var fife1ButtonDown = Input.GetButtonDown(GlobalStringVars.FIRE1);
        EventStart(fife1ButtonDown);
    }

    private void EventStart(bool fife1ButtonDown)
    {
        if (fife1ButtonDown && _isTrigger)
        {
            _spriteRenderer.sprite = flashlightOnSprite;
            _sliderJoint2D.useMotor = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            _isTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _isTrigger = false;
    }
}
