using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mineral", menuName = "Items/Mineral", order = 1)]
public class Mineral : ItemObject 
{
    [SerializeField]
    AudioClip soundEffect;
    public void Pickup(PlayerMovement player)
    {
        Vector3 playerPosition = player.transform.position;
        AudioSource.PlayClipAtPoint(soundEffect, playerPosition, 1f);
    }
}
