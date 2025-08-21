using Unity.VisualScripting;
using UnityEngine;

public class DoorUi : UiBase
{
    [SerializeField] private Animator anim;

#if UNITY_EDITOR
    private void Reset()
    {
        anim = this.TryGetComponent<Animator>();
        if (!anim) anim = this.AddComponent<Animator>();
    }
#endif

    public override void Init()
    {
        UiManager.Instance.Add<DoorUi>(this);
    }

    public override void On()
    {
        base.On();
        anim.Play(Str.Play, 0, 0);
    }
}
