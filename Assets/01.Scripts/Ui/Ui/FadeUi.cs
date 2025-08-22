using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeUi : UiBase
{
    [SerializeField] private Image image;

#if UNITY_EDITOR
    private void Reset()
    {
        image = this.TryGetComponent<Image>();
    }
#endif

    public override void Init()
    {
        var changeColor = Color.black;
        changeColor.a = 0;
        image.color = changeColor;

        UiManager.Instance.Add<FadeUi>(this);
    }

    public override void On()
    {
        base.On();

        var tween = image.DOFade(1f, 1f);
        tween.OnComplete(FadeIn);
    }

    private void FadeIn()
    {
        UiManager.Instance.Get<DoorWindow>().CanButton();
        UiManager.Instance.Off<ResultUi>();
        UiManager.Instance.Off<DoorUi>();

        var tween = image.DOFade(0, 1f);
        tween.OnComplete(FadeOut);
    }

    private void FadeOut()
    {
        image.DOKill();
        this.gameObject.SetActive(false);
    }
}
