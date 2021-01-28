using System;
using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool Playable;
    private float _horizontal;
    private float _vertical;
    private Vector3 _oldPosition;
    private float _moveSpeed = 4f;
    public TcpClientController TcpClient;
    public GameObject camera;
    private Vector3 _oldRotation;
    private Vector3 _viewTarget;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject leftPortal;
    public GameObject rightPortal;

    private void Update()
    {
        if (cube1 == null)
        {
            cube1 = FindObjectOfType<Pickupable>().gameObject;
        }

        if (cube2 == null)
        {
            cube2 = FindObjectOfType<Pickupable>().gameObject;
        }
        
        if (cube3 == null)
        {
            cube3 = FindObjectOfType<Pickupable>().gameObject;
        }

        if (leftPortal == null)
        {
            leftPortal = FindObjectOfType<TeleportationLeft>().gameObject;
        }

        if (rightPortal == null)
        {
            rightPortal = FindObjectOfType<TeleportationRight>().gameObject;
        }
    }
    
    
    void FixedUpdate()
    {
        if (!Playable) return;
        
        _viewTarget = transform.position + transform.forward;

        if (transform.position != _oldPosition || _viewTarget != _oldRotation)
        {
            Message m = new Message();
            m.MessageType = MessageType.PlayerMovement;
            PlayerInfo info = new PlayerInfo();
            
            info.Id = TcpClient.Player.Id;
            info.Name = TcpClient.Player.Name;
            info.X = transform.position.x;
            info.Y = transform.position.y;
            info.Z = transform.position.z;
            info.lookX = _viewTarget.x;
            info.lookY = _viewTarget.y;
            info.lookZ = _viewTarget.z;
            
            if (cube1 != null)
            {
                info.C1x = cube1.transform.position.x;
                info.C1y = cube1.transform.position.y;
                info.C1z = cube1.transform.position.z;

            }
            
            if (cube2 != null)
            {
                info.C2x = cube2.transform.position.x;
                info.C2y = cube2.transform.position.y;
                info.C2z = cube2.transform.position.z;

            }
            
            if (cube3 != null)
            {
                info.C3x = cube3.transform.position.x;
                info.C3y = cube3.transform.position.y;
                info.C3z = cube3.transform.position.z;

            }
            
            if (leftPortal != null)
            {
                info.P1x = leftPortal.transform.position.x;
                info.P1y = leftPortal.transform.position.y;
                info.P1z = leftPortal.transform.position.z;
            }
            
            if (rightPortal != null)
            {
                info.P2x = rightPortal.transform.position.x;
                info.P2y = rightPortal.transform.position.y;
                info.P2z = rightPortal.transform.position.z;
            }


            m.PlayerInfo = info;
            TcpClient.Player.SendMessage(m);
        }
        
        _oldPosition = transform.position;
        _oldRotation = _viewTarget;
    }
}