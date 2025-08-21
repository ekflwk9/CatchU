using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoxEffectUi : UiBase
{
    [Header("임펙트 이미지"), SerializeField] private Image image;

#if UNITY_EDITOR
    private void Reset()
    {
        image = this.TryGetComponent<Image>();
    }
#endif

    public override void Init()
    {
        UiManager.Instance.Add<BoxEffectUi>(this);
        this.gameObject.SetActive(false);
    }

    public override void On()
    {
        base.On();

        var fade = image.DOFade(0f, 0.3f);
        fade.SetLoops(-1, LoopType.Yoyo);
        fade.SetEase(Ease.Linear);

        var rotate = this.transform.DORotate(new Vector3(0, 0, 90f), 3f);
        rotate.SetEase(Ease.OutSine);
    }

    public override void Off()
    {
        this.transform.rotation = Quaternion.identity;
        this.transform.DOKill();
        image.DOKill();
        base.Off();
    }
}
