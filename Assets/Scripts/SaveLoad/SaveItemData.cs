using System.Collections.Generic;


namespace SaveDate
{
    [System.Serializable]
    public class SaveItemData
    {
        public bool SaveLoad;

        public List<int> SlotId;
        public List<int> IdItem;
        public List<int> Count;

        public List<int> SlotEqupId;
        public List<int> IdEqupItem;

        public SaveItemData()
        {

        }
    }
}
