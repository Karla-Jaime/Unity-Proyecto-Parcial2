using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mineral", menuName = "Items/Mineral", order = 1)]
public class Mineral : ItemObject 
{
    [SerializeField]
    string title;
    [SerializeField]
    string description;
    [SerializeField]
    AudioClip soundEffect;
    public void Analyze(PlayerMovement player)
    {
        Vector3 playerPosition = player.transform.position;
        if (soundEffect != null)
        {
            AudioSource.PlayClipAtPoint(soundEffect, playerPosition, 1f);
        }

        if (player.titleText != null && title != null)
        {
            player.titleText.text = title;
        }

        if (player.descriptionText != null && description != null)
        {
            player.descriptionText.text = description;
        }
    }
}
