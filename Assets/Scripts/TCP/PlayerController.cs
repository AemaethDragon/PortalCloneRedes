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
    public GameObject cube;

    private void Update()
    {
        if (cube == null)
        {
            cube = FindObjectOfType<Pickupable>().gameObject;

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
            if (cube != null)
            {
                info.cube1.Cy = cube.transform.position.x;
                info.cube1.Cz = cube.transform.position.y;
                info.cube1.Cx = cube.transform.position.z;

            }

            m.PlayerInfo = info;
            TcpClient.Player.SendMessage(m);
        }
        _oldPosition = transform.position;
        _oldRotation = _viewTarget;

       
    }
}