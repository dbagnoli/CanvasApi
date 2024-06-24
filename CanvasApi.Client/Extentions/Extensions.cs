using CanvasApi.Client.Attributes;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CanvasApi.Client.Extentions {
    public static class Extensions {
        /// <summary>
        /// Gets the string used by Canvas used to refer to this enum member.
        /// </summary>
        /// <returns>The string.</returns>
        /// <remarks>
        /// For any enum member decorated with the <see cref="ApiRepresentationAttribute"/> attribute,
        /// the name returned by this function must be used in requests instead of the literal name of the member,
        /// and any API response will refer to this member by that name.
        /// </remarks>
        /// <seealso cref="ApiRepresentationAttribute"/>
        [CanBeNull]
        [Pure]
        internal static string GetApiRepresentation ( [NotNull] this Enum en ) {
            MemberInfo[] member = en.GetType().GetMember(en.ToString());

            if (member.Length <= 0)
                return null;

            object[] attribute = member[0].GetCustomAttributes(typeof(ApiRepresentationAttribute), false);

            return attribute.Length > 0 ? ((ApiRepresentationAttribute)attribute[0]).Representation
                                        : null;
        }
        /// <summary>
        /// Gets a collection of every flag represented by this flag enum.
        /// </summary>
        /// <returns>The collection of flags.</returns>
        /// <remarks>
        /// If this enum is empty (<c>0x0</c>), any "default" <c>0x0</c> flag will not be returned, and the collection
        /// will be empty.
        /// </remarks>
        [Pure]
        internal static IEnumerable<TE> GetFlags<TE> ( this TE en ) where TE : Enum {
            ulong flag = 1;

            foreach (var value in Enum.GetValues(en.GetType()).Cast<TE>()) {
                var bits = Convert.ToUInt64(value);

                while (flag < bits) {
                    flag <<= 1;
                }

                if (flag == bits && en.HasFlag(value)) {
                    yield return value;
                }
            }
        }
        internal static string IdOrSelf ( this ulong? uId ) => uId != null ? uId.ToString() : "self";

        [Pure]
        internal static IEnumerable<string> GetFlagsApiRepresentations ( [NotNull] this Enum en ) {
            return en.GetFlags().GetApiRepresentations();
        }

        [Pure]
        internal static IEnumerable<string> GetApiRepresentations ( [NotNull] this IEnumerable<Enum> ie ) {
            return ie.Select(e => e.GetApiRepresentation());
        }

        [PublicAPI]
        public static IEnumerable<T> Peek<T> ( [NotNull] this IEnumerable<T> ie, Action<T> a ) {
            List<T> list = ie.ToList();
            foreach (var e in list) {
                a(e);
            }

            return list;
        }

        [Pure]
        internal static (TK, TO) ValSelect<TK, TV, TO> ( this (TK, TV) kvp, Func<TV, TO> f ) {
            return (kvp.Item1, f(kvp.Item2));
        }

        [Pure]
        internal static IEnumerable<(TK, TO)> ValSelect<TK, TV, TO> ( this IEnumerable<(TK, TV)> kvp, Func<TV, TO> f ) {
            return kvp.Select(kv => kv.ValSelect(f));
        }

        [Pure]
        internal static KeyValuePair<TO, TV> KeySelect<TK, TV, TO> ( this KeyValuePair<TK, TV> kvp, Func<TK, TO> f ) {
            return KeyValuePair.New(f(kvp.Key), kvp.Value);
        }

        [Pure]
        internal static IEnumerable<(TO, TV)> KeySelect<TK, TV, TO> ( this IEnumerable<(TK, TV)> kvp, Func<TK, TO> f ) {
            return kvp.Select(kv => kv.KeySelect(f));
        }

        [Pure]
        internal static Dictionary<TO, TV> KeySelect<TK, TV, TO> ( this IDictionary<TK, TV> d, Func<TK, TO> f ) {
            return d.Select(kv => kv.KeySelect(f)).IdentityDictionary();
        }

        [Pure]
        internal static Dictionary<TK, TV> IdentityDictionary<TK, TV> ( this IEnumerable<KeyValuePair<TK, TV>> ie ) {
            return ie.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        [Pure]
        internal static (TO, TV) KeySelect<TK, TV, TO> ( this (TK, TV) kvp, Func<TK, TO> f ) {
            return (f(kvp.Item1), kvp.Item2);
        }

        internal static class KeyValuePair {
            internal static KeyValuePair<TK, TV> New<TK, TV> ( TK k, TV v ) => new KeyValuePair<TK, TV>(k, v);
        }
    }
}