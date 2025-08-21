using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoorWindow : UiBase, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image image;
    private float moveSpeed = 0.001f;

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
    }

    public void OnDrag(PointerEventData eventData)
    {
        image.fillAmount += (eventData.delta.y * moveSpeed) * -1f;

        if (image.fillAmount <= 0f)
        {
            OnEvent();
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        image.fillAmount = 1f;
    }

    private void OnEvent()
    {
        //UiManager.Instance.Get<>
        UiManager.Instance.Get<StartButtonUi>().CanButton();
    }
}
