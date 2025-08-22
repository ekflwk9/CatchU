using UnityEngine.EventSystems;

public class TakeButtonUi : UiBase, IPointerClickHandler
{
    public override void Init()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UiManager.Instance.On<FadeUi>();

        //아이템 저장 로직 추가
    }
}
