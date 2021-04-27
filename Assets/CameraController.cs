using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        FollowPlayer();
    }

    /// <summary>
    /// Faz com que a câmera siga o jogador de forma elástica.
    /// </summary>
    public void FollowPlayer() {
        Vector3 _position = transform.position;
        Vector3 _playerPosition = player.position;
        Vector3 _dir = new Vector3(player.position.x, player.position.y, 0) - new Vector3(transform.position.x, transform.position.y, 0);
        //Executa função elástica de movimentação de câmera.
        if(_position.x != _playerPosition.x || _position.y != _playerPosition.y) {
            transform.position += _dir * cameraSpeed * Time.fixedDeltaTime;
        }
    }
}
