using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    public struct IdOrKey
    {
        public long? Id { get; private set; }

        public string Key { get; private set; }

        public IdOrKey(long id) : this()
        {
            this.Id = id;
            this.Key = null;
        }

        public IdOrKey(string key) : this()
        {
            this.Id = null;
            this.Key = key;
        }

        public override string ToString() => Id.HasValue ? Id.ToString() : Key ?? "";

        public static implicit operator IdOrKey(long id) => new IdOrKey(id);

        public static implicit operator IdOrKey(string key) => new IdOrKey(key);
    }
}
