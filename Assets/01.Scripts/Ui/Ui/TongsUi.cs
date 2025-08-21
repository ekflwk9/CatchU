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

    public void ShowAnimation()
    {
        anim.Play("Play", 0, 0);
    }
}
