using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectExtension {

	public static Vector2 GetCenter(this Rect rect) {
        return new Vector2(rect.position.x + rect.width / 2, rect.position.y + rect.height / 2);
    }

    public static Rect AddX(this Rect rect, float x) {
        return rect.SetX(rect.x + x);
    }

    public static Rect AddY(this Rect rect, float y) {
        return rect.SetY(rect.y + y);
    }

    public static Rect AddWith(this Rect rect, float width) {
        return rect.SetWidth(rect.width + width);
    }

    public static Rect AddHeight(this Rect rect, float height) {
        return rect.SetHeight(rect.height + height);
    }

    public static Rect SetX(this Rect rect, float x) {
        return new Rect(x, rect.y, rect.width, rect.height);
    }

    public static Rect SetY(this Rect rect, float y) {
        return new Rect(rect.x, y, rect.width, rect.height);
    }

    public static Rect SetWidth(this Rect rect, float width) {
        return new Rect(rect.x, rect.y, width, rect.height);
    }

    public static Rect SetHeight(this Rect rect, float height) {
        return new Rect(rect.x, rect.y, rect.width, height);
    }

}
