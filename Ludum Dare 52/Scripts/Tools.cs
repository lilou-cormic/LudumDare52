using PurpleCable;
using System.Collections.Generic;

public static class Tools
{
    #region Data

    private static ToolTypeResourceDictionary Defs;

    #endregion

    #region Methods

    internal static void SetDefs(ToolTypeResourceDictionary defs)
    {
        Defs = defs;
    }

    public static ToolDef GetToolDef(ToolType toolType)
        => Defs.Get(toolType);

    #endregion

    #region class ToolTypeResourceDictionary

    internal class ToolTypeResourceDictionary : ResourceDictionary<ToolType, ToolDef>
    {
        #region Initialization

        public ToolTypeResourceDictionary(IEnumerable<ToolDef> resources)
            : base(resources)
        { }

        #endregion

        #region Methods

        protected override ToolType GetKeyForItem(ToolDef item)
        {
            return item.ToolType;
        }

        #endregion
    }

    #endregion
}