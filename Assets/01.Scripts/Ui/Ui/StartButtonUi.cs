using UnityEngine.EventSystems;

public class StartButtonUi : UiBase, IPointerClickHandler
{
    private bool isClick;

    public override void Init()
    {
        UiManager.Instance.Add<StartButtonUi>(this);
    }

    public void CanButton()
    {
        isClick = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClick)
        {
            UiManager.Instance.Get<TongsUi>().ShowAnimation();
            isClick = true;
        }
    }
}
