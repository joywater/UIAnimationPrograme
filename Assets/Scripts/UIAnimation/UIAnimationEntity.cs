using UnityEngine;

public class UIAnimationEntity
{
    public RectTransform TargetTrans
    {
        private set;
        get;
    }

    private float passTime = 0;
    private CanvasGroup canvasGroup = null;
    private UIAnimationSettingAsset.AnimSetting m_AnimSetting;
    private Vector3 initPos = Vector3.zero;
    private Vector3 movePos = Vector3.zero;
    private Vector3 scaleVec = Vector3.zero;
    private Vector3 rotVec = Vector3.zero;
    private float animTotalTime = 0;

    public void SetAnimInfo(RectTransform transform, UIAnimationSettingAsset.AnimSetting animSetting, Vector3 initAnchorPos)
    {
        TargetTrans = transform;
        m_AnimSetting = animSetting;
        passTime = 0;
        if(initAnchorPos.x == -1)
        {
            initPos = transform.anchoredPosition;
        }
        else
        {
            initPos = initAnchorPos;
        }
    }

    public void OnUpdate(float dt, float timeSinceUpdate)
    {
        passTime = passTime + dt;
        //位移
        if (m_AnimSetting.ratioMoveX > 0 || m_AnimSetting.ratioMoveY > 0)
        {
            movePos.x = m_AnimSetting.ratioMoveX * m_AnimSetting.xMoveCurve.Evaluate(passTime);
            movePos.y = m_AnimSetting.ratioMoveY * m_AnimSetting.yMoveCurve.Evaluate(passTime);
            TargetTrans.anchoredPosition = initPos + movePos;
            UpdateAnimTotalTime(m_AnimSetting.xMoveCurve);
            UpdateAnimTotalTime(m_AnimSetting.yMoveCurve);
        }
        if(m_AnimSetting.ratioAlpha > 0)
        {
            if(canvasGroup==null)
            {
                canvasGroup = TargetTrans.GetComponent<CanvasGroup>();
            }
            if (canvasGroup == null)
            {
                canvasGroup = TargetTrans.gameObject.AddComponent<CanvasGroup>();
            }
            float alpha = m_AnimSetting.ratioAlpha * m_AnimSetting.alphaCurve.Evaluate(passTime);
            canvasGroup.alpha = alpha;
            UpdateAnimTotalTime(m_AnimSetting.alphaCurve);
        }
        if(m_AnimSetting.ratioScaleX > 0 || m_AnimSetting.ratioScaleY > 0)
        {
            scaleVec.x = m_AnimSetting.ratioScaleX * m_AnimSetting.xScaleCurve.Evaluate(passTime);
            scaleVec.y = m_AnimSetting.ratioScaleY * m_AnimSetting.yScaleCurve.Evaluate(passTime);
            TargetTrans.localScale = scaleVec;
            UpdateAnimTotalTime(m_AnimSetting.xScaleCurve);
            UpdateAnimTotalTime(m_AnimSetting.yScaleCurve);
        }
        if (m_AnimSetting.ratioRotX > 0 || m_AnimSetting.ratioRotY > 0 || m_AnimSetting.ratioRotZ > 0)
        {
            rotVec.x = m_AnimSetting.ratioRotX * m_AnimSetting.rotCurveX.Evaluate(passTime);
            rotVec.y = m_AnimSetting.ratioRotY * m_AnimSetting.rotCurveY.Evaluate(passTime);
            rotVec.z = m_AnimSetting.ratioRotZ * m_AnimSetting.rotCurveZ.Evaluate(passTime);
            TargetTrans.localEulerAngles = rotVec;
            UpdateAnimTotalTime(m_AnimSetting.rotCurveX);
            UpdateAnimTotalTime(m_AnimSetting.rotCurveY);
            UpdateAnimTotalTime(m_AnimSetting.rotCurveZ);
        }
        if (m_AnimSetting.wrapType != UIAnimationSettingAsset.WrapType.Loop && passTime > animTotalTime) 
        {
            //GS.UIAnimSystem.RemoveOneUIAnim(TargetTrans);
        }
    }

    private void UpdateAnimTotalTime(AnimationCurve animCurve)
    {
        if(animCurve.length > 0 && animCurve.keys[animCurve.length-1].time > animTotalTime)
        {
            animTotalTime = animCurve.keys[animCurve.length-1].time;
        }
    }
    public void Clear()
    {
        TargetTrans = null;
        passTime = 0;
        m_AnimSetting = null;
    }
}
