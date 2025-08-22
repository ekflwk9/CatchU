using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffectUi : UiBase
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
        UiManager.Instance.Add<ItemEffectUi>(this);
    }

    public void SetColor(Color _color)
    {
        var changeColor = _color;
        changeColor.a = 0f;

        image.color = _color;
    }

    public void SetAlpha(float _value)
    {
        var result = 0.7f - _value;
        if (0.3f < result) result = 0.3f;

        var thisColor = image.color;
        thisColor.a = result;
        image.color = thisColor;
    }

    public override void On()
    {
        base.On();

        var tween = this.transform.DORotate(new Vector3(0, 0, 360f), 0.5f, RotateMode.FastBeyond360);
        tween.SetRelative();
        tween.SetLoops(-1, LoopType.Restart);
        tween.SetEase(Ease.Linear);
    }

    public override void Off()
    {
        this.transform.DOKill();
        this.transform.rotation = Quaternion.identity;
        SetColor(image.color);

        base.Off();
    }
}
