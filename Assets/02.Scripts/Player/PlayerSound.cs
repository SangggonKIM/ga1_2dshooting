using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private AudioSource _playerDamagedaudioSource;

    private void Awake()
    {
        _playerDamagedaudioSource = GetComponent<AudioSource>();
    }

    public void PlayDamagedSound()
    {
        _playerDamagedaudioSource.Play();
    }
}
