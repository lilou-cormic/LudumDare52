using PurpleCable;
using System.Collections.Generic;

public static class Crops
{
    #region Data

    private static CropTypeResourceDictionary Defs;

    #endregion

    #region Methods

    internal static void SetDefs(CropTypeResourceDictionary defs)
    {
        Defs = defs;
    }

    public static CropDef GetCropDef(CropType cropType)
        => Defs.Get(cropType);

    #endregion

    #region class CropTypeResourceDictionary

    internal class CropTypeResourceDictionary : ResourceDictionary<CropType, CropDef>
    {
        #region Initialization

        public CropTypeResourceDictionary(IEnumerable<CropDef> resources)
            : base(resources)
        { }

        #endregion

        #region Methods

        protected override CropType GetKeyForItem(CropDef item)
        {
            return item.CropType;
        }

        #endregion
    }

    #endregion
}
