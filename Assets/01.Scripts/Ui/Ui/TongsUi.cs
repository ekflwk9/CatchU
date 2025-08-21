using Unity.VisualScripting;
using UnityEngine;

public class TongsUi : UiBase
{
    [SerializeField] private Animator anim;

#if UNITY_EDITOR
    private void Reset()
    {
        anim = this.TryGetComponent<Animator>();
        if(!anim) anim = this.AddComponent<Animator>();
    }
#endif

    public override void Init()
    {
        UiManager.Instance.Add<TongsUi>(this);
    }

    public override void Off()
    {
        anim.Play(Str.Idle, 0, 0);
    }

    public void ShowAnimation()
    {
        anim.Play(Str.Play, 0, 0);
    }

    private void StartEvent()
    {
        //애니메이션 호출 전용 메서드
        UiManager.Instance.On<BoxEffectUi>();
    }

    private void EndEvent()
    {
        //애니메이션 호출 전용 메서드
        UiManager.Instance.On<DoorUi>();
        UiManager.Instance.Off<BoxEffectUi>();
    }
}
