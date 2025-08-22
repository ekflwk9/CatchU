using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoxEffectUi : UiBase
{
    [Header("임펙트 이미지"), SerializeField] private Image image;
    private Color color;

#if UNITY_EDITOR
    private void Reset()
    {
        image = this.TryGetComponent<Image>();
    }
#endif

    public override void Init()
    {
        color = image.color;
        UiManager.Instance.Add<BoxEffectUi>(this);
        this.gameObject.SetActive(false);
    }

    public override void On()
    {
        base.On();

        image.color = color;
        var fade = image.DOFade(0f, 0.3f);
        fade.SetLoops(-1, LoopType.Yoyo);
        fade.SetEase(Ease.Linear);

        var rotate = this.transform.DORotate(new Vector3(0, 0, 360f), 0.5f, RotateMode.FastBeyond360);
        rotate.SetRelative();
        rotate.SetLoops(-1, LoopType.Restart);
        rotate.SetEase(Ease.Linear);
    }

    public override void Off()
    {
        this.transform.DOKill();
        this.transform.rotation = Quaternion.identity;

        image.DOKill();
        base.Off();
    }
}
