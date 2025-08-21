using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUi : UiBase
{
    [Header("페이드 이미지"), SerializeField] private Image image;

#if UNITY_EDITOR
    private void Reset()
    {
        image = this.TryGetComponent<Image>();
        image.color = Color.white;
        this.gameObject.SetActive(false);
    }
#endif

    public override void Init()
    {
        UiManager.Instance.Add<PopUpUi>(this);
    }

    public override void On()
    {
        base.On();

        var tween = image.DOFade(0.7f, 1f);
        tween.OnComplete(OnComplete);
    }

    private void OnComplete()
    {
        UiManager.Instance.Off<TongsUi>();

        image.DOKill();
        this.gameObject.SetActive(false);
    }
}
