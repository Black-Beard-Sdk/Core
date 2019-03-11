using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.ComponentModel.Attributes
{

    public enum IocScopeEnum
    {

        /// <summary>
        /// Specifies that a single instance of the service will be created.
        /// </summary>
        Singleton = 0,
        
        /// <summary>
        /// The scopedSpecifies that a new instance of the service will be created for each scope.
        /// </summary>
        /// <remarks>In ASP.NET Core applications a scope is created around each server request.</remarks>
        Scoped = 1,

        /// <summary>
        /// Specifies that a new instance of the service will be created every time it is requested.
        /// </summary>
        Transient = 2,

    }

    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class IocRegisterAttribute : Attribute
    {

        // This is a positional argument
        public IocRegisterAttribute(Type exposedType, IocScopeEnum scope = IocScopeEnum.Transient)
        {
            this.ExposedType = exposedType;
            this.Scope = scope;
        }

        public Type ExposedType { get; }

        public IocScopeEnum Scope { get; }

    }

}
