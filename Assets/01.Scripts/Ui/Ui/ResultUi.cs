using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResultUi : UiBase
{
    [SerializeField] private Image image;
    [SerializeField] private Animator anim;

#if UNITY_EDITOR
    private void Reset()
    {
        image = this.TryGetComponent<Image>();
        anim = this.TryGetComponent<Animator>();
        if (!anim) anim = this.AddComponent<Animator>();
    }
#endif

    public override void Init()
    {
        UiManager.Instance.Add<ResultUi>(this);
    }
}
