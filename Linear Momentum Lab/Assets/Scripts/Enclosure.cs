using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enclosure : MonoBehaviour
{
    [SerializeField]
    private GameObject _button;
    [SerializeField]
    private bool _pushed;
    Collider _collider;
    private void Start()
    {
        
        _collider = GetComponent<Collider>();
    }
    private void Update()
    {
        _pushed = _button.GetComponent<Push_Button>().pushed;
        if (_pushed == true)
        {
            _collider.enabled = false;
        }
        else if(_pushed == false)
        {
            _collider.enabled = true;
        }
    }
}
