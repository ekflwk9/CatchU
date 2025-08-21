using UnityEngine;

public class MapMusic : MonoBehaviour
{
    private void Start()
    {
        SoundManager.OnMusic(Str.BackGroundMusic);
    }
}
