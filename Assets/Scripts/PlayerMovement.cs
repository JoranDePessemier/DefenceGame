using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera _mainCam;
    private Transform _transform;

    [SerializeField]
    private float _moveSpeed = 10;


    private void Awake()
    {
        _mainCam = Camera.main;
        _transform = this.transform;
    }

    private void Update()
    {
        Vector3 mousePosition = _mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
        
        _transform.up = Vector3.MoveTowards(_transform.up,-(_transform.position - mousePosition).normalized,_moveSpeed*Time.deltaTime);
    }


}
