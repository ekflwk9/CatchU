using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolumeManager : MonoBehaviour
{
    public static GlobalVolumeManager Instance { get; private set; }
    [Header("글로벌 볼륨"), SerializeField] private Volume globalVolume;

    private Bloom bloom;

#if UNITY_EDITOR
    private void Reset()
    {
        globalVolume = this.TryGetComponent<Volume>();
    }
#endif

    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            Init();
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            DestroyImmediate(this.gameObject);
        }
    }

    private T TryGet<T>() where T : VolumeComponent
    {
        var volume = TryGet<T>();
        if (volume) return volume;
        else Utility.Log($"{typeof(T).Name}은 없는 볼륨");

        return null;
    }

    private void Init()
    {
        bloom = TryGet<Bloom>();
    }
}
