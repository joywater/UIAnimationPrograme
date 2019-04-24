using UnityEngine;

public class UIAnimationTest : MonoBehaviour {
    private UIAnimationEntitySystem m_UIAnimSystem;
    public RectTransform recTransform;
    // Use this for initialization
    private void Start () {
        m_UIAnimSystem = new UIAnimationEntitySystem();
    }
	
	// Update is called once per frame
	void Update () {
        m_UIAnimSystem.Update(Time.deltaTime);
	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,200,100), "播放"))
        {
            m_UIAnimSystem.AddOneUIAnim(recTransform, "test");
        }
        if(GUI.Button(new Rect(0, 300, 200, 100),"停止"))
        {
            m_UIAnimSystem.RemoveOneUIAnim(recTransform);
        }
    }
}
