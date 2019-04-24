using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIAnimationSetting", menuName = "配置文件/UI动画样式")]
public class UIAnimationSettingAsset : ScriptableObject
{
    [System.Serializable]
    public enum WrapType
    {
        Once = 1,
        Loop = 2,
    }
    [System.Serializable]
    public class AnimSetting
    {
        public string animStyleKey;
        public WrapType wrapType = WrapType.Once;
        //水平位移曲线
        public float ratioMoveX = 0;
        public AnimationCurve xMoveCurve = new AnimationCurve(new Keyframe(0f, 1f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));
        //竖直位移曲线
        public float ratioMoveY = 0;
        public AnimationCurve yMoveCurve = new AnimationCurve(new Keyframe(0f, 1f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));
        //大小曲线
        public float ratioScaleX = 0;
        public AnimationCurve xScaleCurve = new AnimationCurve(new Keyframe(0f, 1f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));
        public float ratioScaleY = 0;
        public AnimationCurve yScaleCurve = new AnimationCurve(new Keyframe(0f, 1f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));
        //透明度
        public float ratioAlpha = 0;
        public AnimationCurve alphaCurve = new AnimationCurve(new Keyframe(0f, 1f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));
        //旋转
        public float ratioRotX = 0;
        public AnimationCurve rotCurveX = new AnimationCurve(new Keyframe(0f, 1f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));
        public float ratioRotY = 0;
        public AnimationCurve rotCurveY = new AnimationCurve(new Keyframe(0f, 1f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));
        public float ratioRotZ = 0;
        public AnimationCurve rotCurveZ = new AnimationCurve(new Keyframe(0f, 1f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f));
    }

    public List<AnimSetting> animSetting = new List<AnimSetting>();
}