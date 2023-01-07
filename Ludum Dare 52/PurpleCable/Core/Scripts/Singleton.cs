using System;

namespace PurpleCable
{
    /// <summary>
    /// Node2D: Singleton
    /// </summary>
    /// <typeparam name="TSingleton"></typeparam>
    public abstract class Singleton<TSingleton>
        where TSingleton : Singleton<TSingleton>, new()
    {
        #region Instance

        private static TSingleton _Instance = null;
        /// <summary>Singleton instance</summary>
        public static TSingleton Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new TSingleton();

                return _Instance;
            }
        }

        #endregion

        #region Initialization

        protected Singleton()
        { }

        #endregion
    }
}
