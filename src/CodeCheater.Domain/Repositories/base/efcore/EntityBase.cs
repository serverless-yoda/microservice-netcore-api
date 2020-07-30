using System;
using System.Collections.Generic;

namespace CodeCheater.Domain.Repositories
{
    public abstract class EntityBase<TId> : IEntityBase<TId>, IEquatable<EntityBase<TId>>
    {
        int? _requestedHashCode;
        public virtual TId Id { get; protected set; }
        public bool IsTransient()
        {
            return Id.Equals(default(TId));
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is EntityBase<TId>)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
           
            var item = (EntityBase<TId>)obj;
            if (item.IsTransient() || IsTransient()) return false;
           
            return item == this;
        }

        public bool Equals(EntityBase<TId> other)
        {
            return other != null;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue) _requestedHashCode = Id.GetHashCode() ^ 31;
                return _requestedHashCode.Value;
            }
            else return base.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> left, EntityBase<TId> right)
        {
            return EqualityComparer<EntityBase<TId>>.Default.Equals(left, right);
        }

        public static bool operator !=(EntityBase<TId> left, EntityBase<TId> right)
        {
            return !(left == right);
        }
    }
}
