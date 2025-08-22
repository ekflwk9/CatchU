using UnityEngine;
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
            var item = ItemManager.GetRandomItem();

            UiManager.Instance.Get<TongsUi>().ShowAnimation();
            UiManager.Instance.Get<ResultUi>().SetItem(item);
            UiManager.Instance.Get<ItemEffectUi>().SetColor(item.effectColor);
            isClick = true;
        }
    }
}
