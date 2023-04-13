using System;

namespace CanvasApi.Client.Attributes {

    [AttributeUsage(AttributeTargets.Field)]
    internal sealed class ApiRepresentationAttribute : Attribute {
        internal string Representation { get; }

        public ApiRepresentationAttribute ( string representation ) {
            Representation = representation;
        }
    }
}