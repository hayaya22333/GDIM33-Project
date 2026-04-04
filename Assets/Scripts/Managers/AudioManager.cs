using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource pistol;
    void Start()
    {
        Locator.Instance.Player.Shoot += HandleShoot;
    }

    void HandleShoot()
    {
        pistol.Play();
    }
}
