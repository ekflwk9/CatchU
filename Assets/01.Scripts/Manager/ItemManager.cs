using System.Collections.Generic;
using UnityEngine;

public struct Item
{
    public Sprite sprite;
    public string title;
    public string name;
    public int price;
    public Color effectColor;

    public Item(Sprite _sprite, string _title, string _name, int _price, Color _color)
    {
        sprite = _sprite;
        title = _title;
        name = _name;
        price = _price;
        effectColor = _color;
    }
}

public static class ItemManager
{
    private static List<Item> items = new(50);
    private static bool isStart;

    private static void CheckStart()
    {
        if(!isStart)
        {
            isStart = true;
            LoadItem();
        }
    }

    private static void LoadItem()
    {
        //추후 CSV로 추가 가능
        var sprite = Resources.Load<Sprite>($"{Str.Sprite}/item1");
        items.Add(new Item(sprite, "구찌", "구찌 한정판 가방", 1500000, Color.yellow));

        sprite = Resources.Load<Sprite>($"{Str.Sprite}/item2");
        items.Add(new Item(sprite, "애플", "아이폰 17", 900000, Color.blue));

        sprite = Resources.Load<Sprite>($"{Str.Sprite}/item3");
        items.Add(new Item(sprite, "루이비통", "루이비통 한정판 가방", 2300000, Color.yellow));

        sprite = Resources.Load<Sprite>($"{Str.Sprite}/item4");
        items.Add(new Item(sprite, "애플", "에어팟 프로", 300000, Color.white));
    }

    public static Item GetRandomItem()
    {
        CheckStart();

        var ranItem = Random.Range(0, items.Count);
        return items[ranItem];
    }
}
