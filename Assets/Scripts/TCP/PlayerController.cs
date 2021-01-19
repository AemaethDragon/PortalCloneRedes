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
    
    void FixedUpdate()
    {
        if (!Playable) return;
        if (transform.position != _oldPosition)
        {
            Message m = new Message();
            m.MessageType = MessageType.PlayerMovement;
            PlayerInfo info = new PlayerInfo();
            info.Id = TcpClient.Player.Id;
            info.Name = TcpClient.Player.Name;
            info.X = transform.position.x;
            info.Y = transform.position.y;
            info.Z = transform.position.z;
            info.XQ = transform.rotation.x;
            info.YQ = transform.rotation.y;
            info.ZQ = transform.rotation.z;
            info.WQ = transform.rotation.w;
                
                
            m.PlayerInfo = info;
            TcpClient.Player.SendMessage(m);
        }
        _oldPosition = transform.position;
    }
}