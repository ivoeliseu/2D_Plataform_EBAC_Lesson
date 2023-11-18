using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyer : MonoBehaviour
{
    public Player player;

    public void KillPlayer()
    {
        player.DestroyMe();
    }
}
