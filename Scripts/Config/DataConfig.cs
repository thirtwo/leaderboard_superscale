// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using UnityEngine;
namespace Thirtwo.Config
{
    [CreateAssetMenu(fileName = "DataConfig", menuName = "Thirtwo/Data/Data Config")]
    public class DataConfig : Config
    {
        [field: SerializeField] public TextAsset[] Datas { get; private set; }

        private int index = 0;
        private int DataIndex
        {
            get
            {
                if(index >= Datas.Length) 
                    index = 0;
                return index++;
            }
        }

        public TextAsset GetAsset()
        {
            return Datas[DataIndex];
        }

        
    }
}
