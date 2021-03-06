using System.Collections;
using VipSoft.Data.Engine;

namespace VipSoft.Data.Context
{
    public abstract class MapBasedSessionContext : CurrentSessionContext
    {
        private readonly ISessionFactoryImplementor _factory;

        protected MapBasedSessionContext(ISessionFactoryImplementor factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Gets or sets the currently bound session.
        /// </summary>
        protected override ISession Session
        {
            get
            {
                IDictionary map = GetMap();
                if (map == null)
                {
                    return null;
                }
                else
                {
                    return map[_factory] as ISession;
                }
            }
            set
            {
                IDictionary map = GetMap();
                if (map == null)
                {
                    map = new Hashtable();
                    SetMap(map);
                }
                map[_factory] = value;
            }
        }

        /// <summary>
        /// Get the dicitonary mapping session factory to its current session.
        /// </summary>
        protected abstract IDictionary GetMap();

        /// <summary>
        /// Set the map mapping session factory to its current session.
        /// </summary>
        protected abstract void SetMap(IDictionary value);
    }
}