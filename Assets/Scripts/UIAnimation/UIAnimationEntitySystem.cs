using System.Collections.Generic;
using UnityEngine;

    public class UIAnimationEntitySystem
    {
        private UIAnimationSettingAsset m_AssetList = null;

        private List<UIAnimationEntity> m_UIAnimList = new List<UIAnimationEntity>();

        public void AddOneUIAnim(Transform uiTrans, string animId, Vector3 initAnchorPos)
        {
            if (m_AssetList == null)
                m_AssetList = Resources.Load<UIAnimationSettingAsset>("UIAnimationSetting");
            UIAnimationEntity tempEntity = new UIAnimationEntity();
            tempEntity.SetAnimInfo(uiTrans as RectTransform, GetAnimSettingById(animId), initAnchorPos);
            m_UIAnimList.Add(tempEntity);
            //GS.Update.AddEntity(tempEntity);
        }

        public void AddOneUIAnim(Transform uiTrans, string animId)
        {
            if (IsExist(uiTrans))
                return;
            if(m_AssetList == null)
                m_AssetList = Resources.Load<UIAnimationSettingAsset>("UIAnimationSetting");
            UIAnimationEntity tempEntity = new UIAnimationEntity();
            tempEntity.SetAnimInfo(uiTrans as RectTransform, GetAnimSettingById(animId), Vector3.one * -1);
            m_UIAnimList.Add(tempEntity);
            //GS.Update.AddEntity(tempEntity);
        }

        public void RemoveOneUIAnim(Transform uiTrans)
        {
            for (int i = m_UIAnimList.Count-1; i >= 0; i--)
            {
                if (m_UIAnimList[i].TargetTrans == uiTrans)
                {
                    UIAnimationEntity entity = m_UIAnimList[i];
                    m_UIAnimList.RemoveAt(i);
                    //GS.Update.RemoveEntity(entity);
                    break;
                }
            }
        }

        public void ClearData(bool clearAssetList)
        {
            for (int i = m_UIAnimList.Count - 1; i >= 0; i--)
            {
                RemoveOneUIAnim(m_UIAnimList[i].TargetTrans);
            }
            if(clearAssetList)
            {
                m_AssetList = null;
            }
        }

        private bool IsExist(Transform transform)
        {
            for (int i = m_UIAnimList.Count - 1; i >= 0; i--)
            {
                if (m_UIAnimList[i].TargetTrans == transform)
                    return true;
            }
            return false;
        }

        private UIAnimationSettingAsset.AnimSetting GetAnimSettingById(string animId)
        {
            for(int i=0;i< m_AssetList.animSetting.Count;i++)
            {
                if (m_AssetList.animSetting[i].animStyleKey == animId)
                    return m_AssetList.animSetting[i];
            }
            return null;
        }

        public void Update(float delta)
        {
            for (int i = m_UIAnimList.Count - 1; i >= 0; i--)
            {
                m_UIAnimList[i].OnUpdate(delta, 0);
            }
        }
    }
