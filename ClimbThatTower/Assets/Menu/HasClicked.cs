using UnityEngine;
using System.Collections;

public class HasClicked : MonoBehaviour
{
    private bool _hasClicked = false;

    public void click()
    {
        this._hasClicked = true;
    }

    public bool hasClicked()
    {
        if (this._hasClicked == true)
        {
            this._hasClicked = false;
            return (true);
        }
        return (false);
    }
}
