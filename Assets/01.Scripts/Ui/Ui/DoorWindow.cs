using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoorWindow : UiBase, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image image;
    private float moveSpeed = 0.001f;
    private bool isClick;

#if UNITY_EDITOR
    private void Reset()
    {
        image = this.TryGetComponent<Image>();
        image.fillAmount = 1f;
    }
#endif

    public override void Init()
    {
        UiManager.Instance.Add<DoorWindow>(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        UiManager.Instance.On<ItemEffectUi>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isClick) return;
        image.fillAmount += (eventData.delta.y * moveSpeed) * -1f;
        UiManager.Instance.Get<ItemEffectUi>().SetAlpha(image.fillAmount);

        if (image.fillAmount <= 0f) OnEvent();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        image.fillAmount = 1f;
        UiManager.Instance.Off<ItemEffectUi>();
    }

    private void OnEvent()
    {
        isClick = true;
        image.fillAmount = 1f;
        UiManager.Instance.On<ResultUi>();
        UiManager.Instance.Off<TongsUi>();
        UiManager.Instance.Off<ItemEffectUi>();
        UiManager.Instance.Get<StartButtonUi>().CanButton();
    }

    public void CanButton()
    {
        isClick = false;
    }
}
